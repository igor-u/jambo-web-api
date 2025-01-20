using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jambo.Dtos;
using Jambo.Models;

namespace Jambo.Profiles
{
    public class SolarPowerPlantProfile : Profile
    {

        public SolarPowerPlantProfile()
        {
            CreateMap<AddSolarPowerPlantDto, SolarPowerPlant>()
            .ForMember(spp => spp.TotalSolarPanelWattage,
                    opt => opt.MapFrom(src => src.SolarPanels
                    .Select(p => p.Power)
                    .Sum()))
            .ForMember(spp => spp.TotalSolarInverterWattage,
                    opt => opt.MapFrom(src => src.SolarInverters
                    .Select(p => p.RatedPower)
                    .Sum()));
        }

    }
}