using StockProject.Models;
using System;
using System.Collections.Generic;

namespace StockProject.Business
{
    public interface IBusinessStore
    {
        IEnumerable<StoreDto> GetStores();
        StoreDto GetStore(string name);
        StoreDto GetStore(Guid code);
        void AddStore (StoreDto storeDto);
        void RemoveStore (Guid code);
        void UpdateStore(StoreDto storeDto);
    }
}
