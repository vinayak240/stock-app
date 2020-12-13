using StockExchangeService.DataContext;
using StockExchangeService.Domain.Contracts;
using StockExchangeService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockExchangeService.Domain.Repositories
{
    public class StockExchangeRepository : IStockExchangeRepository
    {
        readonly StockExchangeDbContext context;
        public delegate bool mCheck(string str, string name);
        public StockExchangeRepository(StockExchangeDbContext ctx)
        {
            context = ctx;
        }

        public bool AddStockExchange(StockExchange stockexchange)
        {
            context.StockExchanges.Add(stockexchange);
            int RowsAdded = context.SaveChanges();
            return RowsAdded > 0;
        }

        public IEnumerable<Company> GetStockExchangeCompanies(string name)
        { 
            mCheck func = delegate (string str, string name)
           {
               return str.Split(',').ToList().Contains(name);
           };
           var query = context.Companies.Where(com => func(com.StockExchanges, name));
         
           return query.ToList();
        }

        public IEnumerable<StockExchange> GetStockExchanges()
        {
            var query = from obj in context.StockExchanges
                        orderby obj.Name
                        select obj;
            return query.ToList();
        }
    }
}
