using System.ComponentModel.DataAnnotations;

namespace Jambo.Models
{
    public class SolarPanel
    {
        [Key]
        [Required]
        [Length(12, 12)]
        public required string SerialNumber { get; set; }
        [Required]
        [Range(40, 600)]
        public int Power { get; set; }
    }
}