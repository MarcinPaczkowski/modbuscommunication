using System;
using ModbusCommon.Models;
using ModbusExtension.Services;
using ModbusSynchronisation.Models;
using ModbusExtension.Models;
using System.Collections.Generic;
using ModbusCommon.Utils;
using ModbusExtension.Enums;

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

                var activeMode = GetActiveMode();

                var isActive = _modbusService.CheckActivityStatusOfDevice(new Slave
                {
                    DeviceNumber = (ushort) sensor.Id,
                    SlaveId = (byte) sensor.GatewayId
                }, activeMode);

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

        private static ActiveMode GetActiveMode()
        {
            var activeModeString = Configuration.Instance.GetValue("ActiveSensorMode");

            if (activeModeString.ToUpper().Equals("EQUAL"))
                return ActiveMode.Equal;
            if (activeModeString.ToUpper().Equals("EQUALORGREATER"))
                return ActiveMode.EqualOrGreater;
            return ActiveMode.Greater;
        }
    }
}
