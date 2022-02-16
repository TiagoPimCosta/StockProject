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

        public void AddProduct(ProductDto productDto)
        {
            var product = _productRepository.GetProduct(productDto.Name);

            if (product != null)
            {
                throw new Exception("Product exists.");
            }

            productDto.Quantity = 0;
            var newProduct = _mapper.Map<Product>(productDto);

            _productRepository.AddProduct(newProduct);
        }

        public void UpdateStockProduct(UpdateStockProductDto updateStock)
        {
            var product = _productRepository.GetProduct(updateStock.Name);

            if (updateStock.StockIn)
            {
                product.Quantity += updateStock.Quantity;
            }
            else
            {
                product.Quantity -= updateStock.Quantity;

                if (product.Quantity < 0)
                {
                    throw new Exception("Quantity is not allow.");
                }
            }

            _productRepository.UpdateStockProduct(product);
        }
    }
}
