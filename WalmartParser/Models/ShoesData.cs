using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WalmartParser.Models
{
    public class ShoesData
    {

        public static void Initialize(ShoesContext context)
        {
            if (!context.Shoes.Any())
            {
                //List<Shoes> shoeses = new List<Shoes>();
                //shoeses = Parser.ParserProcess.Parse();
                //context.Shoes.AddRange(shoeses);

                //context.SaveChanges();
                List<Shoes> shoeses = new List<Shoes>();
                shoeses = Parser.ParserProcess.Parse();

                Console.ReadKey();

                using (context)
                {
                    foreach (var shoe in shoeses)
                    {
                        ShoesDb shoesDb = new ShoesDb();

                        shoesDb.BrandName = shoe.ShoesBrand;
                        shoesDb.Name = shoe.ShoesTitle;
                        shoesDb.Image = shoe.ShoesImageUrl;
                        shoesDb.Prise = shoe.ShoesPrice;
                        foreach (string variant in shoe.ShoesVariants)
                        {
                            shoesDb.Variety.Na
                        }

                    }
                    
                }


            }
        }
    }
}
