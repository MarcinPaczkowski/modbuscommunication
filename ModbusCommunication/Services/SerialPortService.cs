using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;

namespace ModbusSensorOperation.Services
{
    internal class SerialPortService
    {
        internal SerialPort SerialPort { get; set; }

        internal SerialPortService()
        {
            SerialPort = new SerialPort();
            InitializeSerialPort();
        }

        private void InitializeSerialPort()
        {
            SerialPort.BaudRate = 19200;
            SerialPort.DataBits = 8;
            SerialPort.Parity = Parity.None;
            SerialPort.StopBits = StopBits.One;
        }

        internal List<string> GetAvailableSerialPorts()
        {
            return SerialPort.GetPortNames().ToList();
        }

        internal void ConnectToSerialPort(string serialPortName)
        {
            SerialPort.Close();
            SerialPort.PortName = serialPortName;
            SerialPort.Open();
        }

        internal void DisconnectSerialPort()
        {
            SerialPort.Close();
        }
    }
}
