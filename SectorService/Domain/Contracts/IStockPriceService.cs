using SectorService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SectorService.Domain.Contracts
{
    public interface IStockPriceService
    {
        bool AddStockPrice(StockPrice price);
        bool DeleteStockPrice(int id);
        StockPrice GetStockPrice(int id);
        bool UpdateStockPrice(StockPrice price);
    }
}
