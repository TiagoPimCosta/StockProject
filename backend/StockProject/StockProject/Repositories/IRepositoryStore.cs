using StockProject.Entities;
using System.Collections.Generic;

namespace StockProject.Repositories
{
    public interface IRepositoryStore
    {
        IEnumerable<Store> GetStores();
        Store GetStore(string name);
        void AddStore(Store store);
    }
}
