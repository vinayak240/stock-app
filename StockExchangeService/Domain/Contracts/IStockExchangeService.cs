using StockExchangeService.Dtos;
using StockExchangeService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockExchangeService.Domain.Contracts
{
    public interface IStockExchangeService
    {
        IEnumerable<StockExchangeDto> GetStockExchanges();
        bool AddStockExchange(StockExchangeDto stockexchange);
        IEnumerable<Company> GetStockExchangeCompanies(string name);
    }
}
