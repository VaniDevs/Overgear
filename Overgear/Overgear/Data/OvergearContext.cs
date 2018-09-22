using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Overgear.Models;

namespace Overgear.Models
{
    public class OvergearContext : DbContext
    {
        public OvergearContext (DbContextOptions<OvergearContext> options)
            : base(options)
        {
        }

        public DbSet<Overgear.Models.Boot> Boot { get; set; }

        public DbSet<Overgear.Models.Shirt> Shirt { get; set; }

        public DbSet<Overgear.Models.HighVisibility> HighVisibility { get; set; }

        public DbSet<Overgear.Models.Pants> Pants { get; set; }

        public DbSet<Overgear.Models.Outerwear> Outerwear { get; set; }

        public DbSet<Overgear.Models.Gloves> Gloves { get; set; }

        public DbSet<Overgear.Models.Headgear> Headgear { get; set; }

        public DbSet<Overgear.Models.Shoe> Shoe { get; set; }
    }
}
