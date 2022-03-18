using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Services.ProductService.Dto;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IModel _model;
        private readonly IMapper _mapper;

        private static readonly int[] Entries = new[] { 1, 2, 3 };
        private const int Losses = 4;

        public ProductService(IModel model, IMapper mapper)
        {
            _model = model;
            _mapper = mapper;
        }

        public async Task AddProductAsync(InsertProductCommand command)
        {
            var validation = await new InsertProductCommandValidation().ValidateAsync(command);

            if (!validation.IsValid) throw new ValidationException(validation.Errors);

            var unit = await _model.Units.FindAsync(command.UnitId);

            if (unit is null) throw new NotFoundException("unidad", command.UnitId);

            _model.Products.Add(_mapper.Map<Product>(command));

            await _model.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductDto>> GetProductListAsync()
        {
            return await _model.Products
                .Include(i => i.Unit)
                .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductHistory>> GetProductHistoryAsync(int id, ProductHistoryFilter filter)
        {
            var product = await _model.Products.FindAsync(id);
            if (product is null) throw new NotFoundException("producto", id);

            var history = await _model.Transactions
                .Include(i => i.Product).ThenInclude(i => i.Unit)
                .Include(i => i.TransactionType)
                .Where(w => w.ProductId == id && Entries.Contains(w.TransactionTypeId))
                .ProjectTo<ProductHistory>(_mapper.ConfigurationProvider)
                .ToListAsync();

            if (!history.Any()) return new List<ProductHistory>(0);

            var validateFilter = await new ProductHistoryFilterValidation().ValidateAsync(filter);

            if (!validateFilter.IsValid) throw new ValidationException(validateFilter.Errors);
            
            return FilterBy(history, filter);
        }

        public async Task<IEnumerable<ProductHistory>> GetProductLossesAsync(int id, ProductHistoryFilter filter)
        {
            var product = await _model.Products.FindAsync(id);
            if (product is null) throw new NotFoundException("producto", id);

            var losses = await _model.Transactions
                .Include(i => i.Product).ThenInclude(i => i.Unit)
                .Include(i => i.TransactionType)
                .Where(w => w.ProductId == id && w.TransactionTypeId == Losses)
                .ProjectTo<ProductHistory>(_mapper.ConfigurationProvider)
                .ToListAsync();

            if (!losses.Any()) return new List<ProductHistory>(0);

            var validateFilter = await new ProductHistoryFilterValidation().ValidateAsync(filter);

            if (!validateFilter.IsValid) throw new ValidationException(validateFilter.Errors);

            return FilterBy(losses, filter);
        }

        public async Task AddProductTransaction(InsertProductTransactionCommand command)
        {
            var validation = await new InsertProductTransactionCommandValidation().ValidateAsync(command);

            if (!validation.IsValid) throw new ValidationException(validation.Errors);

            var product = await _model.Products.FindAsync(command.ProductId);

            if (product is null) throw new NotFoundException("producto", command.ProductId);

            var transactionType = await _model.TransactionTypes.FindAsync(command.TransactionTypeId);

            if (transactionType is null) throw new NotFoundException("tipo", command.TransactionTypeId);

            var productQuantity = command.Quantity;
            if (transactionType.Operation == '-') productQuantity *= -1;

            product.Quantity += productQuantity;

            _model.Transactions.Add(_mapper.Map<Transaction>(command));

            await _model.SaveChangesAsync();
        }

        private static IEnumerable<ProductHistory> FilterBy(IEnumerable<ProductHistory> list, ProductHistoryFilter filter)
        {
            return list
                .Where(w =>
                    w.Unit.Contains(filter.Unit ?? string.Empty, StringComparison.CurrentCultureIgnoreCase)
                    && w.ProductName.Contains(filter.ProductName ?? string.Empty, StringComparison.CurrentCultureIgnoreCase)
                    && w.Purpose.Contains(filter.Purpose ?? string.Empty, StringComparison.CurrentCultureIgnoreCase)
                    && w.TransactionType.Contains(filter.TransactionType ?? string.Empty, StringComparison.CurrentCultureIgnoreCase))
                .ToList();
        }
    }
}
