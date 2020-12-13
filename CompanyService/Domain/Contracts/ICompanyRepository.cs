using CompanyService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyService.Domain.Contracts
{
    public interface ICompanyRepository
    {
        IEnumerable<Company> GetCompanies();
        Company GetCompany(string code);
        bool AddCompany(Company company);
        bool UpdateCompany(Company company);
        bool DeleteCompany(string code);
        IEnumerable<IPO> GetCompanyIPODetails(string code);
        IEnumerable<Company> GetMatchingCompanies(string filter);
        IEnumerable<StockPrice> GetCompanyStockPrice(string code, DateTime fromDt, DateTime toDt, string period);
    }
}
