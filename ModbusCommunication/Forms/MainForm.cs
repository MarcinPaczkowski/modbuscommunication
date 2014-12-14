using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using ModbusCommunication.Models;
using ModbusCommunication.Services;

namespace ModbusCommunication.Forms
{
    public partial class MainForm : Form
    {
        private SerialPortBackgroundWorkerService _serialPortBackgroundWorkerService;

        public MainForm()
        {
            InitializeComponent();
            InitializeCommonObjects();
        }

        private void InitializeCommonObjects()
        {
            _serialPortBackgroundWorkerService = new SerialPortBackgroundWorkerService(uxSerialPortList, uxSerialPortStatus);
            uxSerialPortTimer.Start();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                var gateways = _serialPortBackgroundWorkerService.GetGateways();
                _serialPortBackgroundWorkerService.ReloadListBoxes(gateways);
            }
            catch (Exception ex)
            {
                uxConsoleLog.Nodes.Add(ex.Message);
            }
        }

        #region GetAvailableSerialPorts

        private void uxSerialPortTimer_Tick(object sender, EventArgs e)
        {
            uxAvailableGatewayBackgroundWorker.RunWorkerAsync();
        }

        private void uxAvailableGatewayBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var gateways = _serialPortBackgroundWorkerService.GetGateways();
                uxAvailableGatewayBackgroundWorker.ReportProgress(100, gateways);
            }
            catch (Exception ex)
            {
                uxAvailableGatewayBackgroundWorker.ReportProgress(0, ex.Message);
            }
        }

        private void uxAvailableGatewayBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 100)
            {
                var gateways = (List<Gateway>)(e.UserState);
                _serialPortBackgroundWorkerService.ReloadListBoxes(gateways);
            }
            else
            {
                uxConsoleLog.Nodes.Add(e.UserState.ToString());
            }
        }

        #endregion

        #region Get/SetGatewaysAndSensors
        private void uxGatewayOperationTimer_Tick(object sender, EventArgs e)
        {

        }

        #endregion

        private void uxRefreshConsole_Click(object sender, EventArgs e)
        {
            uxConsoleLog.Nodes.Clear();
        }

        private void uxStart_Click(object sender, EventArgs e)
        {

        }

        

        

        
    }
}
