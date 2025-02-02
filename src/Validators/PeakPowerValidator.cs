using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Jambo.Models;

namespace Jambo.Validators
{

public class PeakPowerValidator : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var inverter = (SolarInverter)validationContext.ObjectInstance;
#pragma warning disable CS8605 // Unboxing a possibly null value.
            int peakPower = (int)value;
#pragma warning restore CS8605 // Unboxing a possibly null value.

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