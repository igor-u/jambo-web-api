using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Jambo.Data
{
    public class JamboDbContext : DbContext
    {
        public JamboDbContext(DbContextOptions<JamboDbContext> options) : base(options) {

        }
    }
}