using CompanyService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyService.Domain.Contracts
{
    public interface ICompanyService
    {
        IEnumerable<CompanyDto> GetCompanies();
        CompanyDto GetCompany(string code);
        bool AddCompany(CompanyDto company);
        bool UpdateCompany(CompanyDto company);
        bool DeleteCompany(string code);
        IEnumerable<IPODto> GetCompanyIPODetails(string code);
        IEnumerable<CompanyDto> GetMatchingCompanies(string filter);
        IEnumerable<StockPriceDto> GetCompanyStockPrice(string code, DateTime fromDt, DateTime toDt, string period);
    }
}
