using ModbusCommunication.Services;
using ModbusExtension.Models;
using ModbusExtension.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModbusCommunication
{
    public partial class MainForm : Form
    {
        SerialPortService _serialPortService;
        ModbusService _modbusService;
        public MainForm()
        {
            InitializeComponent();
            InitializeCommonObjects();
        }

        private void InitializeCommonObjects()
        {
            _serialPortService = new SerialPortService();
            _modbusService = new ModbusService();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ReloadAvaiableSerialPorts();
        }

        #region ConnectionToSerialPortGroupBox
        private void uxReloadAvailableSerialPorts_Click(object sender, EventArgs e)
        {
            ReloadAvaiableSerialPorts();
        }

        private void ReloadAvaiableSerialPorts()
        {
            uxAvailableSerialPorts.Text = String.Empty;
            if (_serialPortService.GetAvailableSerialPorts().Length > 0)
            {
                uxAvailableSerialPorts.Items.Clear();
                uxAvailableSerialPorts.Items.AddRange(_serialPortService.GetAvailableSerialPorts());
                uxAvailableSerialPorts.SelectedIndex = 0;
            }
            else
                uxAvailableSerialPorts.Text = "Brak dostępnych portów COM";
        }

        private void uxComConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (uxAvailableSerialPorts.SelectedItem != null)
                {
                    _serialPortService.ConnectToSerialPort(uxAvailableSerialPorts.SelectedItem.ToString());
                    uxConnectionSerialPortTest.Text = String.Empty;
                    uxConnectionSerialPortTest.Text = String.Format("Połączenie z portem {0}", uxAvailableSerialPorts.SelectedItem.ToString());
                    uxConsoleLog.Nodes.Add(String.Format("Połączenie z portem {0}", uxAvailableSerialPorts.SelectedItem.ToString()));
                    uxConnectionSerialPortTest.ForeColor = Color.Green;
                    uxConnectionSerialPort.Enabled = false;
                    uxDisconnectSerialPort.Enabled = true;
                    uxConnectionToGatewayGroup.Enabled = true;
                }
                else
                    throw new Exception("Nie wybrano portu COM");
            }
            catch (Exception ex)
            {
                uxConsoleLog.Nodes.Add(ex.Message);
            }
        }

        private void uxComDisconnect_Click(object sender, EventArgs e)
        {
            _serialPortService.DisconnectSerialPort();
            uxConnectionSerialPortTest.Text = String.Empty;
            uxConnectionSerialPortTest.Text = "Brak połączenie z portem COM";
            uxConnectionSerialPortTest.ForeColor = Color.Red;
            uxConsoleLog.Nodes.Add("Rozłączenie z portem COM");
            uxConnectionSerialPort.Enabled = true;
            uxDisconnectSerialPort.Enabled = false;
            uxConnectionToGatewayGroup.Enabled = false;
        }
        #endregion
        
        #region ConnectionToGateway
        private void uxConnectionToGateway_Click(object sender, EventArgs e)
        {
            try
            {
                _modbusService.InitializeModbus(new ModbusConfiguration
                {
                    SerialPort = _serialPortService.SerialPort,
                    TimeOut = 300
                });
                _modbusService.TestConnection(new Slave
                {
                    Address = 1,
                    StartAddress = 0
                });
                uxConnectionGatewayTest.Text = String.Empty;
                uxConnectionGatewayTest.Text = String.Format("Połączenie z gateway OK");
                uxConsoleLog.Nodes.Add("Poprawne zestawienie połączenia z gateway");
                uxConnectionGatewayTest.ForeColor = Color.Green;
            }
            catch(Exception ex)
            {
                uxConsoleLog.Nodes.Add(ex.Message);
                uxConnectionGatewayTest.Text = String.Empty;
                uxConnectionGatewayTest.Text = String.Format("Nie udało nawiązać się połączenie z gateway");
                uxConsoleLog.Nodes.Add("Brak połączenie z gateway");
                uxConnectionGatewayTest.ForeColor = Color.Red;
            }
        }
        #endregion

        #region ConsoleLogGroupBox
        private void uxRefreshConsole_Click(object sender, EventArgs e)
        {
            uxConsoleLog.Nodes.Clear();
        }
        #endregion        

        private void uxGetAllRegistersValue_Click(object sender, EventArgs e)
        {
            var registers = _modbusService.GetAllRegisterForSelectedDevice(new Slave
            {
                Address = 1,
                StartAddress = 0,
            });
            var logBuilder = new StringBuilder();
            foreach (var register in registers)
            {
                logBuilder.Append(register.ToString() + " ");
            }
            uxConsoleLog.Nodes.Add(logBuilder.ToString());
        }

        private void uxActivityStateOfDevices_Click(object sender, EventArgs e)
        {
            try
            {
                var activityStatusOfDevices = _modbusService.GetActivityStatusOfDevices(new Slave
                {
                    Address = 1,
                    StartAddress = 0,
                });

                foreach (var device in activityStatusOfDevices)
                {
                    var tmpWord = device.Value ? "jest" : "nie jest";
                    uxConsoleLog.Nodes.Add(String.Format("Urządzenie numer {0} {1} aktywne", device.Key, tmpWord));
                }
            }
            catch (Exception ex)
            {
                uxConsoleLog.Nodes.Add(ex.Message);
            }
        }

        private void uxGetEMValue_Click(object sender, EventArgs e)
        {
            var fieldValue = _modbusService.GetElectromagneticFieldValue(new Slave
            {
                Address = 1,
                StartAddress = 0,
                DeviceNumber = 11
            });
            uxConsoleLog.Nodes.Add(fieldValue.ToString());

        }
    }
}
