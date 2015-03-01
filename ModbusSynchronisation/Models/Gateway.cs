using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.SqlServer.Server;

namespace ModbusSynchronisation.Models
{
    public class Gateway
    {
        public int ZoneId { get; set; }
        public string ZoneName { get; set; }
        public int GatewayId { get; set; }
        public string SerialPort { get; set; }
        public bool IsAvailable { get; set; }
        public List<Sensor> Sensors { get; set; }

        public override string ToString()
        {
            return String.Format("{0}, Id = {1}", ZoneName, GatewayId);
        }
    }
}
