using System.Threading.Tasks;
using TomadaStore.Models.DTOs.Sale;

namespace TomadaStore.SaleAPI.Services.Interfaces
{
    public interface ISaleService
    {
        Task CreateSaleAsync(int idCustomer, SaleRequestDTO saleDTO);


    }
}
