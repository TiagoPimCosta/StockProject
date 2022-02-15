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


        public IEnumerable<ProductDto> GetProducts()
        {

            var products = _productRepository.GetProducts();

            

            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public ProductDto GetProduct(string name)
        {
            var product = _productRepository.GetProduct(name);

            

            return _mapper.Map<ProductDto>(product);
        }

        public ProductDto AddProduct(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            
            _productRepository.AddProduct(product);

            return _mapper.Map<ProductDto>(product);
        }

    }
}
