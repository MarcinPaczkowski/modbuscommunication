using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusCommon.Models
{
    public class SerialPortToken
    {
        private static readonly SerialPortToken _instance = new SerialPortToken();

        private readonly SerialPort _serialPort;

        static SerialPortToken()
        {
        }

        private SerialPortToken()
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

        public static SerialPortToken Instance
        {
            get
            {
                return _instance;
            }
        }

        public SerialPort GetSerialPort()
        {
            return _serialPort;
        }

        public List<string> GetAvailableSerialPorts()
        {
            return SerialPort.GetPortNames().ToList();
        }

        public void ConnectToSerialPort(string serialPortName)
        {
            _serialPort.Close();
            _serialPort.PortName = serialPortName;
            _serialPort.Open();
        }

        public void DisconnectSerialPort()
        {
            _serialPort.Close();
        }
    }
}
