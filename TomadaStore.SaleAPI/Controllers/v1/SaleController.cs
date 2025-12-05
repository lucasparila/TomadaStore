using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TomadaStore.Models.DTOs.Sale;
using TomadaStore.SaleAPI.Services.Interfaces;

namespace TomadaStore.SaleAPI.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ILogger<SaleController> _logger;
        private readonly ISaleService _saleService;
        public SaleController(ISaleService saleService, ILogger<SaleController> logger)
        {
            _saleService = saleService;
            _logger = logger;
        }

        [HttpPost("customer/{idCustomer}")]
        public async Task<ActionResult> CreateSaleAsync(int idCustomer, [FromBody] SaleRequestDTO saleDTO)
        {
            try
            {

                await _saleService.CreateSaleAsync(idCustomer, saleDTO);

                return Created();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating a sale.");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}

