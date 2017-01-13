using System.Collections.Generic;
using AutoMapper;
using CoreWEBAPI.Domain.DTOs;
using CoreWEBAPI.Domain.Models;

namespace CoreWEBAPI.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BillDto, BillModel>();
            CreateMap<BillModel, BillDto>();
            CreateMap<CompanyModel, CompanyDto>();
            CreateMap<CompanyDto, CompanyModel>();
            CreateMap<ProductModel, ProductDto>();
            CreateMap<ProductDto, ProductModel>();
        }
    }
}