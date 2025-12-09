using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TomadaStore.PaymentAPI.Services;

namespace TomadaStore.PaymentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ILogger<PaymentController> _logger;
        private readonly PaymentService _paymentService;

        public PaymentController(ILogger<PaymentController> logger, PaymentService paymentService)
        {
            _logger = logger;
            _paymentService = paymentService;
        }   

        [HttpPut]
        public async Task<ActionResult> ProcessPayment()
        {
            try
            {
                
                await _paymentService.ValidateSaleAsync();
                return Ok("Payment processed successfully.");
            }
            catch (Exception ex)
            {
                
                return Problem(ex.Message);
            }
        }
    }
}
