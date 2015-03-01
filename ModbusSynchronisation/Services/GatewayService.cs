using System.Collections.Generic;
using System.Linq;
using ModbusCommon.Models;
using ModbusSynchronisation.Models;
using ModbusSynchronisation.Repositories;

namespace ModbusSynchronisation.Services
{
    class GatewayService
    {
        private readonly GatewayRepository _gatewayRepository;
        private readonly SensorRepository _sensorRepository;

        internal GatewayService()
        {
            _gatewayRepository = new GatewayRepository();
            _sensorRepository = new SensorRepository();
        }

        internal List<Gateway> GetGateways()
        {
            lock (SerialPortToken.Instance)
            {
                var gateways = _gatewayRepository.SelectGateways();
                gateways = GetAvailableGateways(gateways);
                    foreach (var gateway in gateways)
                gateway.Sensors = _sensorRepository.SelectSensors(gateway);

            return gateways;
            }
        }

        private static List<Gateway> GetAvailableGateways(List<Gateway> gateways)
        {
            var availableSerialPorts = SerialPortToken.Instance.GetAvailableSerialPorts();

            foreach (var gateway in gateways)
                gateway.IsAvailable = availableSerialPorts.Any(p => p.Equals(gateway.SerialPort));

            return gateways;
        }
    }
}
