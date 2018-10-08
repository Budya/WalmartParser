using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WalmartParser.Models
{
    public class ShoesContext : DbContext
    {
        public DbSet<ShoesDb> Shoes { get; set; }
        public DbSet<Variety> Varieties { get; set; }

        public ShoesContext(DbContextOptions<ShoesContext> options) 
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
