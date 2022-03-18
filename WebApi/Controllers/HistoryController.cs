using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services.ProductService;
using Application.Services.ProductService.Dto;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly IProductService _service;

        public HistoryController(IProductService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ProductHistory>>> Get(int id, [FromQuery] ProductHistoryFilter filter)
        {
            var productHistory = await _service.GetProductHistoryAsync(id, filter);

            return Ok(productHistory);
        }

        [HttpGet("{id}/losses")]
        public async Task<ActionResult<IEnumerable<ProductHistory>>> GetLosses(int id, [FromQuery] ProductHistoryFilter filter)
        {
            var productHistory = await _service.GetProductLossesAsync(id, filter);

            return Ok(productHistory);
        }
    }
}
