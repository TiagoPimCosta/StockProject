using AutoMapper;
using StockProject.Entities;
using StockProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockProject.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDtoForCreation>();
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDtoForCreation, Product>();
            CreateMap<ProductDto, Product>();
        }
    }
}
