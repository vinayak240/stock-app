using SectorService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SectorService.Domain.Contracts
{
    public interface ICompanyRepository
    {

        Company GetCompany(string code);
        bool AddCompany(Company company);
        bool UpdateCompany(Company company);
        bool DeleteCompany(string code);
       // public IEnumerable<StockPrice> GetCompanyStockPrice(string code, DateTime fromDt, DateTime toDt, string period);
    }
}
