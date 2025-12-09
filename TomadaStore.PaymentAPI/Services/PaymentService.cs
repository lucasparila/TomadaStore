using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using TomadaStore.Models.DTOs.Customer;
using TomadaStore.Models.DTOs.Payment;
using TomadaStore.Models.DTOs.Products;
using TomadaStore.Models.DTOs.Sale;
using TomadaStore.Models.Models;

namespace TomadaStore.PaymentAPI.Services
{
    public class PaymentService
    {

        private readonly ILogger<PaymentService> _logger;
        private readonly HttpClient httpClientProduct;
        private readonly HttpClient httpClientCustomer;
        private readonly IConnectionFactory _connectionFactory;
        public PaymentService(ILogger<PaymentService> logger, IHttpClientFactory httpClientFactory, IConnectionFactory connection)
        {
            _logger = logger;
            this.httpClientProduct = httpClientFactory.CreateClient("ClientProduct");
            this.httpClientCustomer = httpClientFactory.CreateClient("ClientCustomer");
            this._connectionFactory = connection;
        }

        public async Task ValidateSaleAsync()
        {
            try
            {

                using var connection = await _connectionFactory.CreateConnectionAsync();
                using var channel = await connection.CreateChannelAsync();
                await channel.QueueDeclareAsync(queue: "salesQueue",
                                             durable: false,
                                             exclusive: false,
                                             autoDelete: false,
                                             arguments: null);

                var consumer = new AsyncEventingBasicConsumer(channel);
                consumer.ReceivedAsync += async (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);

                    var sale = JsonSerializer.Deserialize<SaleRequestDTO>(message);


                    var customer = await httpClientCustomer.GetFromJsonAsync<CustomerResponseDTO>(sale.ClienteId.ToString());
                    if (customer == null)
                    {
                        throw new Exception("Cliente não encontrado");
                    }
                    var cliente = new PaymentCustomerDTO
                                    (
                                        sale.ClienteId.ToString(),
                                        customer.FirstName,
                                        customer.LastName,
                                        customer.Email,
                                        customer.PhoneNumber
                                    );


                    var products = new List<PaymentProductDTO>();
                    foreach (var idProduct in sale.ProductIds)
                    {
                        var product = await httpClientProduct.GetFromJsonAsync<ProductResponseDTO>(idProduct);
                        if (product == null)
                        {
                            throw new Exception("Produto não encontrado");
                        }
                        var category = new PaymentCategoryDTO
                                        (
                                            product.category.Id.ToString(),
                                            product.category.Name,
                                            product.category.Description
                                       );
                        var produto = new PaymentProductDTO
                                        (
                                         product.Id.ToString(),
                                         product.Name,
                                         product.Description,
                                         product.Price,
                                         category
                                         );
                        products.Add(produto);
                    }

                    PaymentSaleDTO newSale = new PaymentSaleDTO
                                   (
                                       cliente,
                                       products
                                   );


                    if(newSale.TotalPrice < 1000)
                    {
                        
                        Console.WriteLine($" [x] Sale: processed successfully. Total Price: {newSale.TotalPrice}");
                        newSale.Status = "Approved";

                        await ProcessPaymentAsync(newSale);
                    }
                    else
                    {
                        Console.WriteLine($" [x] Sale requires manual payment approval. Total Price: {newSale.TotalPrice}");
                        newSale.Status = "Reproved";
                        await ProcessPaymentAsync(newSale);
                    }

                    Console.WriteLine($" [x] Received {message}");


                };

                await channel.BasicConsumeAsync(
                queue: "salesQueue",
                autoAck: true,
                consumer: consumer);

                Console.WriteLine(" [*] Aguardando mensagens... CTRL+C para sair");



            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating a sale.");
                throw;
            }
        }
    


        public async Task ProcessPaymentAsync(PaymentSaleDTO sale)
        {
            try
            {
                using var connection = await _connectionFactory.CreateConnectionAsync();
                using var channel = await connection.CreateChannelAsync();
                await channel.QueueDeclareAsync(queue: "paymentsQueue",
                                             durable: false,
                                             exclusive: false,
                                             autoDelete: false,
                                             arguments: null);

                var message = JsonSerializer.Serialize(sale);
                var body = Encoding.UTF8.GetBytes(message);
                await channel.BasicPublishAsync(exchange: string.Empty,
                                             routingKey: "paymentsQueue",
                                             body: body);
                Console.WriteLine($" [x] Sent {message}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing payment");
                throw;
            }
        }
    }
}
