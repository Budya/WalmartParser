using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WalmartParser.Models
{
    public class ShoesDb
    {
        
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
        public string Prise { get; set; }
        
    }
}
