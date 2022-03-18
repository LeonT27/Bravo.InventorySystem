using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Services.ProductService.Dto;

namespace Application.Services.ProductService
{
    public interface IProductService
    {
        Task AddProductAsync(InsertProductCommand command);
        Task<IEnumerable<ProductDto>> GetProductListAsync();
        Task<IEnumerable<ProductHistory>> GetProductHistoryAsync(int id, ProductHistoryFilter filter);
        Task<IEnumerable<ProductHistory>> GetProductLossesAsync(int id, ProductHistoryFilter filter);
        Task AddProductTransaction(InsertProductTransactionCommand command);
    }
}
