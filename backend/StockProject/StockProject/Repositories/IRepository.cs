using StockProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockProject.Repositories
{
    public interface IRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProduct(string name);
        bool ProductExists(string name);
        
    }
}
