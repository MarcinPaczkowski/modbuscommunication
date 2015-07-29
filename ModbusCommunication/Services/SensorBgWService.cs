using ModbusCommon.Models;
using ModbusCommunication.Models;
using ModbusCommunication.Repositories;
using ModbusExtension.Models;
using ModbusExtension.Services;

namespace ModbusCommunication.Services
{
    internal class SensorBgWService
    {
        private readonly SensorService _sensorService;
        private readonly SensorRepository _sensorRepository;
        private readonly ModbusService _modbusService;

        internal SensorBgWService()
        {
            _sensorService = new SensorService();
            _sensorRepository = new SensorRepository();
            _modbusService = new ModbusService();
        }

        internal void InitializeConnection()
        {
            InitializeModbus();
        }

        internal bool IsSensorStatusChanged(Gateway gateway, Sensor sensor)
        {
            var isActive = _sensorService.CheckIfSensorIsActive(sensor, _modbusService);

            if (isActive)
            {
                sensor = _sensorService.GetSensorStatus(sensor, _modbusService);
                sensor.ConnectionErrorCounter = sensor.ConnectionError;
                sensor.IsOffline = false;
            }

            else
            {
                sensor.ConnectionErrorCounter--;
                if (sensor.ConnectionErrorCounter <= 0)
                    sensor.IsOffline = true;
            }

            var previousSensor = _sensorRepository.SelectPreviousSensorStatus(sensor, gateway);

            if ((sensor.Status == previousSensor.Status) && (sensor.IsOffline == previousSensor.IsOffline))
                return false;

            _sensorRepository.UpdateSensorStatus(sensor, gateway);
            return true;
        }

        internal string GetFirstAndEightRegister(Sensor sensor)
        {
            return _sensorService.GetFirstAndEightRegisters(sensor, _modbusService);
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
