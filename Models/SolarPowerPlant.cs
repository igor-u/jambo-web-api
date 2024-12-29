using System.ComponentModel.DataAnnotations;

namespace Jambo.Models
{
    public class SolarPowerPlant
    {
        [Key]
        [Required]
        public long Id { get; set; }
        [Required]        
        public string? Coordinates { get; set; }
        [Required]
        public required Dictionary<string, SolarPanel> SolarPanels { get; set; }
        [Required]
        public required Dictionary<string, SolarInverter> SolarInverters { get; set; }
    }
}