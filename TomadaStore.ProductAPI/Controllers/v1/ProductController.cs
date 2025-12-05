using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TomadaStore.Models.DTOs.Products;
using TomadaStore.ProductAPI.Controllers.Interfaces;

namespace TomadaStore.ProductAPI.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
       private readonly ILogger<ProductController> _logger;
       private readonly IProductService _productService;
         public ProductController(ILogger<ProductController> logger, IProductService productService)
         {
              _logger = logger;
              _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductResponseDTO>>> GetProductsAsync()
        {
            try
            {
                var products = await _productService.GetProductsAsync();
                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting products.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");

            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResponseDTO>> GetProductByIdAsync(string id)
        {
            try
            {
                var product = await _productService.GetProductByIdAsync(id);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting the product by id.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }


        [HttpPost]
        public async Task<ActionResult> CreateProductAsync([FromBody] ProductRequestDTO productRequest)
        {
            try
            {
                await _productService.CreateProductAsync(productRequest);
                return Created();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a product.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

    }
}
