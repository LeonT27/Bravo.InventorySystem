using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.UnitService.Dto;

namespace Application.Services.UnitService
{
    public interface IUnitService
    {
        Task<IEnumerable<UnitDto>> GetUnitListAsync();
    }
}
