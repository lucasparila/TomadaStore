using MongoDB.Bson;
using MongoDB.Driver;
using System.Runtime.CompilerServices;
using TomadaStore.Models.DTOs.Category;
using TomadaStore.Models.DTOs.Products;
using TomadaStore.Models.Models;
using TomadaStore.ProductAPI.Data;

namespace TomadaStore.ProductAPI.Repository
{
    public class ProductRepository : IproductRepository
    {

        private readonly ILogger<ProductRepository> _logger;
        private readonly IMongoCollection<Product> _mongoCollection;
        private readonly ConnectionDB _connection;

        public ProductRepository(ILogger<ProductRepository> logger, ConnectionDB connection)
        {
            _logger = logger;
            _connection = connection;
            _mongoCollection = _connection.GetMongoCollection();
        }

        public async Task CreateProductAsync(ProductRequestDTO productDTO)
        {
            try
            {
                await _mongoCollection.InsertOneAsync(new Product 
                (
                    productDTO.Name, 
                    productDTO.Description, 
                    productDTO.Price, 
                    new Category
                    (
                        productDTO.category.Name, 
                        productDTO.category.Description
                    )
                ));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao criar produto: {ex.Message}");
                throw;
            }
        }

        public async Task<ProductResponseDTO> GetProductByIdAsync(string id)
        {
            try
            {
                var filter = Builders<Product>.Filter.Eq("_id", ObjectId.Parse(id));
                var product = await _mongoCollection.Find(filter).FirstOrDefaultAsync();
                if (product == null)
                {
                    return null;
                }
                return new ProductResponseDTO
                (
                    product.Id.ToString(),
                     product.Name,
                    product.Description,
                    product.Price,
                    new CategoryResponseDTO
                    (
                        product.category.Id.ToString(),
                        product.category.Name,
                        product.category.Description
                    )
               );
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao buscar produto pelo id: {ex.Message}");
                throw;
            }
        }

        public Task<List<ProductResponseDTO>> GetProductsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
