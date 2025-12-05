using TomadaStore.Models.Models;
using TomadaStore.Models.DTOs.Customer;

namespace TomadaStore.CustomerAPI.Services.Interfaces
{
    public interface ICustomerService
    {
        Task InsertCustomerAsync(CustomerRequestDTO customer);
        Task<List<CustomerResponseDTO>> GetAllCustomerAsync();
        Task<CustomerResponseDTO?> GetCustomerByIdAsync(int Id);
    }
}
