using System.ComponentModel.DataAnnotations;

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

public class PeakPowerValidator : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var inverter = (SolarInverter)validationContext.ObjectInstance;
        int peakPower = (int)value;

        int minPeakPower = (int)(inverter.RatedPower * 1.2); 

        int maxPeakPower = (int)(inverter.RatedPower * 1.5); 

        if (peakPower < minPeakPower || peakPower > maxPeakPower)
        {
            return new ValidationResult($"Peak power must be at least {minPeakPower} and at most {maxPeakPower}.");
        }

        return ValidationResult.Success;
    }
}

}