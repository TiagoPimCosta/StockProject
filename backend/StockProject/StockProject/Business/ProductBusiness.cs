using MongoDB.Driver;
using StockProject.Entities;
using StockProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockProject.Business
{
    public class ProductBusiness : IBusiness
    {
        private readonly IRepository _productRepository;
        
        public ProductBusiness(IRepository repository)
        {
            _productRepository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public IEnumerable<Product> GetProducts()
        {
            
            return _productRepository.GetProducts();
        }

        public Product GetProduct(string name)
        {
            return _productRepository.GetProduct(name);
        }

    }
}
