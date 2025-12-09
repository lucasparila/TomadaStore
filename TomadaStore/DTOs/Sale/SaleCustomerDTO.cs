using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomadaStore.Models.DTOs.Sale
{
    public class SaleCustomerDTO
    {

        public string Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Email { get; init; }
        public string? PhoneNumber { get; init; }


        public SaleCustomerDTO() { }
        public SaleCustomerDTO(string id, string firstName, string lastName, string email)
          
        {
            this.Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public SaleCustomerDTO(string id, string firstName, string lastName, string email, string? phoneNumber)
            : this(id, firstName, lastName, email)
        {
            PhoneNumber = phoneNumber;
        }
    }
}
