using System;
using System.Collections;
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
                
                List<Shoes> shoesParsed = new List<Shoes>();
                shoesParsed = Parser.ParserProcess.Parse();

                ShoesContext db;
                using (db = context)
                {
                    foreach (var shoe in shoesParsed)
                    {
                        ShoesDb shoesDb = new ShoesDb
                        {
                            BrandName = shoe.ShoesBrand,
                            Name = shoe.ShoesTitle,
                            Image = shoe.ShoesImageUrl,
                            Prise = shoe.ShoesPrice
                        };


                        db.Shoes.Add(shoesDb);
                        db.SaveChanges();
                    }
                }
            }
        }
    }
}
