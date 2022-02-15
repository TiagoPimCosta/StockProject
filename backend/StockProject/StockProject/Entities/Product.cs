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
        [BsonRequired]
        public string Name { get; set; }
        [BsonElement("price")]
        [BsonRequired]
        public int Price { get; set; }
        [BsonElement("quantity")]
        public int Quantity { get; set; }
        [BsonElement("brand")]
        [BsonRequired]
        public string Brand { get; set; }
        [BsonElement("description")]
        [BsonRequired]
        public string Description { get; set; }
        [BsonElement("colour")]
        [BsonRequired]
        public string Colour { get; set; }
        public DateTime CreationTime { get; set; }

    }
}
