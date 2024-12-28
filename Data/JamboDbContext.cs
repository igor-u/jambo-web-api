using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jambo.Models;
using Microsoft.EntityFrameworkCore;

namespace Jambo.Data
{
    public class JamboDbContext : DbContext
    {
        public JamboDbContext(DbContextOptions<JamboDbContext> options) : base(options) {

        }

        public DbSet<SolarPanel> SolarPanels { get; set; }

        public DbSet<SolarInverter> SolarInverters { get; set; }
    
    }
}
