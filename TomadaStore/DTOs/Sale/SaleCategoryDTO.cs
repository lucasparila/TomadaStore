using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TomadaStore.Models.DTOs.Sale
{
    public class SaleCategoryDTO
    {


        public string Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }

        public SaleCategoryDTO() { }
        public SaleCategoryDTO(string id, string name, string description)
        {
            this.Id = id;
            Name = name;
            Description = description;
        }

    }
        
}