using System;
using ModbusCommunication.Models;
using ModbusExtension.Models;
using ModbusExtension.Services;

namespace ModbusCommunication.Services
{
    internal class SensorService
    {
        internal Sensor GetSensorStatus(Sensor sensor, ModbusService modbusService)
        {
            var status = modbusService.GetSensorStatus(new Slave
            {
                DeviceNumber = (ushort) sensor.Id,
                SlaveId = (byte) sensor.GatewayId,
            });

            sensor.Status = status ? 1 : 0;
            return sensor;
        }

        internal bool CheckIfSensorIsActive(Sensor sensor, ModbusService modbusService)
        {
            return modbusService.CheckActivityStatusOfDevice(new Slave
            {
                DeviceNumber = (ushort)sensor.Id,
                SlaveId = (byte)sensor.GatewayId
            });
        }

        internal string GetFirstAndEightRegisters(Sensor sensor, ModbusService modbusService)
        {
            var registers = modbusService.GetAllRegisterForSelectedDevice(new Slave
            {
                DeviceNumber = (ushort)sensor.Id,
                SlaveId = (byte)sensor.GatewayId
            });
            return String.Format("Rejestr 1 - {0}, rejestr 8 - {1}", registers[0], registers[7]);
        }
    }
}
