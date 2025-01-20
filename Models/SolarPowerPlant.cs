using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Jambo.Utils;

namespace Jambo.Models
{
    public class SolarPowerPlant
    {
        [Key]
        [Required]
        public long Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(19)")]
        public required GeoCoordinates Coordinates { get; set; }
        [Required]
        public required ICollection<SolarPanel> SolarPanels { get; set; }
        [Required]
        public required ICollection<SolarInverter> SolarInverters { get; set; }
        //since totalWattage is a dynamic value, there is no need to serialize it
        [JsonIgnore]
        public int TotalSolarPanelWattage { get; set; }
        [JsonIgnore]
        public int TotalSolarInverterWattage { get; set; }
        public void SetTotalSolarPanelWattage() {
            TotalSolarPanelWattage = SolarPanels
            .Select(p => p.Power)
            .Sum();
        }
        public void SetTotalSolarInverterWattage() {
            TotalSolarInverterWattage = SolarInverters
            .Select(p => p.RatedPower)
            .Sum();
        }
    }
}