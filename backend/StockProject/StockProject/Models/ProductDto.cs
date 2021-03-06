using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockProject.Models
{
    public class ProductDto
    {
        public string Name { get; set; }
        
        public int Price { get; set; }
        
        public int Quantity { get; set; }
        
        public string Brand { get; set; }
        
        public string Description { get; set; }
        
        public string Colour { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
