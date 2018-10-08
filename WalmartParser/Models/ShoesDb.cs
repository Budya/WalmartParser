using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalmartParser.Models
{
    public class ShoesDb
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
        public string Prise { get; set; }

        public List<Variety> Variety { get; set; }
    }

    public class Variety
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int ShoesDbId { get; set; }
        public ShoesDb ShoesDb { get; set; }
    }
}
