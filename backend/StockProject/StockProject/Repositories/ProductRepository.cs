﻿using Microsoft.AspNetCore.Mvc;
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
    public class ProductRepository : IRepository
    {

        public IMongoCollection<Product> ProductCollection { get; set; }

        public ProductRepository(IMongoClient client)
        {
            var database = client.GetDatabase("StockProject");
            ProductCollection = database.GetCollection<Product>("Product");
        }

        public IEnumerable<Product> GetProducts()
        {
            var products = ProductCollection.Find(new BsonDocument()).ToList();

            return products;
        
        }

        public Product GetProduct(string name)
        {
            var product = ProductCollection.Find(p => p.Name == name).FirstOrDefault();

            return product;

        }

        public void AddProduct(Product product)
        {
            ProductCollection.InsertOne(product);
        }

        public void StockInProduct(Product product)
        {
            var filter = Builders<Product>.Filter.Eq(product => product.Name, product.Name);
            var update = Builders<Product>.Update.Set(product => product.Quantity, product.Quantity);
            ProductCollection.UpdateOne(filter, update);


            //ProductCollection.Find(p => p.Name == product.Name).UpdateOne(product.Quantity);
        }

        public bool ProductExists(string name)
        {
            bool productExists = ProductCollection.Find(p => p.Name == name).Any();

            return productExists;
            
        }
    }
}
