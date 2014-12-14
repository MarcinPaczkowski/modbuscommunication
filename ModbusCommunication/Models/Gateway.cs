using System.Collections.Generic;

namespace ModbusCommunication.Models
{
    public class Gateway
    {
        public int ZoneId { get; set; }
        public string ZoneName { get; set; }
        public int GatewayId { get; set; }
        public string SerialPort { get; set; }
        public bool IsAvailable { get; set; }
        public List<Sensor> Sensors { get; set; }
    }
}
