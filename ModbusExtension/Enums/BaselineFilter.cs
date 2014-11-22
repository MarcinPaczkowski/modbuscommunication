using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusExtension.Enums
{
    public enum BaselineFilter
    {
        NoChange = 0,
        FilterOff = 1,
        FilterTreshold30And2Hour = 2,
        FilterTreshold30And8Hour = 3
    }
}
