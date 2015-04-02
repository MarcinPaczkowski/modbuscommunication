using System;
using System.Collections.Generic;

namespace ModbusSynchronisation.Models
{
    public class Gateway
    {
        public int Id { get; set; }
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
