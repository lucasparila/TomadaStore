
using RabbitMQ.Client;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using TomadaStore.Models.DTOs.Customer;
using TomadaStore.Models.DTOs.Products;
using TomadaStore.Models.DTOs.Sale;
using TomadaStore.SaleAPI.Services.Interfaces;

namespace TomadaStore.SaleAPI.Services
{
    public class SaleService : ISaleService
    {
        private readonly ILogger<SaleService> _logger;
      
        private readonly HttpClient httpClientProduct;
        private readonly HttpClient httpClientCustomer;
        private readonly IConnectionFactory _connectionFactory;

        public SaleService(ILogger<SaleService> logger, IHttpClientFactory httpClientFactory, IConnectionFactory _connection)
        {
            _logger = logger;
           
            this.httpClientProduct = httpClientFactory.CreateClient("ClientProduct");
            this.httpClientCustomer = httpClientFactory.CreateClient("ClientCustomer");
            _connectionFactory = _connection;
        }
   

        public async Task CreateSaleAsync(int idCustomer, SaleRequestDTO saleDTO)
        {
            try
            {
               
                var customer = await httpClientCustomer.GetFromJsonAsync<CustomerResponseDTO>(saleDTO.ClienteId.ToString());
                if (customer == null)
                {
                    throw new Exception("Cliente não encontrado");
                }

                foreach (var idProduct in saleDTO.ProductIds)
                {
                    var product = await httpClientProduct.GetFromJsonAsync<ProductResponseDTO>(idProduct);
                    if (product == null)
                    {
                        throw new Exception("Produto não encontrado");
                    }
                }

                using var connection = await _connectionFactory.CreateConnectionAsync();
                using var channel = await connection.CreateChannelAsync();
                await channel.QueueDeclareAsync(queue: "salesQueue",
                                             durable: false,
                                             exclusive: false,
                                             autoDelete: false,
                                             arguments: null);
                var message = JsonSerializer.Serialize(saleDTO);
                var body = Encoding.UTF8.GetBytes(message);

                await channel.BasicPublishAsync(exchange: string.Empty,
                                             routingKey: "salesQueue",
                                             body: body);
                Console.WriteLine($" [x] Sent {message}");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating a sale.");
                throw;
            }
        }
    }
}

