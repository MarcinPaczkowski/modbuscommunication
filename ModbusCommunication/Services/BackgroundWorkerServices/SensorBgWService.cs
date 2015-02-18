using System;
using System.ComponentModel;
using ModbusCommunication.Models;
using ModbusCommunication.Repositories;
using ModbusCommunication.Utils;
using ModbusExtension.Models;
using ModbusExtension.Services;

namespace ModbusCommunication.Services.BackgroundWorkerServices
{
    internal class SensorBgWService
    {
        private readonly BackgroundWorker _sensorWorker;
        private readonly SensorService _sensorService;
        private readonly SensorRepository _sensorRepository;
        private readonly ModbusService _modbusService;
        private readonly SerialPortService _serialPortService;

        private Gateway _gateway;
        private string _serialPort;

        internal SensorBgWService()
        {
            _sensorWorker = new BackgroundWorker();
            _sensorService = new SensorService();
            _sensorRepository = new SensorRepository();
            _modbusService = new ModbusService();
            _serialPortService = new SerialPortService();
            
            _sensorWorker.DoWork += _sensorWorker_DoWork;
            _sensorWorker.ProgressChanged += _sensorWorker_ProgressChanged;
            _sensorWorker.RunWorkerCompleted += _sensorWorker_RunWorkerCompleted;

            _sensorWorker.WorkerReportsProgress = true;
        }
        internal void GetSensorStatusAndUpdateOnDb(Gateway gateway, string serialPort)
        {
            _gateway = gateway;
            _serialPort = serialPort;
            _sensorWorker.RunWorkerAsync();
        }

        private void _sensorWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            _serialPortService.ConnectToSerialPort(_serialPort);
            InitializeModbus();

            for (var i = 0; i < _gateway.Sensors.Count; i++)
            {
                try
                {
                    _gateway.Sensors[i] = _sensorService.GetSensorStatus(_gateway.Sensors[i], _modbusService);
                    var previousStatus = _sensorRepository.SelectPreviousSensorStatus(_gateway.Sensors[i], _gateway.ZoneId);

                    if (_gateway.Sensors[i].Status == previousStatus)
                        continue;

                    _sensorRepository.UpdateSensorStatus(_gateway.Sensors[i], _gateway.ZoneId);

                    var message = GetMessage(i);

                    _sensorWorker.ReportProgress(i, message);
                }
                catch (Exception ex)
                {
                    ConsoleHelper.AddMessage(ex.Message);
                }
            }

            _serialPortService.DisconnectSerialPort();
        }

        private static void _sensorWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var message = e.UserState.ToString();
            ConsoleHelper.AddMessage(message);
        }

        private void _sensorWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }

        private void InitializeModbus()
        {
            _modbusService.InitializeModbusRtu(new ModbusConfiguration
            {
                SerialPort = _serialPortService.SerialPort,
                TimeOut = 300
            });
        }

        private string GetMessage(int index)
        {
            var message = _gateway.Sensors[index].Status == 1
                ? String.Format("Gateway {0}, czujnik {1} - ZAJĘTY", _gateway.Sensors[index].GatewayId, _gateway.Sensors[index].Id)
                : String.Format("Gateway {0}, czujnik {1} - WOLNY", _gateway.Sensors[index].GatewayId, _gateway.Sensors[index].Id);
            return message;
        }
    }
}
