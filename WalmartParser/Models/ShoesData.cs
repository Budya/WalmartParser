using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

            }
        }
    }
}
