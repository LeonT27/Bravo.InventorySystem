using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Services.ProductService;
using Application.Services.ProductService.Dto;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> Get()
        {
            var products = await _service.GetProductListAsync();
            
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Post(InsertProductCommand command)
        {
            await _service.AddProductAsync(command);

            return NoContent();
        }
    }
}
