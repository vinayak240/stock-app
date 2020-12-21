using AutoMapper;
using SectorService.Domain.Contracts;
using SectorService.Dtos;
using SectorService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SectorService.Domain.Services
{
    public class SectorService : ISectorService
    {
        readonly ISectorRepository repo;
        readonly IMapper mapper;
        public SectorService(ISectorRepository repository, IMapper mapper)
        {
            this.repo = repository;
            this.mapper = mapper;
        }

        public bool AddSectors(SectorDto sector)
        {
            var obj = mapper.Map<Sector>(sector);
            return repo.AddSectors(obj);
        }

        public SectorDto GetSector(int id)
        {
            var Obj = repo.GetSector(id);
            var Dto = mapper.Map<SectorDto>(Obj);
            return Dto;
        }

        public IEnumerable<Company> GetSectorCompanies(string name)
        {
            
            return repo.GetSectorCompanies(name);
        }

        public IEnumerable<SectorDto> GetSectors()
        {
            var sectors = repo.GetSectors();
            var dtos = mapper.Map<IEnumerable<SectorDto>>(sectors);
            return dtos;
        }

        public IEnumerable<StockPrice> GetSectorStockPrice(string name, DateTime fromDt, DateTime toDt, string period)
        {
            var stocks = repo.GetSectorStockPrice(name, fromDt, toDt, period);
          
            return stocks;
        }

    }
}
