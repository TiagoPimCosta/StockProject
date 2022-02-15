using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using StockProject.Entities;
using StockProject.Models;
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
        private readonly IMapper _mapper;

        public ProductBusiness(IRepository repository, IMapper mapper)
        {
            _productRepository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        public IEnumerable<Product> GetProducts()
        {

            var products = _productRepository.GetProducts();

            

            return (IEnumerable<Product>)_mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public ProductDto GetProduct(string name)
        {
            var product = _productRepository.GetProduct(name);

            

            return _mapper.Map<ProductDto>(product);
        }

        public void AddProduct(Product product)
        {
            _productRepository.AddProduct(product);
        }

    }
}
