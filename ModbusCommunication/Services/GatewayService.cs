using System.Collections.Generic;
using System.Linq;
using ModbusSensorOperation.Models;
using ModbusSensorOperation.Repositories;

namespace ModbusSensorOperation.Services
{
    internal class GatewayService
    {
        private readonly GatewayRepository _gatewayRepository;
        private readonly SerialPortService _serialPortService;

        internal GatewayService()
        {
            _gatewayRepository = new GatewayRepository();
            _serialPortService = new SerialPortService();
        }

        internal List<Gateway> GetGateways()
        {
            var gateways = _gatewayRepository.SelectGateways();
            gateways = GetAvailabilityGateways(gateways);
            return gateways;
        }

        private List<Gateway> GetAvailabilityGateways(List<Gateway> gateways)
        {
            var availableSerialPorts = _serialPortService.GetAvailableSerialPorts();

            foreach (var gateway in gateways)
            {
                gateway.ConnectionStatus = availableSerialPorts.Any(p => p.Equals(gateway.SerialPort)) ? 1 : 0;
            }
            return gateways;
        }
    }
}
