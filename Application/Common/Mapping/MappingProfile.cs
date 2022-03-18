﻿using Application.Services.ProductService.Dto;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(d => d.Unit, o => o.MapFrom(s => s.Unit.Name));

            CreateMap<Transaction, ProductHistory>()
                .ForMember(d => d.Created, o => o.MapFrom(s => s.Created))
                .ForMember(d => d.ProductName, o => o.MapFrom(s => s.Product.Name))
                .ForMember(d => d.Unit, o => o.MapFrom(s => s.Product.Unit.Name))
                .ForMember(d=>d.TransactionType,o=>o.MapFrom(s=>s.TransactionType.Name));

            CreateMap<InsertProductCommand, Product>();

            CreateMap<InsertProductTransactionCommand, Transaction>();
        }
    }
}
