using System;
using ModbusCommon.Models;
using ModbusExtension.Services;
using ModbusSynchronisation.Models;
using ModbusExtension.Models;

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

        internal ushort GetElectroMagneticFieldValue(Sensor sensor, string serialPort)
        {
            try
            {
                SerialPortToken.Instance.ConnectToSerialPort(serialPort);
                InitializeModbus();

                return _modbusService.GetElectromagneticFieldValue(new Slave
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
