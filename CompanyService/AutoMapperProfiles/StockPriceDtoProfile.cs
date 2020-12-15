using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;
using CompanyService.Dtos;
using CompanyService.Entities;

namespace CompanyService.AutoMapperProfiles
{
    public class StockPriceDtoProfile : Profile
    {
        public StockPriceDtoProfile()
        {
            CreateMap<StockPrice, StockPriceDto>().ReverseMap();
        }
    }
}
