using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockProject.Entities
{
    public class Product
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("price")]
        public int Price { get; set; }
        [BsonElement("quantity")]
        public int Quantity { get; set; }
        [BsonElement("brand")]
        public string Brand { get; set; }
        [BsonElement("description")]
        public string Description { get; set; }
        [BsonElement("colour")]
        public string Colour { get; set; }
        
    }
}
