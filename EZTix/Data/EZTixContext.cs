using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EZTix.Models;

namespace EZTix.Data
{
    public class EZTixContext : DbContext
    {
        public EZTixContext (DbContextOptions<EZTixContext> options)
            : base(options)
        {
        }

        public DbSet<EZTix.Models.Show> Show { get; set; } = default!;
        public DbSet<EZTix.Models.Category> Category { get; set; } = default!;
        public DbSet<EZTix.Models.Venue> Venue { get; set; } = default!;
        public DbSet<EZTix.Models.Purchase> Purchase { get; set; } = default!;
    }
}
