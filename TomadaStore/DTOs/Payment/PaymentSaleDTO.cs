using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomadaStore.Models.Models;

namespace TomadaStore.Models.DTOs.Payment
{
    public class PaymentSaleDTO
    {
        public PaymentCustomerDTO Customer { get; init; }
        public List<PaymentProductDTO> Products { get; init; }
        public DateTime SaleDate { get; init; }
        public decimal TotalPrice { get; private set; }
        public string Status { get; set; }

        public PaymentSaleDTO()
        {
        }
        public PaymentSaleDTO(PaymentCustomerDTO customer, List<PaymentProductDTO> products)
        {
       
            Customer = customer;
            Products = products;
            SaleDate = DateTime.UtcNow;
            CalcularTotalPrice();
        }

        public void CalcularTotalPrice()
        {
            TotalPrice = Products.Sum(p => p.Price);
        }
    }
}
