using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomadaStore.Models.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; private set; } 
        public string Name { get; private set; } 
        public string Description { get; private set; } 
        public decimal Price { get; private set; } 
        public Category category { get; private set; }

        [BsonConstructor]
        public Product(string id, string name, string description, decimal price, Category category)
        {
            Id = ObjectId.Parse(id);
            Name = name;
            Description = description;
            Price = price;
            this.category = category;
        }

        public Product(string name, string description, decimal price, Category category)
        {
            Name = name;
            Description = description;
            Price = price;
            this.category = category;
        }
    }
}
