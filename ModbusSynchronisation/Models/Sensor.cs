﻿using System;

namespace ModbusSynchronisation.Models
{
    public class Sensor
    {
        public int Id { get; set; }
        public int GatewayId { get; set; }
        public int Status { get; set; }

        public override string ToString()
        {
            return String.Format("Sensor {0}", Id);
        }
    }
}
