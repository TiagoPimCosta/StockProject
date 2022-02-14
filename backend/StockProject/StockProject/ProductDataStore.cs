using StockProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockProject
{
    public class ProductDataStore
    {
        public static ProductDataStore Current { get; } = new ProductDataStore();

        public List<ProductDto> Products { get; set; }

        public ProductDataStore()
        {
            
            Products = new List<ProductDto>()
            {
                new ProductDto()
                {
                     Id = 1,
                     Name = "Coat",
                     Colour = "Blue",
                     Description = "New collection",
                     Brand = "Adidas",
                     Price = 100,
                     Quantity = 1000
                    
                     
                },
                new ProductDto()
                {
                    Id = 2,
                     Name = "Shoes",
                     Colour = "Red",
                     Description = "New collection",
                     Brand = "Nike",
                     Price = 50,
                     Quantity = 1000


                },
                new ProductDto()
                {
                    Id = 3,
                     Name = "T-shirt",
                     Colour = "Black",
                     Description = "New collection",
                     Brand = "Puma",
                     Price = 70,
                     Quantity = 1000

                },
                new ProductDto()
                {
                    Id = 4,
                     Name = "Hat",
                     Colour = "White",
                     Description = "New collection",
                     Brand = "Channel",
                     Price = 80,
                     Quantity = 1000
                }

            };
        }

    }

}
    

