using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusExtension.Models
{
    public class ModbusConfiguration
    {
        public SerialPort SerialPort { get; set; }
        public int TimeOut { get; set; }
    }
}
