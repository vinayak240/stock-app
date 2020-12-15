using AutoMapper;
using CompanyService.Domain.Contracts;
using CompanyService.Dtos;
using CompanyService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyService.Domain.Services
{
    public class CompanyService : ICompanyService
    {
        readonly ICompanyRepository repo;
        readonly IMapper mapper;
        public CompanyService(ICompanyRepository repository, IMapper mapper)
        {
            this.repo = repository;
            this.mapper = mapper;
        }

        public bool AddCompany(CompanyDto company)
        {
            var obj = mapper.Map<Company>(company);
            return repo.AddCompany(obj);
        }

        public bool DeleteCompany(string code)
        {
            return repo.DeleteCompany(code);
        }

        public IEnumerable<CompanyDto> GetCompanies()
        {
            var companies = repo.GetCompanies();
            var dtos = mapper.Map<IEnumerable<CompanyDto>>(companies);
            return dtos;
        }

        public CompanyDto GetCompany(string code)
        {
            var Obj = repo.GetCompany(code);
            var Dto = mapper.Map<CompanyDto>(Obj);
            return Dto;
        }

        public IEnumerable<IPODto> GetCompanyIPODetails(string code)
        {
            var ipos = repo.GetCompanyIPODetails(code);
            var dtos = mapper.Map<IEnumerable<IPODto>>(ipos);
            return dtos;
        }

        public IEnumerable<StockPriceDto> GetCompanyStockPrice(string code, DateTime fromDt, DateTime toDt, string period)
        {
            var stocks = repo.GetCompanyStockPrice(code, fromDt, toDt, period);
            var dtos = mapper.Map<IEnumerable<StockPriceDto>>(stocks);
            return dtos;
        }

        public IEnumerable<CompanyDto> GetMatchingCompanies(string filter)
        {
            var companies = repo.GetMatchingCompanies(filter);
            var dtos = mapper.Map<IEnumerable<CompanyDto>>(companies);
            return dtos;
        }

        public bool UpdateCompany(CompanyDto company)
        {
            var com = mapper.Map<Company>(company);
            var result = repo.UpdateCompany(com);

            return result;
        }
    }
}
