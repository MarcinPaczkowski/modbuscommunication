﻿namespace ModbusCommunication.Models
{
    public class Sensor
    {
        public int Id { get; set; }
        public int GatewayId { get; set; }
        public int Status { get; set; }
        public bool IsOffline { get; set; }
        public int ConnectionError { get; set; }
        public int ConnectionErrorCounter { get; set; }

        public override string ToString()
        {
            return string.Format("Gateway {0} Sensor {1} Status {2}", GatewayId, Id, Status);
        }
    }
}
