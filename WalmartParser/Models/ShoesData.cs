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
                context.Shoes.AddRange(
                    new ShoesDb
                    {
                        Name = "Adidas",
                        Image = "Apple",
                        BrandName = "Adidas5",
                        Prise = "600"
                    },
                    new ShoesDb()
                    {
                        Name = "Adidas",
                        Image = "Apple",
                        BrandName = "Adidas5",
                        Prise = "600"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
