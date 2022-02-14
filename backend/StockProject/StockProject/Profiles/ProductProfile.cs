using AutoMapper;
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
            CreateMap<Entities.Product, ProductDtoForCreation>();
            CreateMap<Entities.Product, ProductDto>();
            CreateMap<ProductDtoForCreation, Entities.Product>();
        }
    }
}
