using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Jambo.Data;
using Jambo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Jambo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SolarPowerPlantController : Controller
    {
        private readonly ILogger<SolarPowerPlantController> _logger;

        private JamboDbContext _context;
        public SolarPowerPlantController(ILogger<SolarPowerPlantController> logger,
        JamboDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        // public IActionResult Index()
        // {
        //     return View();
        // }

        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View("Error!");
        // }
    
        [HttpPost]
        public CreatedAtActionResult AddSolarPowerPlant([FromBody] SolarPowerPlant solarPowerPlant)
        {
            solarPowerPlant.SetTotalSolarInverterWattage();
            solarPowerPlant.SetTotalSolarPanelWattage();
            _context.SolarPowerPlants.Add(solarPowerPlant);

            foreach (SolarPanel solarPanel in solarPowerPlant.SolarPanels) {
                // if solarPanel exists in the database, it gets updated
                // otherwise, an exception is thrown, and no changes are made in the database
                _context.SolarPanels.Entry(solarPanel).State = EntityState.Modified;
            }

            foreach (SolarInverter solarInverter in solarPowerPlant.SolarInverters) {
                // if solarInverter [...]
                // [...]
                _context.SolarInverters.Entry(solarInverter).State = EntityState.Modified;
            }

            _context.SaveChanges();

            return CreatedAtAction(nameof(GetSolarPowerPlantById),
            new { id = solarPowerPlant.Id },
            solarPowerPlant);
        }

        [HttpGet]
        public IEnumerable<SolarPowerPlant> GetSolarPowerPlants([FromQuery] int skip = 0, [FromQuery] int take = 10)
        {
            return _context.SolarPowerPlants
            .Include(spp => spp.SolarPanels)
            .Include(spp => spp.SolarInverters)
            .ToList();
        }

        [HttpGet("{id}")]
        public IEnumerable<SolarPowerPlant> GetSolarPowerPlantById(string id)
        {
            return _context.SolarPowerPlants
            .Where(solarPowerPlant => solarPowerPlant.Id.ToString()
            .Contains(id))
            .Include(spp => spp.SolarPanels)
            .Include(spp => spp.SolarInverters);
        }
    }
}