using StockExchangeService.Domain.Contracts;
using StockExchangeService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockExchangeService.Domain.Services
{
        public class CompanyService : ICompanyService
        {
            readonly ICompanyRepository repo;

            public CompanyService(ICompanyRepository repo)
            {
                this.repo = repo;
            }

            public bool AddCompany(Company company)
            {
                bool res = repo.AddCompany(company);
                return res;
            }

            public bool DeleteCompany(string code)
            {
                bool result = repo.DeleteCompany(code);
                return result;
            }

            public Company GetCompany(string code)
            {
                var company = repo.GetCompany(code);
                return company;
            }

            public bool UpdateCompany(Company company)
            {
                bool res = repo.UpdateCompany(company);
                return res;
            }
        }
    }

