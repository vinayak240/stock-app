using SectorService.Dtos;
using SectorService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SectorService.Domain.Contracts
{
    public interface ISectorService
    {
        IEnumerable<SectorDto> GetSectors();
        SectorDto GetSector(int id);
        bool AddSectors(SectorDto sector);
        public IEnumerable<StockPrice> GetSectorStockPrice(string name, DateTime fromDt, DateTime toDt, string period);
        IEnumerable<Company> GetSectorCompanies(string name);
    }
}
