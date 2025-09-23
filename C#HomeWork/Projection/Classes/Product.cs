using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projection.Classes
{
    public class Product
    {
        public string Name { get; set; } 
        public string Description { get; set; }
        public double Price { get; set; } 
        public string Category { get; set; } 
        public string Brand { get; set; } 
        public int Stock { get; set; }
        public string ReleaseDate { get; set; }
        public Manufacturer Manufacturer { get; set; }
    }
}
