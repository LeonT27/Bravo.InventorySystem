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
    public class TransactionController : ControllerBase
    {
        private readonly IProductService _service;

        public TransactionController(IProductService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post(InsertProductTransactionCommand command)
        {
            await _service.AddProductTransaction(command);

            return NoContent();
        }
    }
}
