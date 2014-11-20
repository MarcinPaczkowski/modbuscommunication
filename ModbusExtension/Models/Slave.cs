using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusExtension.Models
{
    public class Slave
    {
        public byte Address { get; set; }
        public ushort StartAddress { get; set; }
        public ushort DeviceNumber { get; set; }
    }
}
