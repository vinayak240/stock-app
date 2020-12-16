using AutoMapper;
using SectorService.Dtos;
using SectorService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SectorService.AutoMapperProfiles
{
    public class SectorDtoProfile : Profile
    {
        public SectorDtoProfile()
        {
            CreateMap<Sector, SectorDto>().ReverseMap();
        }
    }
}
