using StockExchangeService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockExchangeService.Domain.Contracts
{
    public interface IStockExchangeRepository
    {
        IEnumerable<StockExchange> GetStockExchanges();
        bool AddStockExchange(StockExchange stockexchange);
        IEnumerable<Company> GetStockExchangeCompanies(string name);
    }
}
