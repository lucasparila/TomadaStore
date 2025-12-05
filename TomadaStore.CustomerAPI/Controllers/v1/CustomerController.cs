using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TomadaStore.CustomerAPI.Services.Interfaces;
using TomadaStore.Models.Models;
using TomadaStore.Models.DTOs.Customer;

namespace TomadaStore.CustomerAPI.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;

        public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        [HttpPost]

        public async Task<ActionResult> CreateCustomer(CustomerRequestDTO customer)
        {
            try
            {
                _logger.LogInformation("Creating a new customer.");
                await _customerService.InsertCustomerAsync(customer);
                return Created();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while a newcustomer. " + ex.Message);
                return Problem(ex.Message);
            }

        }

        [HttpGet]
        public async Task<ActionResult<List<CustomerResponseDTO>>> GeAllCustomerAsync()
        {
            try
            {
                var customers = await _customerService.GetAllCustomerAsync();
                return customers;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while a newcustomer. " + ex.Message);
                return Problem(ex.Message);
            }


        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerResponseDTO>> GetCustormerById(int id)
        {
            try
            {
                var customer = await _customerService.GetCustomerByIdAsync(id);
                if(customer == null)
                {
                    return NotFound("Customer not found.");
                }
                return customer;
            }catch(Exception ex)
            {
                _logger.LogError("Error occurred while a newcustomer. " + ex.Message);
                return Problem(ex.Message);
            }
        }

    }
}
