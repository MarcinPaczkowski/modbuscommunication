using Modbus.Device;
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
        public ModbusSerialMaster ModbusSerial { get; set; }

        public void InitializeModbus(ModbusConfiguration modbusConfiguration)
        {
            ModbusSerial = ModbusSerialMaster.CreateRtu(modbusConfiguration.SerialPort);
            ModbusSerial.Transport.ReadTimeout = modbusConfiguration.TimeOut;
        }

        public void TestConnection(Slave slave)
        {
            ModbusSerial.ReadHoldingRegisters(slave.Address, slave.StartAddress, 1);  
        }

        public ushort[] GetAllRegisterForSelectedDevice(Slave slave)
        {
            return ModbusSerial.ReadHoldingRegisters(slave.Address, slave.StartAddress, 16);
        }

        public ushort GetElectromagneticFieldValue(Slave slave)
        {
            int startAddres = slave.DeviceNumber * 16;
            var registers = ModbusSerial.ReadHoldingRegisters(slave.Address, (ushort)startAddres, 1);
            return registers[0];
        }

        public bool CheckStateOfSensor(Slave slave)
        {
            var registers = ModbusSerial.ReadHoldingRegisters(slave.Address, slave.StartAddress, 16);
            return (registers[0] & 1) == 1;
        }

        public Dictionary<int, bool> GetActivityStatusOfDevices(Slave slave)
        {
            var registers = ModbusSerial.ReadHoldingRegisters(slave.Address, 6600, 3);
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
    }
}
