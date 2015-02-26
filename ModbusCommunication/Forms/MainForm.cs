using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ModbusCommunication.Models;
using ModbusCommunication.Services;
using ModbusCommunication.Services.BackgroundWorkerServices;
using ModbusCommunication.Utils;

namespace ModbusCommunication.Forms
{
    public partial class MainForm : Form
    {
        GatewayService _gatewayService;
        SerialPortService _serialPortService;
        SensorBgWService _sensorBgWService;

        Timer _uxGetSensorStatusTimer;
        Timer _uxGetGatewaysTimer;

        List<Gateway> _gateways = new List<Gateway>();
        bool _IsRunning = false;

        public MainForm()
        {
            InitializeComponent();
            InitializeObject();
            TimersConfiguration();
        }

        private void InitializeObject()
        {
            _gatewayService = new GatewayService();
            _serialPortService = new SerialPortService();
            _sensorBgWService = new SensorBgWService();

            ConsoleHelper.InitilizeConsole(uxConsoleLog);
        }

        private void TimersConfiguration()
        {
            try
            {
                _uxGetGatewaysTimer = new Timer
                {
                    Interval = Convert.ToInt32(Configuration.Instance.GetValue("GatewaysInterval"))
                };

                _uxGetSensorStatusTimer = new Timer
                {
                    Interval = Convert.ToInt32(Configuration.Instance.GetValue("SensorsInterval"))
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
            ConsoleHelper.AddMessage("Start aplikacji.");
            _IsRunning = true;
            SetStartAndStopEnables();
            StartTimers();
        }

        private void uxStop_Click(object sender, EventArgs e)
        {
            ConsoleHelper.AddMessage("Stop aplikacji.");
            _IsRunning = false;
            SetStartAndStopEnables();
            StopTimers();
        }

        private void _uxGetGatewaysTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                uxSerialPortList.Items.Clear();
                uxSerialPortStatus.Items.Clear();
                _gateways.Clear();

                _gateways = _gatewayService.GetGateways();
                foreach (var gateway in _gateways)
                {
                    uxSerialPortList.Items.Add(gateway.SerialPort);
                    uxSerialPortStatus.Items.Add(gateway.IsAvailable ? "AKTYWNY" : "NIEAKTYWNY");
                }
            }
            catch (Exception ex)
            {
                ConsoleHelper.AddMessage(ex.Message);
            }
        }

        private void _uxGetSensorStatusTimer_Tick(object sender, EventArgs e)
        {
            _uxGetGatewaysTimer.Stop();
            foreach (var gateway in _gateways.Where(g => g.IsAvailable))
            {
                try
                {
                    _sensorBgWService.GetSensorStatusAndUpdateOnDb(gateway, gateway.SerialPort);
                }
                catch (Exception ex)
                {
                    ConsoleHelper.AddMessage(ex.Message);
                    _serialPortService.DisconnectSerialPort();
                }
            }
            _uxGetGatewaysTimer.Start();
        }

        private void StartTimers()
        {
            _uxGetGatewaysTimer.Start();
            _uxGetSensorStatusTimer.Start();
        }

        private void StopTimers()
        {
            _uxGetGatewaysTimer.Stop();
            _uxGetSensorStatusTimer.Stop();
        }

        private void SetStartAndStopEnables()
        {
            uxStart.Enabled = !_IsRunning;
            uxStop.Enabled = _IsRunning;
        }
    }
}
