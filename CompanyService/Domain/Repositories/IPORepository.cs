using CompanyService.DataContext;
using CompanyService.Domain.Contracts;
using CompanyService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyService.Domain.Repositories
{
    public class IPORepository : IIPORepository
    {
        readonly CompanyDbContext context;
        public IPORepository(CompanyDbContext ctx)
        {
            context = ctx;
        }

        public bool AddIPO(IPO ipo)
        {
            context.Ipos.Add(ipo);
            int RowsAdded = context.SaveChanges();
            return RowsAdded > 0;
        }
    }
}
