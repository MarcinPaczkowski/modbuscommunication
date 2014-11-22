using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusExtension.Enums
{
    public enum ReportRate
    {
        NoChange = 0,
        OnChangeOfState = 1,
        Seconds16 = 2,
        SampleRate = 3
    }
}
