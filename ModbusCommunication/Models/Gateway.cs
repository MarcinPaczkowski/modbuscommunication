namespace ModbusSensorOperation.Models
{
    public class Gateway
    {
        public int ZoneId { get; set; }
        public string ZoneName { get; set; }
        public int GatewayId { get; set; }
        public string SerialPort { get; set; }
        public int ActiveStatus { get; set; }
        public int ConnectionStatus { get; set; }
        public int Command { get; set; }
    }
}
