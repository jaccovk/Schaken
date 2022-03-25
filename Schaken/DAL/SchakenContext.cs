using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Schaken.Models;

namespace Schaken.DAL
{
    public class SchakenContext : DbContext
    {
        public SchakenContext (DbContextOptions<SchakenContext> options)
            : base(options)
        {
        }

        public DbSet<Schaken.Models.Speler> Speler { get; set; }

        public DbSet<Schaken.Models.Partij> Partij { get; set; }
    }
}
