using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockExchangeService.DataContext
{
    public class StockExchangeDbContext : DbContext
    {
        public StockExchangeDbContext(DbContextOptions<StockExchangeDbContext> options) : base(options)
        {

        }

        public DbSet<Entities.Company> Companies { get; set; }
        public DbSet<Entities.StockExchange> StockExchanges { get; set; }
    }
}
