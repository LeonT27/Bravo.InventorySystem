using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Services.TransactionTypeService.Dto;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.TransactionTypeService
{
    public class TransactionTypeService : ITransactionTypeService
    {
        private readonly IModel _model;
        private readonly IMapper _mapper;

        public TransactionTypeService(IModel model, IMapper mapper)
        {
            _model = model;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TransactionTypeDto>> GetTransactionTypeListAsync() => await _model.TransactionTypes
            .ProjectTo<TransactionTypeDto>(_mapper.ConfigurationProvider).ToListAsync();
    }
}
