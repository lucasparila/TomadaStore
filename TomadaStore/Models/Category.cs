using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomadaStore.Models.Models
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public Category() { }
        public Category(string name, string description)
        {
            this.Id = ObjectId.GenerateNewId();
            Name = name;
            Description = description;
        }

        
        public Category(string id, string name, string description)
        {
            this.Id = ObjectId.Parse(id);
            Name = name;
            Description = description;
        }
    }
}
