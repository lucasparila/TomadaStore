using TomadaStore.Models.DTOs.Customer;
using TomadaStore.Models.Models;

namespace TomadaStore.CustomerAPI.Repositories
{
    public interface ICustomerRepository
    {
        Task InsertCustomerAsync(CustomerRequestDTO customer);
        Task<List<CustomerResponseDTO>> GetAllCustomerAsync();
        Task<CustomerResponseDTO?> GetCustomerByIdAsync(int Id);
    }
}
