using StockProject.Entities;
using StockProject.Models;
using System;
using System.Collections.Generic;

namespace StockProject.Repositories
{
    public interface IRepositoryStore
    {
        IEnumerable<Store> GetStores();
        Store GetStore(string name);
        Store GetStore(Guid code);
        void AddStore(Store store);
        void RemoveStore(Guid code);
        void UpdateStore(Store store);
    }
}
