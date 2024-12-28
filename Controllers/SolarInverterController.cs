using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Jambo.Data;
using Jambo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Jambo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SolarInverterController : Controller
    {
        private readonly ILogger<SolarInverterController> _logger;
        private JamboDbContext _context;
        public SolarInverterController(ILogger<SolarInverterController> logger,
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

        public CreatedAtActionResult AddSolarInverter([FromBody] SolarInverter solarInverter)
        {
            _context.SolarInverters.Add(solarInverter);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetSolarInverterBySerialNumber),
            new { serialNumber = solarInverter.SerialNumber },
            solarInverter);
        }

        [HttpGet]
        public IEnumerable<SolarInverter> GetSolarInverters([FromQuery] int skip = 0, [FromQuery] int take = 10)
        {
            return _context.SolarInverters.Skip(skip).Take(take);
        }

        [HttpGet("{serialNumber}")]
        public IEnumerable<SolarInverter> GetSolarInverterBySerialNumber(string serialNumber)
        {
            return _context.SolarInverters.Where(solarInverter => solarInverter.SerialNumber.Contains(serialNumber));
        }
    }
}