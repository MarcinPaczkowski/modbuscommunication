using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using ModbusExtension.Models;
using ModbusExtension.Services;
using ModbusTest.Services;
using ModbusTest.Utils;

namespace ModbusTest.Forms
{
    public partial class MainForm : Form
    {
        private readonly ModbusService _modbusService;
        private readonly SerialPortService _serialPortService;
        private readonly List<string> _enableNodes;

        public MainForm()
        {
            InitializeComponent();
            _modbusService = new ModbusService();
            _serialPortService = new SerialPortService();

            Configuration.Instance.LoadConfiguration("configuration.xml");
            _enableNodes = GetEnableNodes();
            var frequencySensorsReading = GetFrequencySensorReading();
            uxCheckStatusTimer.Interval = Convert.ToInt32(frequencySensorsReading);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RefreshAvailableSerialPort();
        }

        private static List<string> GetEnableNodes()
        {
            var nodes = Configuration.Instance.GetValue("Nodes");
            var tmpNodes = nodes.Trim();
            return tmpNodes.Split(',').ToList();
        }

        private static string GetFrequencySensorReading()
        {
            return Configuration.Instance.GetValue("FrequencySensorsReading");
        }

        private void RefreshAvailableSerialPort()
        {
            try
            {
                uxAvaibleSerialPorts.Items.Clear();
                var availableSerialPorts = _serialPortService.GetAvailableSerialPorts();
                if (availableSerialPorts.Count <= 0)
                    return;
                foreach (var serialport in availableSerialPorts)
                    uxAvaibleSerialPorts.Items.Add(serialport);
            }
            catch (Exception ex)
            {
                uxConsole.Nodes.Add(ex.Message).EnsureVisible();
            }
        }

        private void uxRefreshAvailableSerialPorts_Click(object sender, EventArgs e)
        {
            RefreshAvailableSerialPort();
        }

        private void uxOpenConnection_Click(object sender, EventArgs e)
        {
            try
            {
                if (uxAvaibleSerialPorts.SelectedItem != null)
                {
                    var selectedPortCom = uxAvaibleSerialPorts.SelectedItem.ToString();
                    _serialPortService.ConnectToSerialPort(selectedPortCom);

                    _modbusService.InitializeModbusRtu(new ModbusConfiguration
                    {
                        SerialPort = _serialPortService.SerialPort,
                        TimeOut = 300
                    });

                    Text = selectedPortCom;

                    uxConsole.Nodes.Add(String.Format("Zestawiono połączenie z portem: {0}", selectedPortCom),
                                                    @"Poprawne zestawienie połączenia").EnsureVisible();
                }
                else
                    throw new Exception("Wybierz port COM.");
            }
            catch (Exception ex)
            {
                uxConsole.Nodes.Add(ex.Message).EnsureVisible();
            }
        }

        private void uxCloseConnection_Click(object sender, EventArgs e)
        {
            Text = String.Empty;
            _serialPortService.DisconnectSerialPort();
            uxConsole.Nodes.Add("Rozłączono połączenie.").EnsureVisible();
        }

        private void uxTestConnection_Click(object sender, EventArgs e)
        {
            try
            {
                _modbusService.TestConnection(new Slave
                {
                    DeviceNumber = 0,
                    SlaveId = 1
                });
                uxConsole.Nodes.Add(@"Uzyskano dostęp do gateway.");
            }
            catch (Exception ex)
            {
                uxConsole.Nodes.Add(ex.Message).EnsureVisible();
            }
        }

        private void uxGetRegisterValues_Click(object sender, EventArgs e)
        {
            try
            {
                var gatewayRegisters = _modbusService.GetAllRegisterForSelectedDevice(new Slave
                {
                    DeviceNumber = 0,
                    SlaveId = 1
                });

                var rootNode = uxConsole.Nodes.Add("Wartości rejestrów Gateway'a");

                foreach (var gateway in gatewayRegisters)
                    rootNode.Nodes.Add(gateway.ToString(CultureInfo.InvariantCulture)).EnsureVisible();

                foreach (var node in _enableNodes)
                {
                    var deviceNumber = (ushort)Convert.ToInt32(node);
                    var node1Registers = _modbusService.GetAllRegisterForSelectedDevice(new Slave
                    {
                        DeviceNumber = deviceNumber,
                        SlaveId = 1
                    });

                    var treeNode = uxConsole.Nodes.Add(String.Format("Wartości rejestrów Node{0}", node));
                    foreach (var node1Register in node1Registers)
                        treeNode.Nodes.Add(node1Register.ToString(CultureInfo.InvariantCulture)).EnsureVisible();
                }
            }
            catch (Exception ex)
            {
                uxConsole.Nodes.Add(ex.Message).EnsureVisible();
            }
        }

        private void uxGetEMValue_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var node in _enableNodes)
                {
                    var deviceNumber = (ushort)Convert.ToInt32(node);
                    var fieldValue = _modbusService.GetElectromagneticFieldValue(new Slave
                    {
                        DeviceNumber = deviceNumber,
                        SlaveId = 1
                    });

                    uxConsole.Nodes.Add(String.Format("Wartości 1 rejestru dla Node{0}", node)).
                        Nodes.Add(fieldValue.ToString(CultureInfo.InvariantCulture)).EnsureVisible();

                    var lsb = fieldValue & 1;
                    uxConsole.Nodes.Add(String.Format("Wartość najmniej znaczącego bitu w rejestrze 1 dla Node{0}", node)).
                        Nodes.Add(lsb.ToString(CultureInfo.InvariantCulture)).EnsureVisible();
                }
            }
            catch (Exception ex)
            {
                uxConsole.Nodes.Add(ex.Message).EnsureVisible();
            }
        }

        private void uxCalibration_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var node in _enableNodes)
                {
                    var deviceNumber = (ushort)Convert.ToInt32(node);
                    _modbusService.SendControlMessage(new Slave
                    {
                        DeviceNumber = deviceNumber,
                        SlaveId = 1
                    });
                    uxConsole.Nodes.Add(String.Format("Node{0} skalibrowany", node)).EnsureVisible();
                }
            }
            catch (Exception ex)
            {
                uxConsole.Nodes.Add(ex.Message).EnsureVisible();
            }
        }

        private void uxConsoleClear_Click(object sender, EventArgs e)
        {
            uxConsole.Nodes.Clear();
        }

        private void uxGet6601Register_Click(object sender, EventArgs e)
        {
            try
            {
                var register = _modbusService.GetRegister(new Slave
                {
                    DeviceNumber = 0,
                    SlaveId = 1
                }, (ushort)uxRegisterNumber.Value);

                var rootNode = uxConsole.Nodes.Add(String.Format("Wartości rejestru {0}", uxRegisterNumber.Value.ToString(CultureInfo.InvariantCulture)));
                var mask = 1;
                for (var i = 0; i < 16; i++)
                {
                    rootNode.Nodes.Add((register & mask) == mask ? "1" : "0").EnsureVisible();
                    mask <<= 1;
                }
            }
            catch (Exception ex)
            {
                uxConsole.Nodes.Add(ex.Message).EnsureVisible();
            }
        }

        private void uxStartCheckStatuses_Click(object sender, EventArgs e)
        {
            uxCheckStatusTimer.Start();
        }

        private void uxStopCheckStatuses_Click(object sender, EventArgs e)
        {
            uxCheckStatusTimer.Stop();
        }

        private void uxCheckStatusTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                foreach (var node in _enableNodes)
                {
                    var deviceNumber = (ushort)Convert.ToInt32(node);
                    var isBusy = _modbusService.GetSensorStatus(new Slave
                    {
                        DeviceNumber = deviceNumber,
                        SlaveId = 1
                    });
                    var response = isBusy ? "ZAJĘTY" : "WOLNY";
                    uxConsole.Nodes.Add(String.Format("Czujnik nr {0} jest {1}", node, response));
                }
            }
            catch (Exception ex)
            {
                uxConsole.Nodes.Add(ex.Message).EnsureVisible();
            }
        }
    }
}
