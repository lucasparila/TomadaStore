using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomadaStore.Models.DTOs.Payment
{
    public class PaymentProductDTO
    {

        public string Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public decimal Price { get; init; }
        public PaymentCategoryDTO category { get; init; }

        public PaymentProductDTO() { }
        public PaymentProductDTO(string id, string name, string description, decimal price, PaymentCategoryDTO category)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            this.category = category;
        }
    }
}
