using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModbusCommunication.Models;
using ModbusCommunication.Repositories;
using ModbusExtension.Models;
using ModbusExtension.Services;

namespace ModbusCommunication.Services
{
    internal class SensorService
    {
        readonly SensorRepository _sensorRepository = new SensorRepository();

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
    }
}
