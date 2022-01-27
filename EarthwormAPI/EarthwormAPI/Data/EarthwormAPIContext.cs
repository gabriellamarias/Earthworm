using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EarthwormAPI.Models;

namespace EarthwormAPI.Data
{
    public class EarthwormAPIContext : DbContext
    {
        public EarthwormAPIContext (DbContextOptions<EarthwormAPIContext> options)
            : base(options)
        {
        }

        public DbSet<EarthwormAPI.Models.garden> garden { get; set; }

        public DbSet<EarthwormAPI.Models.gardener> gardener { get; set; }
    }
}
