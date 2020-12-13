using SectorService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SectorService.Domain.Contracts
{
    public interface ISectorRepository
    {
        IEnumerable<Sector> GetSectors();
        Sector GetSector(int id);
        bool AddSectors(Sector sector);
        //public IEnumerable<StockPrice> GetSectorStockPrice(int id, DateTime fromDt, DateTime toDt, string period);
        IEnumerable<Company> GetSectorCompanies(string name);
    }
}
