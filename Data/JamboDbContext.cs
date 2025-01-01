using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jambo.Converters;
using Jambo.Models;
using Jambo.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Jambo.Data
{
    public class JamboDbContext : DbContext
    {
        public JamboDbContext(DbContextOptions<JamboDbContext> options) : base(options) {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SolarPowerPlant>()
            .Property(spp => spp.Coordinates)
            .HasConversion<GeoCoordinatesConverter>();
        }

        public DbSet<SolarPanel> SolarPanels { get; set; }

        public DbSet<SolarInverter> SolarInverters { get; set; }
    
        public DbSet<SolarPowerPlant> SolarPowerPlants { get; set; }
    }
}
