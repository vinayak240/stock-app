using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyService.DataContext
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options) : base(options)
        {
           
        }

        public DbSet<Entities.Company> Companies { get; set; }
        public DbSet<Entities.StockPrice> StockPrices { get; set; }
        public DbSet<Entities.IPO> Ipos { get; set; }

    }
}
