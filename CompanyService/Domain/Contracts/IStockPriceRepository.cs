using CompanyService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyService.Domain.Contracts
{
    public interface IStockPriceRepository
    {
        bool AddStockPrice(StockPrice price);
        bool DeleteStockPrice(int id);
        StockPrice GetStockPrice(int id);
        bool UpdateStockPrice(StockPrice price);
    }
}
