using TomadaStore.Models.DTOs.Customer;
using TomadaStore.Models.DTOs.Products;
using TomadaStore.Models.DTOs.Sale;
using TomadaStore.Models.Models;

namespace TomadaStore.SaleAPI.Repositories.Interfaces
{
    public interface ISaleRepository
    {
        Task CreateSaleAsync(CustomerResponseDTO customer, List<ProductResponseDTO> productsDTO);
    }
}
