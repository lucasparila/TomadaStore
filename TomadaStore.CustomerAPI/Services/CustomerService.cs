using TomadaStore.CustomerAPI.Repositories;
using TomadaStore.CustomerAPI.Services.Interfaces;
using TomadaStore.Models.DTOs.Customer;
using TomadaStore.Models.Models;

namespace TomadaStore.CustomerAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<CustomerService> _logger;

        public CustomerService(ICustomerRepository customerRepository, ILogger<CustomerService> logger)
        {
            _customerRepository = customerRepository;
            _logger = logger;
        }
        public async Task<List<CustomerResponseDTO>> GetAllCustomerAsync()
        {
            try
            {
               return await _customerRepository.GetAllCustomerAsync();

            }catch(Exception e)
            {
                throw;
            }
        }

        public async Task<CustomerResponseDTO?> GetCustomerByIdAsync(int Id)
        {
            try
            {
                return await _customerRepository.GetCustomerByIdAsync(Id); 
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task InsertCustomerAsync(CustomerRequestDTO customer)
        {
            try
            {
                await _customerRepository.InsertCustomerAsync(customer);

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
