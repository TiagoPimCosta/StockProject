using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using StockProject.Entities;
using StockProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockProject.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IRepository
    {
        public ProductRepository(IMongoClient client) : base(client)
        {
           
        }

        public IEnumerable<Product> GetProducts()
        {
            var products = collection.Find(new BsonDocument()).ToList();

            return products;
        
        }

        public Product GetProduct(string name)
        {
            var product = collection.Find(p => p.Name == name).FirstOrDefault();

            return product;

        }

        public void AddProduct(Product product)
        {
            collection.InsertOne(product);
        }

        public void UpdateStockProduct(Product product)
        {
            var filter = Builders<Product>.Filter.Eq(product => product.Name, product.Name);
            var update = Builders<Product>.Update.Set(product => product.Quantity, product.Quantity);
            collection.UpdateOne(filter, update);


            //ProductCollection.Find(p => p.Name == product.Name).UpdateOne(product.Quantity);
        }

        public bool ProductExists(string name)
        {
            bool productExists = collection.Find(p => p.Name == name).Any();

            return productExists;
            
        }
    }
}
