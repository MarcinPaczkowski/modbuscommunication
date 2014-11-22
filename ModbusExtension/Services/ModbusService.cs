﻿using Modbus.Device;
using ModbusExtension.Models;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusExtension.Services
{    
    public class ModbusService
    {
        ModbusSerialMaster _modbusSerial;

        public void InitializeModbusRtu(ModbusConfiguration modbusConfiguration)
        {
            _modbusSerial = ModbusSerialMaster.CreateRtu(modbusConfiguration.SerialPort);
            _modbusSerial.Transport.ReadTimeout = modbusConfiguration.TimeOut;
        }

        #region METHOD_TO_READ_MODBUS

        public void TestConnection(Slave slave)
        {
            var startAddress = GetStartAddress(slave.DeviceNumber);
            _modbusSerial.ReadHoldingRegisters(slave.SlaveId, startAddress, 1);  
        }

        public List<ushort> GetAllRegisterForSelectedDevice(Slave slave)
        {
            var startAddress = GetStartAddress(slave.DeviceNumber);
            return _modbusSerial.ReadHoldingRegisters(slave.SlaveId, startAddress, 16).ToList();
        }

        public ushort GetElectromagneticFieldValue(Slave slave)
        {
            var startAddress = GetStartAddress(slave.DeviceNumber);
            var registers = _modbusSerial.ReadHoldingRegisters(slave.SlaveId, startAddress, 1);
            return registers[0];
        }

        public bool CheckStateOfSensor(Slave slave)
        {
            var startAddress = GetStartAddress(slave.DeviceNumber);
            var registers = _modbusSerial.ReadHoldingRegisters(slave.SlaveId, startAddress, 16);
            return (registers[0] & 1) == 1;
        }        

        public Dictionary<int, bool> GetActivityStatusOfDevices(Slave slave)
        {
            var registers = _modbusSerial.ReadHoldingRegisters(slave.SlaveId, 6600, 3);
            var deviceCounter = 0;
            var deviceStatusDictionary = new Dictionary<int, bool>();
            foreach (var register in registers)
            {
                var mask = 1;
                for (int i = 0; i < 16; i++)
                {
                    var isActive = (register & mask) == mask;
                    deviceStatusDictionary.Add(deviceCounter, isActive);
                    deviceCounter++;
                    mask <<= 1;
                }
            }
            return deviceStatusDictionary;
        }

        public bool CheckActivityStatusOfDevice(Slave slave)
        {
            var startAddress = GetStartAddress(slave.DeviceNumber, 7);
            var register = _modbusSerial.ReadHoldingRegisters(slave.SlaveId, startAddress, 1).First();
            return register == 128;
        }        

        #endregion

        #region METHOD_TO_WRITE_TO_MODBUS

        public void SendConfigurationMessage(Slave slave, ConfigurationMessage configurationMessage)
        {
            var startAddress = GetStartAddress(slave.DeviceNumber, 12);
            var valueConfigurationMessage = GetValueToConfigurationMessage(configurationMessage);
            _modbusSerial.WriteSingleRegister(slave.SlaveId, startAddress, valueConfigurationMessage);
        }

        public void SendControlMessage(Slave slave)
        {
            var startAddress = GetStartAddress(slave.DeviceNumber, 14);
            var value = (ushort)4096;
            _modbusSerial.WriteSingleRegister(slave.SlaveId, startAddress, value);
        }

        private ushort GetValueToConfigurationMessage(ConfigurationMessage configurationMessage)
        {
            ushort value = 0;
            value += (ushort)configurationMessage.TresholdAndHysteresis; ;
            value += (ushort)(configurationMessage.BaselineFilter << 3);
            value += (ushort)(configurationMessage.SampleRate << 5);
            value += (ushort)(configurationMessage.ReportRate << 8);
            value += (ushort)(configurationMessage.SampleCounter << 10);
            value += (ushort)(configurationMessage.LowPassFilter << 13);
            return value;
        }
        #endregion

        private ushort GetStartAddress(ushort deviceNumber, int offset = 0)
        {
            return (ushort)(deviceNumber * 16 + offset);
        }
    }
}
