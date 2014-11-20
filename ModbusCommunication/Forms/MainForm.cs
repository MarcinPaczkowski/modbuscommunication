using ModbusCommunication.Services;
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
        public MainForm()
        {
            InitializeComponent();
            InitializeCommonObjects();
        }

        private void InitializeCommonObjects()
        {
            _serialPortService = new SerialPortService();
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
                    uxConnectionTest.Text = String.Empty;
                    uxConnectionTest.Text = String.Format("Połączenie z portem {0}", uxAvailableSerialPorts.SelectedItem.ToString());
                    uxConsoleLog.Nodes.Add(String.Format("Połączenie z portem {0}", uxAvailableSerialPorts.SelectedItem.ToString()));
                    uxConnectionTest.ForeColor = Color.Green;
                    uxComConnect.Enabled = false;
                    uxComDisconnect.Enabled = true;
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
            uxConnectionTest.Text = String.Empty;
            uxConnectionTest.Text = "Brak połączenie z portem COM";
            uxConnectionTest.ForeColor = Color.Red;
            uxConsoleLog.Nodes.Add("Rozłączenie z portem COM");
            uxComConnect.Enabled = true;
            uxComDisconnect.Enabled = false;
        }
        #endregion

        #region ConsoleLogGroupBox
        private void uxRefreshConsole_Click(object sender, EventArgs e)
        {
            uxConsoleLog.Nodes.Clear();
        }
        #endregion
    }
}
