using MongoDB.Bson;
using MongoDB.Driver;
using StockProject.Entities;
using StockProject.Models;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace StockProject.Repositories
{
    public class StoreRepository : BaseRepository<Store>, IRepositoryStore
    {
        public StoreRepository(IMongoClient client, IMongoDatabase dbName) : base(dbName)
        {
        }

        public IEnumerable<Store> GetStores()
        {
            return GetRequest();
        }
        public Store GetStore(string name)
        {
            return collection.Find(p => p.Name == name).FirstOrDefault();
        }
        public Store GetStore(Guid code)
        {
            return collection.Find(p => p.Code == code).FirstOrDefault(); ;
        }
        public void AddStore(Store store)
        {
           AddOne(store);
        }

        public void RemoveStore(Guid code)
        {
            collection.DeleteOne(p => p.Code == code);
        }

        public void UpdateStore(Store store)
        {
            var filter = Builders<Store>.Filter.Eq(store => store.Code, store.Code);
            var update = Builders<Store>.Update.Set(store => store.Name, store.Name)
                                               .Set(store => store.Country, store.Country)
                                               .Set(store => store.Address, store.Address)
                                               .Set(store => store.Activity, store.Activity)
                                               .Set(store => store.Telephone, store.Telephone)
                                               .Set(store => store.Nif, store.Nif);
            collection.UpdateOne(filter, update);
        }
    }
}
