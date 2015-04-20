using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using ModbusCommon.Models;
using ModbusCommunication.Models;
using ModbusCommunication.Repositories;
using ModbusCommunication.Services;
using Npgsql;

namespace ModbusCommunication.Forms
{
    public partial class MainForm : Form
    {
        private GatewayService _gatewayService;
        private SensorBgWService _sensorBgWService;
        private GatewayRepository _gatewayRepository;

        private Timer _uxGetSensorStatusTimer;

        private List<Gateway> _gateways = new List<Gateway>();
        private bool _isRunning;
        private bool _isConnectionToDatabaseFailed;
        private int _errorCounter;
        //private bool _isSendEmail;

        public MainForm()
        {
            InitializeComponent();
            InitializeObject();
            TimersConfiguration();
        }

        private void InitializeObject()
        {
            _gatewayService = new GatewayService();
            _sensorBgWService = new SensorBgWService();
            _gatewayRepository = new GatewayRepository();
        }

        private void TimersConfiguration()
        {
            try
            {
                _uxGetSensorStatusTimer = new Timer
                {
                    Interval = 1000
                };

                _uxGetSensorStatusTimer.Tick += _uxGetSensorStatusTimer_Tick;
            }
            catch (Exception ex)
            {
                IncreaseErrorCounter();
                DisplayMessage(ex.Message);
            }
        }

        private void DisplayMessage(string message)
        {
            uxConsoleLog.Nodes.Add(String.Format("{0} - {1}", DateTime.Now, message));
            uxConsoleLog.Nodes[uxConsoleLog.Nodes.Count - 1].EnsureVisible();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                uxIsProccesing.Visible = false;
                DisplayMessage("Aplikacja rozpoczęła pracę.");
                _isRunning = true;
                SetStartAndStopEnables();
                GetGateways();
                StartTimer();
            }
            catch (Exception ex)
            {
                IncreaseErrorCounter();
                DisplayMessage(ex.Message);
            }
        }

        private void uxRefreshConsole_Click(object sender, EventArgs e)
        {
            uxConsoleLog.Nodes.Clear();
        }

        private void uxStart_Click(object sender, EventArgs e)
        {
            try
            {
                DisplayMessage("Aplikacja rozpoczęła pracę.");
                StartTimer();
                _isRunning = true;
                SetStartAndStopEnables();
                GetGateways(); 
            }
            catch (Exception ex)
            {
                IncreaseErrorCounter();
                DisplayMessage(ex.Message);
            }
        }

        private void uxStop_Click(object sender, EventArgs e)
        {
            DisplayMessage("Aplikacja zakończyła pracę.");
            _isRunning = false;
            SetStartAndStopEnables();
            StopTimer();
        }

        private void _uxGetSensorStatusTimer_Tick(object sender, EventArgs e)
        {
            foreach (var gateway in _gateways.Where(g => g.IsAvailable))
            {
                try
                {
                    if (gateway.SensorsIntervalCounter < gateway.SensorsInterval)
                        gateway.SensorsIntervalCounter++;
                    else
                    {
                        lock (SerialPortToken.Instance)
                        {
                            SerialPortToken.Instance.ConnectToSerialPort(gateway.SerialPort);
                            _sensorBgWService.InitializeConnection();
                            StopTimer();
                            gateway.SensorsIntervalCounter = 0;
                            uxIsProccesing.Visible = true;
                            uxSensorBackgroundWorker.RunWorkerAsync(gateway);
                        }
                    }
                }
                //catch (SqlException ex)
                //{
                //    if (!_isSendEmail)
                //    {
                //        _isSendEmail = true;
                //    }
                //}
                catch (Exception ex)
                {
                    SerialPortToken.Instance.DisconnectSerialPort();
                    uxIsProccesing.Visible = false;
                    DisplayMessage(ex.Message);
                    IncreaseErrorCounter();
                }
            }
        }

        private void uxSensorBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var gateway = (Gateway)e.Argument;
            foreach (var sensor in gateway.Sensors)
            {
                try
                {
                    var isStatusChanged = _sensorBgWService.IsSensorStatusChanged(gateway, sensor);
                    var message = GetMessage(gateway, sensor, isStatusChanged);
                    uxSensorBackgroundWorker.ReportProgress(0, message);
                    var firstAndEightRegister = _sensorBgWService.GetFirstAndEightRegister(sensor);
                    uxSensorBackgroundWorker.ReportProgress(0, firstAndEightRegister);
                }
                catch (Exception ex)
                {
                    uxSensorBackgroundWorker.ReportProgress(0, ex);
                }
            }
        }

        private void uxSensorBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var message = e.UserState.ToString();
            if (message.Contains("NpgsqlException"))
            {
                var exceptionMessage = (Exception) e.UserState;
                if (_isConnectionToDatabaseFailed)
                    return;
                _isConnectionToDatabaseFailed = true;
                DisplayMessage(exceptionMessage.Message);
                IncreaseErrorCounter();
                return;
            }

            if (_isConnectionToDatabaseFailed)
                DisplayMessage("Przywrócono połączenie z bazą danych.");

            _isConnectionToDatabaseFailed = false;
            DisplayMessage(message);
        }

        private void uxSensorBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SerialPortToken.Instance.DisconnectSerialPort();
            uxIsProccesing.Visible = false;
            StartTimer();
        }

        private void uxErrorCounter_Click(object sender, EventArgs e)
        {
            uxErrorCounter.BackColor = Color.LimeGreen;
            uxErrorCounter.Text = @"OK";
            _errorCounter = 0;
            _isConnectionToDatabaseFailed = false;
        }

        private static string GetMessage(Gateway gateway, Sensor sensor, bool isStatusChanged)
        {
            var statusMessage = sensor.Status == 0 ? "WOLNY" : "ZAJĘTY";
            var isOfflineMessage = sensor.IsOffline ? "NIEKATYWNY" : "AKTYWNY";
            var isStatusChangedMessage = isStatusChanged ? "Zmiana" : "Brak zmian";
            return String.Format("Strefa {0}, Bramka {1}, Czujnik {2} - {3}, {4}, {5}",
                gateway.ZoneName, sensor.GatewayId, sensor.Id, statusMessage, isOfflineMessage, isStatusChangedMessage);
        }

        private void GetGateways()
        {
            uxSerialPortList.Items.Clear();
            uxSerialPortStatus.Items.Clear();
            _gateways.Clear();

            _gateways = _gatewayService.GetGateways();

            foreach (var gateway in _gateways)
            {
                lock (SerialPortToken.Instance)
                {
                    try
                    {
                        ReloadSerialPortListAndStatus(gateway);
                        if (!gateway.IsAvailable)
                            continue;
                        var response = _gatewayService.GetResponse(gateway);
                        _gatewayRepository.InsertGatewayResponse(gateway, response);
                    }
                    catch (NpgsqlException ex)
                    {
                        if (_isConnectionToDatabaseFailed)
                            return;
                        _isConnectionToDatabaseFailed = true;
                        IncreaseErrorCounter();
                        DisplayMessage(ex.Message);
                    }
                    catch (Exception ex)
                    {
                        IncreaseErrorCounter();
                        DisplayMessage(ex.Message);
                    }
                }
            }
        }

        private void ReloadSerialPortListAndStatus(Gateway gateway)
        {
            uxSerialPortList.Items.Add(gateway.SerialPort);
            uxSerialPortStatus.Items.Add(gateway.IsAvailable ? "AKTYWNY" : "NIEAKTYWNY");
        }

        private void StartTimer()
        {
            _uxGetSensorStatusTimer.Start();
        }

        private void StopTimer()
        {
            _uxGetSensorStatusTimer.Stop();
        }

        private void SetStartAndStopEnables()
        {
            uxStart.Enabled = !_isRunning;
            uxStop.Enabled = _isRunning;
        }

        private void IncreaseErrorCounter()
        {
            if (_errorCounter <= 0)
                uxErrorCounter.BackColor = Color.Red;
            _errorCounter++;
            uxErrorCounter.Text = _errorCounter.ToString(CultureInfo.InvariantCulture);
        }
    }
}
