using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Services.UnitService.Dto;

namespace Application.Services.UnitService
{
    public interface IUnitService
    {
        Task<IEnumerable<UnitDto>> GetUnitListAsync();
    }
}
