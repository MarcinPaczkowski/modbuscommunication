namespace ModbusExtension.Models
{
    public class ConfigurationMessage
    {
        public int BaselineFilter { get; set; }
        public int LowPassFilter { get; set; }
        public int ReportRate { get; set; }
        public int SampleCounter { get; set; }
        public int SampleRate { get; set; }
        public int TresholdAndHysteresis { get; set; }
    }
}
