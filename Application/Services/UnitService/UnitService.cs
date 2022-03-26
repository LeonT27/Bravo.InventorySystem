using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Services.UnitService.Dto;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.UnitService
{
    public class UnitService : IUnitService
    {
        private readonly IModel _model;
        private readonly IMapper _mapper;

        public UnitService(IModel model, IMapper mapper)
        {
            _model = model;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UnitDto>> GetUnitListAsync()
        {
            return await _model.Units.ProjectTo<UnitDto>(_mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
