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

        public ShoesContext(DbContextOptions<ShoesContext> options) 
            : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=walmartParserdb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ShoesDb[] shoes = new ShoesDb[]
            {
                new ShoesDb
                {
                    Id = 1,
                    Name = "Adidas",
                    Image = "Apple",
                    BrandName = "Adidas5",
                    Prise = "600"
                },
                new ShoesDb()
                {
                    Id = 2,
                    Name = "Adidas",
                    Image = "Apple",
                    BrandName = "Adidas5",
                    Prise = "600"
                }
            };

            modelBuilder.Entity<ShoesDb>().HasData(shoes);
            base.OnModelCreating(modelBuilder);
        }

        //new ShoesDb[]
        //{
        //    new ShoesDb
        //    {
        //        Id =1,
        //        Name = "Adidas",
        //        Image = "Apple",
        //        BrandName = "Adidas5",
        //        Prise = "600"
        //    },
        //    new ShoesDb()
        //    {
        //        Id = 2,
        //        Name = "Adidas",
        //        Image = "Apple",
        //        BrandName = "Adidas5",
        //        Prise = "600"
        //    }
        //}
    }
}
