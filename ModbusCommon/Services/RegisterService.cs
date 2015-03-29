using System;
using Microsoft.Win32;

namespace ModbusCommon.Services
{
    public class RegisterService
    {
        const string Path = @"HKEY_CURRENT_USER\Software\Cat";

        public void SetValue(string valueName, object value)
        {
            Registry.SetValue(Path, valueName, value);
        }

        public object GetValue(string valueName)
        {
            return Registry.GetValue(Path, valueName, null);
        }

        public DateTime UnixTimestampToDateTime(double unixTime)
        {
            var unixStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            var unixTimeStampInTicks = (long)(unixTime * TimeSpan.TicksPerSecond);
            return new DateTime(unixStart.Ticks + unixTimeStampInTicks);
        }

        public double DateTimeToUnixTimestamp(DateTime dateTime)
        {
            var unixStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            var unixTimeStampInTicks = (dateTime.ToLocalTime() - unixStart).Ticks;
            return (double)unixTimeStampInTicks / TimeSpan.TicksPerSecond;
        }
    }
}
