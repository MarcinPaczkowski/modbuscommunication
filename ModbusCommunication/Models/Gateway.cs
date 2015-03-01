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
        public int GatewayInterval { get; set; }
        public int GatewayIntervalCounter { get; set; }
        public int SensorInterval { get; set; }
        public int SensorIntervalCounter { get; set; }
        public List<Sensor> Sensors { get; set; }
    }
}
