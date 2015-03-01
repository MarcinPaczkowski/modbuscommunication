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

        internal void CompareSensorStateWithDb(Sensor sensor)
        {
            
        }

        internal bool CheckIfSensorIsActive(Sensor sensor, ModbusService modbusService)
        {
            return modbusService.CheckActivityStatusOfDevice(new Slave
            {
                DeviceNumber = (ushort)sensor.Id,
                SlaveId = (byte)sensor.GatewayId
            });
        }
    }
}
