using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomadaStore.Models.DTOs.Category;
using TomadaStore.Models.Models;

namespace TomadaStore.Models.DTOs.Products
{
    public class ProductResponseDTO
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; init; }
        [BsonElement("name")]
        public string Name { get; init; }
        [BsonElement("description")]
        public string Description { get; init; }
        [BsonElement("price")]
        public decimal Price { get; init; }
        [BsonElement("category")]
        public CategoryResponseDTO category { get; init; }

        public ProductResponseDTO(string id, string name, string description, decimal price, CategoryResponseDTO category)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            this.category = category;
        }
    }
}
