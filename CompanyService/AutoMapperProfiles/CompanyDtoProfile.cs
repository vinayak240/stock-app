using AutoMapper;
using CompanyService.Dtos;
using CompanyService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyService.AutoMapperProfiles
{
    public class CompanyDtoProfile : Profile
    {
        public CompanyDtoProfile()
        {
            CreateMap<Company, CompanyDto>().ReverseMap();
        }
    }
}
