using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusCommunication.Services
{
    internal class SerialPortService
    {
        SerialPort _serialPort;

        internal SerialPortService()
        {
            _serialPort = new SerialPort();
            InitializeSerialPort();
        }

        private void InitializeSerialPort()
        {
            _serialPort.BaudRate = 19200;
            _serialPort.DataBits = 8;
            _serialPort.Parity = Parity.None;
            _serialPort.StopBits = StopBits.One;
        }

        internal string[] GetAvailableSerialPorts()
        {
            return SerialPort.GetPortNames();
        }

        internal void ConnectToSerialPort(string serialPortName)
        {
            _serialPort.Close();
            _serialPort.PortName = serialPortName;
            _serialPort.Open();
        }

        internal void DisconnectSerialPort()
        {
            _serialPort.Close();
        }
    }
}
