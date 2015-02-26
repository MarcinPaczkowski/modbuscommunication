using System.Collections.Generic;
using System.Linq;
using ModbusCommunication.Models;
using ModbusCommunication.Repositories;

namespace ModbusCommunication.Services
{
    internal class GatewayService
    {
        private readonly GatewayRepository _gatewayRepository;
        private readonly SensorRepository _sensorRepository;
        private readonly SerialPortService _serialPortService;

        internal GatewayService()
        {
            _gatewayRepository = new GatewayRepository();
            _sensorRepository = new SensorRepository();
            _serialPortService = new SerialPortService();
        }

        internal List<Gateway> GetGateways()
        {
            var gateways = _gatewayRepository.SelectGateways();
            gateways = GetAvailableGateways(gateways);
            foreach (var gateway in gateways)
                gateway.Sensors = _sensorRepository.SelectSensors(gateway);
            
            return gateways;
        }

        private List<Gateway> GetAvailableGateways(List<Gateway> gateways)
        {
            var availableSerialPorts = _serialPortService.GetAvailableSerialPorts();

            foreach (var gateway in gateways)
                gateway.IsAvailable = availableSerialPorts.Any(p => p.Equals(gateway.SerialPort));
            
            return gateways;
        }
    }
}
