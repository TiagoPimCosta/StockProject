using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockProject.Entities
{
    public class Store
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("name")]
        [BsonRequired]
        public string Name { get; set; }
        [BsonElement("address")]
        [BsonRequired]
        public string Address { get; set; }
        [BsonElement("country")]
        [BsonRequired]
        public string Country { get; set; }
        [BsonElement("activity")]
        public string Activity { get; set; }
        [BsonElement("telephone")]
        [BsonRequired]
        public string Telephone { get; set; }
        [BsonElement("nif")]
        [BsonRequired]
        public int Nif { get; set; }
    }
}
