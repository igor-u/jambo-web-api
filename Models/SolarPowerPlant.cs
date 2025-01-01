using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Jambo.Utils;

namespace Jambo.Models
{
    public class SolarPowerPlant
    {
        [Key]
        [Required]
        public long Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(19)")]
        public required GeoCoordinates Coordinates { get; set; }
        [Required]
        public required ICollection<SolarPanel> SolarPanels { get; set; }
        [Required]
        public required ICollection<SolarInverter> SolarInverters { get; set; }
    }
}