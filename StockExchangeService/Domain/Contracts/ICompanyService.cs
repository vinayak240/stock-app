using StockExchangeService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockExchangeService.Domain.Contracts
{
    public interface ICompanyService
    {
        Company GetCompany(string code);
        bool AddCompany(Company company);
        bool UpdateCompany(Company company);
        bool DeleteCompany(string code);
    }
}
