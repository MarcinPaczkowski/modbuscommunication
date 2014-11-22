using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusExtension.Enums
{
    public enum SampleRate
    {
        NoChange = 0, 
        MiliSec62 = 1, 
        MiliSec125 = 2, 
        MiliSec250 = 3, 
        MiliSec500 = 4, 
        Sec1 = 5, 
        MiliSec31 = 6, 
        MiliSec20 = 7 
    }
}
