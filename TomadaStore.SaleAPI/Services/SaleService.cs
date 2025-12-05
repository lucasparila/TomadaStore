using TomadaStore.SaleAPI.Repositories.Interfaces;
using TomadaStore.SaleAPI.Services.Interfaces;
using TomadaStore.Models.DTOs.Sale;
using TomadaStore.Models.DTOs.Customer;
using System.Net.Http.Json;
using TomadaStore.Models.DTOs.Products;

namespace TomadaStore.SaleAPI.Services
{
    public class SaleService : ISaleService
    {
        private readonly ILogger<SaleService> _logger;
        private readonly ISaleRepository _saleRepository;
        private readonly HttpClient httpClientProduct;
        private readonly HttpClient httpClientCustomer;
        public SaleService(ILogger<SaleService> logger, ISaleRepository saleRepository, HttpClient httpClientProduct, HttpClient httpClientCustomer)
        {
            _logger = logger;
            _saleRepository = saleRepository;
            this.httpClientProduct = httpClientProduct;
            this.httpClientCustomer = httpClientCustomer;
        }

        public async Task CreateSaleAsync(int idCustomer, SaleRequestDTO saleDTO)
        {
            try
            {
                var products = new List<ProductResponseDTO>();
                var customer = await httpClientCustomer.GetFromJsonAsync<CustomerResponseDTO>(idCustomer.ToString());

                foreach (var idProduct in saleDTO.ProductIds)
                {
                    var product = await httpClientProduct.GetFromJsonAsync<ProductResponseDTO>(idProduct);
                    if (product != null)
                    {
                        products.Add(product);
                    }
                }
                   
                await _saleRepository.CreateSaleAsync(customer, products);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating a sale.");
                throw;
            }
        }
    }
}

