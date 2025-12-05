using TomadaStore.Models.DTOs.Products;

namespace TomadaStore.ProductAPI.Controllers.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductResponseDTO>> GetProductsAsync();
        Task<ProductResponseDTO> GetProductByIdAsync(string id);
        Task CreateProductAsync(ProductRequestDTO productRequest);
        Task UpdateProductAsync(string id, ProductRequestDTO productRequest);
        Task DeleteProductAsync(string id);


    }
}
