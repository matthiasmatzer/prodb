using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProDB.Models
{
    public class ProtagonistContext : DbContext
    {
        public ProtagonistContext(DbContextOptions<ProtagonistContext> options) : base(options)
        {

        }

        public DbSet<Protagonist> Protagonists { get; set; }
    }
}
