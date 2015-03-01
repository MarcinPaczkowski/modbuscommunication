using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using ModbusCommon.Models;
using ModbusSynchronisation.Models;
using ModbusSynchronisation.Services;

namespace ModbusSynchronisation.Forms
{
    public partial class MainForm : Form
    {
        private readonly GatewayService _gatewayService;
        private readonly SynchroniseService _synchroniseService;
        private List<Gateway> _gateways; 

        public MainForm()
        {
            InitializeComponent();
            _gatewayService = new GatewayService();
            _synchroniseService = new SynchroniseService();
            _gateways = new List<Gateway>();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                RefreshLists();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Błąd podczas pobierania danych z bazy danych", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void uxClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void uxRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                RefreshLists();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Błąd podczas pobierania danych z bazy danych", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void uxGateways_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lock (SerialPortToken.Instance)
                {
                    var selectedGateway = (Gateway)uxGateways.SelectedItem; uxSensors.Items.Clear();
                    uxSensors.Items.AddRange(selectedGateway.Sensors.ToArray());
                    if (uxSensors.Items.Count <= 0)
                        return;
                    uxSensors.SelectedIndex = 0;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Błąd programu", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void uxSynchronise_Click(object sender, EventArgs e)
        {
            try
            {
                if (uxGateways.SelectedItem == null)
                    throw new Exception("Nie wybrano żadnego gateway'a.");
                if (uxSensors.SelectedItem == null)
                    throw new Exception("Nie wybrano żadnego czujnika.");

                var selectedGateway = (Gateway)uxGateways.SelectedItem;
                var selectedSensor = (Sensor)uxSensors.SelectedItem;

                lock (SerialPortToken.Instance)
                {
                    _synchroniseService.SynchroniseSensor(selectedSensor, selectedGateway.SerialPort);

                    var electroMagneticFieldValue = _synchroniseService.GetElectroMagneticFieldValue(selectedSensor,
                    selectedGateway.SerialPort);

                    uxEMFieldValue.Text = electroMagneticFieldValue.ToString(CultureInfo.InvariantCulture);
                }

                MessageBox.Show(@"Czujnik został poprawnie zsynchronizowany.", @"Operacja zakończona sukcesem", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Błąd programu", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void uxSensors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (uxGateways.SelectedItem == null)
                throw new Exception("Nie wybrano żadnego gateway'a.");
            if (uxSensors.SelectedItem == null)
                throw new Exception("Nie wybrano żadnego czujnika.");

            var selectedGateway = (Gateway)uxGateways.SelectedItem;
            var selectedSensor = (Sensor)uxSensors.SelectedItem;

            lock (SerialPortToken.Instance)
            {
                var electroMagneticFieldValue = _synchroniseService.GetElectroMagneticFieldValue(selectedSensor,
                selectedGateway.SerialPort);
                uxEMFieldValue.Text = electroMagneticFieldValue.ToString(CultureInfo.InvariantCulture);
            }
        }

        private void RefreshLists()
        {
            lock (SerialPortToken.Instance)
            {
                _gateways = _gatewayService.GetGateways();
                uxGateways.Items.Clear();
                uxGateways.Items.AddRange(_gateways.Where(g => g.IsAvailable).ToArray());
                if (uxGateways.Items.Count <= 0)
                    return;
                uxGateways.SelectedIndex = 0;
            }
        }
    }
}
