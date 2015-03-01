using System;
using System.Collections.Generic;
using System.Linq;
using ModbusCommon.Models;
using ModbusCommunication.Models;
using ModbusCommunication.Repositories;
using ModbusExtension.Models;
using ModbusExtension.Services;

namespace ModbusCommunication.Services
{
    internal class GatewayService
    {
        private readonly GatewayRepository _gatewayRepository;
        private readonly SensorRepository _sensorRepository;
        private readonly ModbusService _modbusService;

        internal GatewayService()
        {
            _gatewayRepository = new GatewayRepository();
            _sensorRepository = new SensorRepository();
            _modbusService = new ModbusService();
        }

        internal List<Gateway> GetGateways()
        {
            var gateways = _gatewayRepository.SelectGateways();
            gateways = GetAvailableGateways(gateways);
            foreach (var gateway in gateways)
                gateway.Sensors = _sensorRepository.SelectSensors(gateway);
            
            return gateways;
        }

        internal string GetResponse(Gateway gateway)
        {
            try
            {
                SerialPortToken.Instance.ConnectToSerialPort(gateway.SerialPort);
                InitializeModbus();

                var registers = _modbusService.GetAllRegisterForSelectedDevice(new Slave
                {
                    DeviceNumber = 0,
                    SlaveId = (byte) gateway.GatewayId
                });

                var response = String.Empty;

                foreach (var register in registers)
                    response += String.Format("{0};", register);

                return response;
            }
            finally
            {
                SerialPortToken.Instance.DisconnectSerialPort();
            }
        }

        private List<Gateway> GetAvailableGateways(List<Gateway> gateways)
        {
            var availableSerialPorts = SerialPortToken.Instance.GetAvailableSerialPorts();

            foreach (var gateway in gateways)
                gateway.IsAvailable = availableSerialPorts.Any(p => p.Equals(gateway.SerialPort));
            
            return gateways;
        }

        private void InitializeModbus()
        {
            _modbusService.InitializeModbusRtu(new ModbusConfiguration
            {
                SerialPort = SerialPortToken.Instance.GetSerialPort(),
                TimeOut = 300
            });
        }
    }
}
