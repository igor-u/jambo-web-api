namespace Jambo.Models
{
    public class SolarPowerPlant
    {
        public long Id { get; set; }
        public string? Coordinates { get; set; }
        public required Dictionary<string, SolarPanel> SolarPanels { get; set; }
        public required Dictionary<string, SolarInverter> SolarInverters { get; set; }
    }
}