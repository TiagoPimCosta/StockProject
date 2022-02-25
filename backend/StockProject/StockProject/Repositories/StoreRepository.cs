using MongoDB.Bson;
using MongoDB.Driver;
using StockProject.Entities;
using StockProject.Models;
using System.Collections.Generic;

namespace StockProject.Repositories
{
    public class StoreRepository : BaseRepository<Store>, IRepositoryStore
    {
        public StoreRepository(IMongoClient client) : base(client)
        {
        }

        public IEnumerable<Store> GetStores()
        {
            var stores = collection.Find(new BsonDocument()).ToList();
            return stores;
        }
        public Store GetStore(string name)
        {
            var store = collection.Find(p => p.Name == name).FirstOrDefault();
            return store;
        }
        public void AddStore(Store store)
        {
           collection.InsertOne(store);
        }

        public void RemoveStore(DeleteStoreDto deleteStoreDto)
        {
            var filter = Builders<Store>.Filter.Eq(deleteStoreDto => deleteStoreDto.Name, deleteStoreDto.Name);
            collection.DeleteOne(filter);
        }

        public void UpdateStore(Store store)
        {
            var filter = Builders<Store>.Filter.Eq(store => store.Name, store.Name);
            var update = Builders<Store>.Update.Set(store => store.Country, store.Country)
                                               .Set(store => store.Address, store.Address)
                                               .Set(store => store.Activity, store.Activity)
                                               .Set(store => store.Telephone, store.Telephone)
                                               .Set(store => store.Nif, store.Nif);
            collection.UpdateOne(filter, update);
        }
    }
}
