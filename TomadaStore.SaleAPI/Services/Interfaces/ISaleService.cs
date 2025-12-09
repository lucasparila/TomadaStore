using System.Threading.Tasks;
using TomadaStore.Models.DTOs.Sale;
using TomadaStore.Models.Models;

namespace TomadaStore.SaleAPI.Services.Interfaces
{
    public interface ISaleService
    {
        Task CreateSaleAsync(int idCustomer, SaleRequestDTO saleDTO);


    }
}
