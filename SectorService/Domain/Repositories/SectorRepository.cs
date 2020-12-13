using SectorService.DataContext;
using SectorService.Domain.Contracts;
using SectorService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SectorService.Domain.Repositories
{
    public class SectorRepository : ISectorRepository
    {
        readonly SectorDbContext context;
        public SectorRepository(SectorDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Sector> GetSectors()
        {
            var query = from obj in context.Sectors
                        orderby obj.Name
                        select obj;
            return query.ToList();
        }

        public Sector GetSector(int id)
        {
            var sector = context.Sectors.Find(id);
            return sector;
        }

        public bool AddSectors(Sector sector)
        {
            context.Sectors.Add(sector);
            int RowsAdded = context.SaveChanges();
            return RowsAdded > 0;
        }

        public IEnumerable<Company> GetSectorCompanies(string name)
        {
            var query = context.Companies.Where(com => com.SectorName == name);
            return query.ToList();
        }
    }
}
