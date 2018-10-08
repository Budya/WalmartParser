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
            if (!context.ShoesTable.Any())
            {
                //List<Shoes> shoeses = new List<Shoes>();
                //shoeses = Parser.ParserProcess.Parse();
                //context.Shoes.AddRange(shoeses);

                //context.SaveChanges();
                List<Shoes> shoeses = new List<Shoes>();
                shoeses = Parser.ParserProcess.Parse();

                ShoesContext db;
                using (db = context)
                {
                    foreach (var shoe in shoeses)
                    {
                        ShoesDb shoesDb = new ShoesDb
                        {
                            BrandName = shoe.ShoesBrand,
                            Name = shoe.ShoesTitle,
                            Image = shoe.ShoesImageUrl,
                            Prise = shoe.ShoesPrice
                        };


                        db.ShoesTable.Add(shoesDb);
                        db.SaveChanges();
                    }

                    //int i = 1;
                }
            }
        }
    }
}
