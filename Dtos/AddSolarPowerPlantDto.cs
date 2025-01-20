using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Jambo.Models;
using Jambo.Utils;

namespace Jambo.Dtos
{
    public class AddSolarPowerPlantDto
    {
        
        public required GeoCoordinates Coordinates { get; set; }
        [Required]
        public required ICollection<SolarPanel> SolarPanels { get; set; }
        [Required]
        public required ICollection<SolarInverter> SolarInverters { get; set; }
    }
}