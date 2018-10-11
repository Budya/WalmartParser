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

        public ShoesContext()
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

            List<Shoes> walmShoes = new List<Shoes>();
            walmShoes = Parser.ParserProcess.Parse();
            List<ShoesDb> tempList = new List<ShoesDb>();
            for (int i = 0; i < walmShoes.Count; i++)
            {
                ShoesDb tempShoes = new ShoesDb
                {
                    BrandName = walmShoes[i].ShoesBrand,
                    Id = i+1,
                    Image = walmShoes[i].ShoesImageUrl,
                    Name = walmShoes[i].ShoesTitle,
                    Prise = walmShoes[i].ShoesPrice
                };
                tempList.Add(tempShoes);
            }
            
            

            modelBuilder.Entity<ShoesDb>().HasData(tempList.Cast<ShoesDb>().ToArray());
            base.OnModelCreating(modelBuilder);
        }
    }
}
