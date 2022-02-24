using StockProject.Entities;
using StockProject.Models;
using System.Collections.Generic;

namespace StockProject.Repositories
{
    public interface IRepositoryStore
    {
        IEnumerable<Store> GetStores();
        Store GetStore(string name);
        void AddStore(Store store);
        void RemoveStore(DeleteStoreDto deleteStoreDto);
        void UpdateStore(Store store);
    }
}
