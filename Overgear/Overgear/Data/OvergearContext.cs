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
    }
}
