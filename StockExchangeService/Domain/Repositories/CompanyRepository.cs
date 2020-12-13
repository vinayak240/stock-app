using StockExchangeService.DataContext;
using StockExchangeService.Domain.Contracts;
using StockExchangeService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockExchangeService.Domain.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        readonly StockExchangeDbContext context;
        public CompanyRepository(StockExchangeDbContext ctx)
        {
            context = ctx;
        }
        public bool AddCompany(Company company)
        {
            context.Companies.Add(company);
            int RowsAdded = context.SaveChanges();
            return RowsAdded > 0;
        }

        public bool DeleteCompany(string code)
        {
            var Obj = GetCompany(code);
            context.Companies.Remove(Obj);
            int RowsDeleted = context.SaveChanges();
            return RowsDeleted > 0;
        }

        public Company GetCompany(string code)
        {
            var company = context.Companies.Find(code);
            return company;
        }

        public bool UpdateCompany(Company company)
        {
            var Obj = GetCompany(company.CompanyCode);
            Obj.Name = company.Name;
            Obj.Description = company.Description;
            Obj.StockExchanges = company.StockExchanges;
            int RowsAffected = context.SaveChanges();
            return RowsAffected > 0;
        }

    }
}
