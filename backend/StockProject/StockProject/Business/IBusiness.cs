using Microsoft.AspNetCore.Mvc;
using StockProject.Entities;
using StockProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockProject.Business
{
    public interface IBusiness
    {
        IEnumerable<ProductDto> GetProducts();
        ProductDto GetProduct(string name);
        void AddProduct(ProductDto productDto);
        void UpdateStockProduct(UpdateStockProductDto updateStock);
    }
}
