using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SectorService.DataContext
{
    public class SectorDbContext : DbContext
    {
        public SectorDbContext(DbContextOptions<SectorDbContext> options) : base(options)
        {

        }

        public DbSet<Entities.Company> Companies { get; set; }
        public DbSet<Entities.StockPrice> StockPrices { get; set; }
        public DbSet<Entities.Sector> Sectors { get; set; }

    }
}
