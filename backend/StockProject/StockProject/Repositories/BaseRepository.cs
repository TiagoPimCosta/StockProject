using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace StockProject.Repositories
{
    public class BaseRepository<T>
    {
        protected readonly IMongoDatabase _database;
        public IMongoCollection<T> collection { get; set; }

        public BaseRepository(IMongoDatabase dbName)
        {
            _database = dbName;
            this.collection = _database.GetCollection<T>(typeof(T).Name);
        }

        public IEnumerable<T> GetRequest()
        {
            return collection.Find(new BsonDocument()).ToList();
        }
        
        public void AddOne(T t)
        {
            collection.InsertOne(t);
        }
    }
}
