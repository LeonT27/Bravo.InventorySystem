using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Services.TransactionTypeService;
using Application.Services.TransactionTypeService.Dto;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionTypeController : ControllerBase
    {
        private readonly ITransactionTypeService _service;

        public TransactionTypeController(ITransactionTypeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionTypeDto>>> Get() =>
            Ok(await _service.GetTransactionTypeListAsync());
    }
}
