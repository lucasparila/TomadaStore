using MongoDB.Driver;
using TomadaStore.SaleAPI.Data;
using TomadaStore.Models.DTOs.Customer;
using TomadaStore.Models.DTOs.Products;
using TomadaStore.Models.DTOs.Sale;
using TomadaStore.Models.Models;
using TomadaStore.SaleAPI.Repositories.Interfaces;

namespace TomadaStore.SaleAPI.Repositories
{
    public class SaleRepository : ISaleRepository
    {

        private readonly ILogger<SaleRepository> _logger;
        private readonly IMongoCollection<Sale> _saleCollection;
        public SaleRepository(ILogger<SaleRepository> logger, ConnectionDB mongoDatabase)
        {
            _logger = logger;
            _saleCollection = mongoDatabase.GetMongoCollection();
        }
        public async Task CreateSaleAsync(CustomerResponseDTO customer, List<ProductResponseDTO> productsDTO)
        {
            try
            {

                var products = new List<Product>();

                foreach (var product in products)
                {
                    var category = new Category
                    (
                        product.category.Id.ToString(),
                        product.category.Name,
                        product.category.Description
                   );
                    var produto = new Product
                   (
                    product.Id.ToString(),
                    product.Name,
                    product.Description,
                    product.Price,
                    category
                    );
                    products.Add(produto);
                }


                var cliente = new Customer
                (
                    customer.FirstName,
                    customer.LastName,
                    customer.Email,
                    customer.PhoneNumber
                );

                var newSale = new Sale
                (
                    cliente,
                    products
                );
                await _saleCollection.InsertOneAsync(newSale);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating sale");
                throw;
            }
        }
    }
}
