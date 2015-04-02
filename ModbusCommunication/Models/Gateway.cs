using System.Collections.Generic;

namespace ModbusCommunication.Models
{
    public class Gateway
    {
        public int Id { get; set; }
        public int ZoneId { get; set; }
        public string ZoneName { get; set; }
        public int HardwareGatewayId { get; set; }
        public string SerialPort { get; set; }
        public bool IsAvailable { get; set; }
        public int SensorsInterval { get; set; }
        public int SensorsIntervalCounter { get; set; }
        public List<Sensor> Sensors { get; set; }
    }
}
