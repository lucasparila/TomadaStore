using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomadaStore.Models.DTOs.Payment
{
    public class PaymentCustomerDTO
    {

        public string Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Email { get; init; }
        public string? PhoneNumber { get; init; }

        PaymentCustomerDTO() { }

        public PaymentCustomerDTO(string id, string firstName, string lastName, string email, string? phoneNumber)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
}
