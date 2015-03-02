using System;
using ModbusCommon.Models;
using ModbusExtension.Services;
using ModbusSynchronisation.Models;
using ModbusExtension.Models;
using System.Collections.Generic;

namespace ModbusSynchronisation.Services
{
    internal class SynchroniseService
    {
        private readonly ModbusService _modbusService;

        internal SynchroniseService()
        {
            _modbusService = new ModbusService();
        }

        internal void SynchroniseSensor(Sensor sensor, string serialPort)
        {
            try
            {
                SerialPortToken.Instance.ConnectToSerialPort(serialPort);
                InitializeModbus();

                var isActive = _modbusService.CheckActivityStatusOfDevice(new Slave
                {
                    DeviceNumber = (ushort) sensor.Id,
                    SlaveId = (byte) sensor.GatewayId
                });

                if (!isActive)
                    throw new Exception("Wybrany czujnik jest niedostępny.");

                _modbusService.SendControlMessage(new Slave
                {
                    DeviceNumber = (ushort) sensor.Id,
                    SlaveId = (byte) sensor.GatewayId
                });
            }
            finally
            {
                SerialPortToken.Instance.DisconnectSerialPort();
            }
        }

        internal List<ushort> GetAllSensorRegisters(Sensor sensor, string serialPort)
        {
            try
            {
                SerialPortToken.Instance.ConnectToSerialPort(serialPort);
                InitializeModbus();

                return _modbusService.GetAllRegisterForSelectedDevice(new Slave
                {
                    DeviceNumber = (ushort)sensor.Id,
                    SlaveId = (byte)sensor.GatewayId
                });
            }
            finally
            {
                SerialPortToken.Instance.DisconnectSerialPort();
            }
        }

        internal List<ushort> GetAllGatewayRegisters(Gateway gateway)
        {
            try
            {
                SerialPortToken.Instance.ConnectToSerialPort(gateway.SerialPort);
                InitializeModbus();

                return _modbusService.GetAllRegisterForSelectedDevice(new Slave
                {
                    DeviceNumber = 0,
                    SlaveId = (byte)gateway.GatewayId
                });
            }
            finally
            {
                SerialPortToken.Instance.DisconnectSerialPort();
            }
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
