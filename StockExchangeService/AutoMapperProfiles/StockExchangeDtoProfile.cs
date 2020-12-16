using AutoMapper;
using StockExchangeService.Dtos;
using StockExchangeService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockExchangeService.AutoMapperProfiles
{
    public class StockExchangeDtoProfile : Profile
    {
        public StockExchangeDtoProfile()
        {
            CreateMap<StockExchange, StockExchangeDto>().ReverseMap();
        }
    }
}
