using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ModbusCommon.Models;
using ModbusCommunication.Models;
using ModbusCommunication.Repositories;
using ModbusCommunication.Services;
using ModbusCommunication.Services.BackgroundWorkerServices;
using ModbusCommunication.Utils;

namespace ModbusCommunication.Forms
{
    public partial class MainForm : Form
    {
        GatewayService _gatewayService;
        SensorBgWService _sensorBgWService;
        GatewayRepository _gatewayRepository;

        Timer _uxGetSensorStatusTimer;
        Timer _uxGetGatewaysTimer;

        List<Gateway> _gateways = new List<Gateway>();
        bool _isRunning;

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

            ConsoleHelper.InitilizeConsole(uxConsoleLog);
        }

        private void TimersConfiguration()
        {
            try
            {
                _uxGetGatewaysTimer = new Timer
                {
                    Interval = 25000
                };

                _uxGetSensorStatusTimer = new Timer
                {
                    Interval = 10000
                };

                _uxGetSensorStatusTimer.Tick += _uxGetSensorStatusTimer_Tick;
                _uxGetGatewaysTimer.Tick += _uxGetGatewaysTimer_Tick;
            }
            catch (Exception ex)
            {
                uxConsoleLog.Nodes.Add(ex.Message);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private void uxRefreshConsole_Click(object sender, EventArgs e)
        {
            ConsoleHelper.ClearConsole();
        }

        private void uxStart_Click(object sender, EventArgs e)
        {
            try
            {
                GetGateways(); 
                ConsoleHelper.AddMessage("Start aplikacji.");
                _isRunning = true;
                SetStartAndStopEnables();
                StartTimers();
            }
            catch (Exception ex)
            {
                ConsoleHelper.AddMessage(ex.Message);
            }
        }

        private void uxStop_Click(object sender, EventArgs e)
        {
            ConsoleHelper.AddMessage("Stop aplikacji.");
            _isRunning = false;
            SetStartAndStopEnables();
            StopTimers();
        }

        private void _uxGetGatewaysTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                StopTimers();
                GetGateways();
            }
            catch (Exception ex)
            {
                StartTimers();
                ConsoleHelper.AddMessage(ex.Message);
            }
            finally
            {
                StartTimers();
            }
        }

        private void _uxGetSensorStatusTimer_Tick(object sender, EventArgs e)
        {
            _uxGetSensorStatusTimer.Stop();
            foreach (var gateway in _gateways.Where(g => g.IsAvailable))
            {
                lock (SerialPortToken.Instance)
                {
                    try
                    {
                        if (gateway.SensorIntervalCounter <= 0)
                        {
                            _sensorBgWService.GetSensorStatusAndUpdateOnDb(gateway);
                            gateway.SensorIntervalCounter = gateway.SensorInterval;
                        }
                        gateway.SensorIntervalCounter--;
                    }
                    catch (Exception ex)
                    {
                        ConsoleHelper.AddMessage(ex.Message);
                        SerialPortToken.Instance.DisconnectSerialPort();
                    }
                }
            }
            _uxGetSensorStatusTimer.Start();
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
                        var response = _gatewayService.GetResponse(gateway);
                        _gatewayRepository.InsertGatewayResponse(gateway, response);
                    }
                    catch (Exception ex)
                    {
                        ConsoleHelper.AddMessage(ex.Message);
                    }
                }
            }
        }

        private void ReloadSerialPortListAndStatus(Gateway gateway)
        {
            uxSerialPortList.Items.Add(gateway.SerialPort);
            uxSerialPortStatus.Items.Add(gateway.IsAvailable ? "AKTYWNY" : "NIEAKTYWNY");
        }

        private void StartTimers()
        {
            _uxGetGatewaysTimer.Start();
            _uxGetSensorStatusTimer.Start();
        }

        private void StopTimers()
        {
            _uxGetSensorStatusTimer.Stop();
            _uxGetGatewaysTimer.Stop();
        }

        private void SetStartAndStopEnables()
        {
            uxStart.Enabled = !_isRunning;
            uxStop.Enabled = _isRunning;
        }
    }
}
