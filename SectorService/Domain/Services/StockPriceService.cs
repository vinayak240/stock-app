using SectorService.Domain.Contracts;
using SectorService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SectorService.Domain.Services
{
    public class StockPriceService : IStockPriceService
    {
        readonly IStockPriceRepository repo;

        public StockPriceService(IStockPriceRepository repo)
        {
            this.repo = repo;
        }

        public bool AddStockPrice(StockPrice price)
        {
            bool res = repo.AddStockPrice(price);
            return res;
        }

        public bool DeleteStockPrice(int id)
        {
            bool res = repo.DeleteStockPrice(id);
            return res;
        }

        public StockPrice GetStockPrice(int id)
        {
            StockPrice price = repo.GetStockPrice(id);
            return price;
        }

        public bool UpdateStockPrice(StockPrice price)
        {
            bool res = repo.UpdateStockPrice(price);
            return res;
        }
    }
}
