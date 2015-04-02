using System;

namespace ModbusCommunication.Models
{
    public class Sensor
    {
        public int Id { get; set; }
        public int GatewayId { get; set; }
        public int Status { get; set; }
        public bool IsOffline { get; set; }

        public override string ToString()
        {
            return String.Format("Gateway {0} Sensor {1} Status {2}", GatewayId, Id, Status);
        }
    }
}
