using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomadaStore.Models.DTOs.Sale
{
    public class SaleProductDTO
    {

        public string Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public decimal Price { get; init; }
        public SaleCategoryDTO category { get; init; }

        public SaleProductDTO() { }
        public SaleProductDTO(string id, string name, string description, decimal price, SaleCategoryDTO category)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            this.category = category;
        }

        public SaleProductDTO(string name, string description, decimal price, SaleCategoryDTO category)
        {
            Name = name;
            Description = description;
            Price = price;
            this.category = category;
        }
    }
}
