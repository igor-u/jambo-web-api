namespace Jambo.Models
{
    public class SolarInverter
    {
        public required string SerialNumber { get; set; }
        public int RatedPower { get; set; }
        public int PeakPower { get; set; }
    }
}