using System.Windows.Forms;
using ModbusCommunication.Models;
using System.Collections.Generic;
using System.Linq;

namespace ModbusCommunication.Services
{
    internal class SerialPortBackgroundWorkerService
    {
        private readonly GatewayService _gatewayService;
        private readonly ListBox _serialPortList;
        private readonly ListBox _serialPortStatus;

        internal SerialPortBackgroundWorkerService(ListBox uxSerialPortList, ListBox uxSerialPortStatus)
        {
            _gatewayService = new GatewayService();
            _serialPortList = uxSerialPortList;
            _serialPortStatus = uxSerialPortStatus;
        }

        internal List<Gateway> GetGateways()
        {
            return _gatewayService.GetGateways();
        }

        internal void ReloadListBoxes(List<Gateway> gateways)
        {
            ReloadSerialPortList(gateways);
            ReloadSerialPortStatuses(gateways);
        }

        private void ReloadSerialPortList(IEnumerable<Gateway> gateways)
        {
            _serialPortList.Items.Clear();
            var serialPorts = gateways.Select(g => g.SerialPort).ToList();
            foreach (var serialPort in serialPorts)
                _serialPortList.Items.Add(serialPort);
        }

        private void ReloadSerialPortStatuses(IEnumerable<Gateway> gateways)
        {
            _serialPortStatus.Items.Clear();
            var activeSerialPorts = gateways.Select(g => g.IsAvailable).ToList();
            foreach (var status in activeSerialPorts.Select(serialPortStatus => serialPortStatus ? "Aktywny" : "Nieaktywny"))
                _serialPortStatus.Items.Add(status);
        }
    }
}
