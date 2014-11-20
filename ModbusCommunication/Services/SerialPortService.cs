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

        internal string[] GetAvailableSerialPorts()
        {
            return SerialPort.GetPortNames();
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
