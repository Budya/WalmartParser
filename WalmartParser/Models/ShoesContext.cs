using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WalmartParser.Models
{
    public class ShoesContext : DbContext
    {
        public DbSet<ShoesDb> ShoesTable { get; set; }
        public DbSet<ShoesDb.Variety> VarietysTable { get; set; }

        public ShoesContext(DbContextOptions<ShoesContext> options) 
            : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
