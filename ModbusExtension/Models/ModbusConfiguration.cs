using System.IO.Ports;

namespace ModbusExtension.Models
{
    public class ModbusConfiguration
    {
        public SerialPort SerialPort { get; set; }
        public int TimeOut { get; set; }
    }
}
