using System.ComponentModel.DataAnnotations;
using Jambo.Validators;

namespace Jambo.Models
{
    public class SolarInverter
    {
        [Key]
        [Required]
        [StringLength(12)]
        public required string SerialNumber { get; set; }
        [Required]
        [Range(1000, 75000)]
        public int RatedPower { get; set; }
        [Required]
        [PeakPowerValidator]
        public int PeakPower { get; set; }
    }
}