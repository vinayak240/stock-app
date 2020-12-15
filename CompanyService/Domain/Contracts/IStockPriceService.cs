using CompanyService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyService.Domain.Contracts
{
    public interface IStockPriceService
    {
        bool AddStockPrice(StockPriceDto price);
        bool DeleteStockPrice(int id);
        StockPriceDto GetStockPrice(int id);
        bool UpdateStockPrice(StockPriceDto price);
    }
}
