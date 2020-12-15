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
    public class StockPriceService : IStockPriceService
    {
        readonly IStockPriceRepository repo;
        readonly IMapper mapper;
        public StockPriceService(IStockPriceRepository repository, IMapper mapper)
        {
            this.repo = repository;
            this.mapper = mapper;
        }
        public bool AddStockPrice(StockPriceDto price)
        {
            var obj = mapper.Map<StockPrice>(price);
            return repo.AddStockPrice(obj);
        }

        public bool DeleteStockPrice(int id)
        {
            return repo.DeleteStockPrice(id);
        }

        public StockPriceDto GetStockPrice(int id)
        {
            var Obj = repo.GetStockPrice(id);
            var Dto = mapper.Map<StockPriceDto>(Obj);
            return Dto;
        }

        public bool UpdateStockPrice(StockPriceDto price)
        {
            var stock = mapper.Map<StockPrice>(price);
            var result = repo.UpdateStockPrice(stock);

            return result;
        }
    }
}
