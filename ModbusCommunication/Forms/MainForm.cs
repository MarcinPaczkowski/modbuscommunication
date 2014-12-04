using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ModbusSensorOperation.Models;
using ModbusSensorOperation.Services;

namespace ModbusCommunication.Forms
{
    public partial class MainForm : Form
    {
        private GatewayService _gatewayService;
        private List<Gateway> _gateways;

        public MainForm()
        {
            InitializeComponent();
            InitializeCommonObjects();
        }

        private void InitializeCommonObjects()
        {
            _gatewayService = new GatewayService();
            _gateways = new List<Gateway>();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                _gateways = _gatewayService.GetGateways();
                ReloadSerialPortList();
                ReloadSerialPortStatuses();
            }
            catch (Exception ex)
            {
                uxConsoleLog.Nodes.Add(ex.Message);
            }
            
        }

        private void ReloadSerialPortList()
        {
            var serialPorts = _gateways.Select(g => g.SerialPort).ToList();
            foreach (var serialPort in serialPorts)
                uxSerialPortList.Items.Add(serialPort);
        }
        
        private void ReloadSerialPortStatuses()
        {
            var activeSerialPorts = _gateways.Select(g => g.ConnectionStatus).ToList();
            foreach (var serialPortStatus in activeSerialPorts.Select(GetSerialPortStatusDescription))
            {
                uxSerialPortStatus.Items.Add(serialPortStatus);
            }
        }

        private static string GetSerialPortStatusDescription(int activeSerialPort)
        {
            var serialPortStatus = "";
            switch (activeSerialPort)
            {
                case 0:
                    serialPortStatus = "Nieaktywny";
                    break;
                case 1:
                    serialPortStatus = "Aktywny";
                    break;
                case 2:
                    serialPortStatus = "Nieaktywny od 24h";
                    break;
            }
            return serialPortStatus;
        }

        private void uxStart_Click(object sender, EventArgs e)
        {
            
        }
    }
}
