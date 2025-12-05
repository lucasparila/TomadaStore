using TomadaStore.Models.DTOs.Products;

namespace TomadaStore.ProductAPI.Repository
{
    public interface IproductRepository
    {

        Task CreateProductAsync(ProductRequestDTO productDTO);
        Task <List<ProductResponseDTO>> GetProductsAsync();
        Task<ProductResponseDTO> GetProductByIdAsync(string id);
    }
}