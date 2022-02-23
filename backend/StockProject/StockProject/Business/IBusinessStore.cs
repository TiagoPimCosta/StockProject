using StockProject.Models;
using System.Collections.Generic;

namespace StockProject.Business
{
    public interface IBusinessStore
    {
        IEnumerable<StoreDto> GetStores();
        StoreDto GetStore(string name);
        void AddStore (StoreDto storeDto);
    }
}
