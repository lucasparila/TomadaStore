using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TomadaStore.Models.Models;

namespace TomadaStore.Models.DTOs.Sale
{
    public class SaleRequestRabbitDTO
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; init; }
        public SaleCustomerDTO Customer { get; init; }
        public List<SaleProductDTO> Products { get; init; }
        public DateTime SaleDate { get; init; }
        public decimal TotalPrice { get; init; }
        public string Status { get; init; }

        public SaleRequestRabbitDTO() { }

        public SaleRequestRabbitDTO(string id, SaleCustomerDTO customer, List<SaleProductDTO> products, DateTime SaleDate, decimal TotalPrice) 
        {
            Id = id;
            Customer = customer;
            Products = products;
            this.SaleDate = SaleDate;
            this.TotalPrice = TotalPrice;
        }

       
    }
}

