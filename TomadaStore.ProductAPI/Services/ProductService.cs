


using TomadaStore.Models.DTOs.Products;
using TomadaStore.ProductAPI.Controllers.Interfaces;
using TomadaStore.ProductAPI.Repository;

namespace TomadaStore.ProductAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly ILogger<ProductService> _logger;
        private readonly IproductRepository _producingRepository;

        public ProductService(ILogger<ProductService> logger, IproductRepository producingRepository)
        {
            _logger = logger;
            this._producingRepository = producingRepository;
        }
        public async Task CreateProductAsync(ProductRequestDTO productRequest)
        {
            try { 
                 await _producingRepository.CreateProductAsync(productRequest);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating product: {ex.Message}");
                throw;
            }
        }

        public Task DeleteProductAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductResponseDTO> GetProductByIdAsync(string id)
        {
            try { 
                return _producingRepository.GetProductByIdAsync(id);
                }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving product by ID: {ex.Message}");
                throw;
            }
        }

        public Task<List<ProductResponseDTO>> GetProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateProductAsync(string id, ProductRequestDTO productRequest)
        {
            throw new NotImplementedException();
        }
    }
}
