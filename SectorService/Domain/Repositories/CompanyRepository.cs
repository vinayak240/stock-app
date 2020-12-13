using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SectorService.DataContext;
using SectorService.Domain.Contracts;
using SectorService.Entities;

namespace SectorService.Domain.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        readonly SectorDbContext context;
        public CompanyRepository(SectorDbContext ctx)
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
            Obj.SectorName = company.SectorName;
            int RowsAffected = context.SaveChanges();
            return RowsAffected > 0;
        }
    }
}
