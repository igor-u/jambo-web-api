using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Jambo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Jambo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SolarPanelController : ControllerBase
    {
        private readonly ILogger<SolarPanelController> _logger;

        public static List<SolarPanel> solarPanels = new List<SolarPanel>();
        public SolarPanelController(ILogger<SolarPanelController> logger)
        {
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
        public void AddSolarPanel([FromBody] SolarPanel solarPanel)
        {
            solarPanels.Add(solarPanel);
        }

        [HttpGet]
        public IEnumerable<SolarPanel> GetSolarPanels()
        {
            return solarPanels;
        }
    }
}