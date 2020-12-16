using AutoMapper;
using StockExchangeService.Domain.Contracts;
using StockExchangeService.Dtos;
using StockExchangeService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockExchangeService.Domain.Services
{
    public class StockExchangeService : IStockExchangeService
    {
        readonly IStockExchangeRepository repo;
        readonly IMapper mapper;
        public StockExchangeService(IStockExchangeRepository repository, IMapper mapper)
        {
            this.repo = repository;
            this.mapper = mapper;
        }
        public bool AddStockExchange(StockExchangeDto stockexchange)
        {
            var obj = mapper.Map<StockExchange>(stockexchange);
            return repo.AddStockExchange(obj);
        }

        public IEnumerable<Company> GetStockExchangeCompanies(string name)
        {
            return repo.GetStockExchangeCompanies(name);
        }

        public IEnumerable<StockExchangeDto> GetStockExchanges()
        {
            var sectors = repo.GetStockExchanges();
            var dtos = mapper.Map<IEnumerable<StockExchangeDto>>(sectors);
            return dtos;
        }
    }
}
