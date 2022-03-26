using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Services.TransactionTypeService.Dto;

namespace Application.Services.TransactionTypeService
{
    public interface ITransactionTypeService
    {
        Task<IEnumerable<TransactionTypeDto>> GetTransactionTypeListAsync();
    }
}
