using MongoDB.Bson;

namespace TomadaStore.Models.DTOs.Payment
{
    public class PaymentCategoryDTO
    {

        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public PaymentCategoryDTO() { }
        public PaymentCategoryDTO(string id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}