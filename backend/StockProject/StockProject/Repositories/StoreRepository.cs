using MongoDB.Bson;
using MongoDB.Driver;
using StockProject.Entities;
using StockProject.Models;
using System.Collections.Generic;

namespace StockProject.Repositories
{
    public class StoreRepository : IRepositoryStore
    {
        public StoreRepository(IMongoClient cliente)
        {
            var database = cliente.GetDatabase("StockProject");
            StoreCollection = database.GetCollection<Store>("Store");
        }

        public IMongoCollection<Store> StoreCollection { get; set; }
        public IEnumerable<Store> GetStores()
        {
            var stores = StoreCollection.Find(new BsonDocument()).ToList();
            return stores;
        }
        public Store GetStore(string name)
        {
            var store = StoreCollection.Find(p => p.Name == name).FirstOrDefault();
            return store;
        }
        public void AddStore(Store store)
        {
           StoreCollection.InsertOne(store);
        }

        public void RemoveStore(DeleteStoreDto deleteStoreDto)
        {
            var filter = Builders<Store>.Filter.Eq(deleteStoreDto => deleteStoreDto.Name, deleteStoreDto.Name);
            StoreCollection.DeleteOne(filter);
        }
    }
}
