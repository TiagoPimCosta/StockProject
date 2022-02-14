using StockProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockProject.Business
{
    public interface IBusiness
    {
        IEnumerable<Product> GetProducts();
        Product GetProduct(string name);


    }
}
