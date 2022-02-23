using AutoMapper;
using StockProject.Entities;
using StockProject.Models;

namespace StockProject.Profiles
{
    public class StoreProfile: Profile
    {
        public StoreProfile()
        {
            CreateMap<Store, StoreDto>();
            CreateMap<StoreDto, Store>();
        }
    }
}
