using AutoMapper;
using CompanyService.Domain.Contracts;
using CompanyService.Dtos;
using CompanyService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyService.Domain.Services
{
    public class IPOService : IIPOService
    {
        readonly IIPORepository repo;
        readonly IMapper mapper;
        public IPOService(IIPORepository repository, IMapper mapper)
        {
            this.repo = repository;
            this.mapper = mapper;
        }
        public bool AddIPO(IPODto ipo)
        {
            var obj = mapper.Map<IPO>(ipo);
            return repo.AddIPO(obj);
        }

        public IEnumerable<IPODto> GetIpos()
        {
            var ipos = repo.GetIpos();
            var dtos = mapper.Map<IEnumerable<IPODto>>(ipos);
            return dtos;
        }
    }
}
