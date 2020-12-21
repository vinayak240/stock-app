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

        public IEnumerable<StockPrice> GetSectorStockPrice(string  name, DateTime fromDt, DateTime toDt, string period)
        {

            var codes = context.Companies.Where(com => com.SectorName == name).Select(com => com.CompanyCode).ToList();

            var query = context.StockPrices.Where(stk => codes.Contains(stk.CompanyCode));

            //var stkList = new List<StockPrice>();
             query = from obj in query
                        where obj.Date.Date >= fromDt.Date && obj.Date.Date <= toDt.Date
                        select obj;

            //switch (period)
            //{
            //    case "daily":
            //        if (fromDt.Day == toDt.Day && fromDt.Month == toDt.Month && fromDt.Year == toDt.Year)
            //        {
            //            float total = query.ToList().Select(price => price.Price).Average();

            //            stkList.Add(new StockPrice() { Price = total, Date = toDt, ID = 0 });

            //            return stkList;
            //        }

            //        DateTime dt3 = fromDt;
            //        int i3 = 0;
            //        while (dt3.Date <= toDt.Date)
            //        {
            //            DateTime curDt = dt3;
            //            DateTime prevDt = dt3.AddDays(-1);
            //            var subquery = from obj in query.ToList()
            //                           where obj.Date.Date > prevDt.Date && obj.Date.Date <= new DateTime(curDt.Year, curDt.Month, curDt.Day, 23, 59, 59, 999)
            //                           select obj;
            //            if (subquery.ToList().Count > 0)
            //            {
            //                float total = subquery.Select(price => price.Price).Average();

            //                stkList.Add(new StockPrice() { Price = total, Date = curDt, ID = i3 });
            //                //take average of all the stck prices the subquery...
            //            }

            //            i3++;
            //            dt3 = dt3.AddDays(i3);


            //            if (dt3.Date > toDt.Date)
            //            {
            //                subquery = from obj in query.ToList()
            //                           where obj.Date.Date > new DateTime(curDt.Year, curDt.Month, curDt.Day, 23, 59, 59, 999) && obj.Date.Date <= toDt.Date
            //                           select obj;
            //                if (subquery.ToList().Count > 0)
            //                {
            //                    float total = subquery.Select(price => price.Price).Average();

            //                    stkList.Add(new StockPrice() { Price = total, Date = toDt, ID = i3 });
            //                }
            //            }

            //        }

            //        break;
            //    case "monthly":

            //        DateTime dt1 = fromDt;
            //        int i2 = 0;
            //        if (fromDt.Month == toDt.Month && fromDt.Year == toDt.Year)
            //        {
            //            float total = query.ToList().Select(price => price.Price).Average();

            //            stkList.Add(new StockPrice() { Price = total, Date = toDt, ID = 0 });
            //            return stkList;
            //        }
            //        while (dt1.Date <= toDt.Date)
            //        {
            //            DateTime curDt = dt1;
            //            DateTime prevDt = dt1.AddDays(-1);
            //            var subquery = from obj in query.ToList()
            //                           where obj.Date.Date > prevDt.Date && obj.Date.Date <= new DateTime(curDt.Year, curDt.Month, DateTime.DaysInMonth(curDt.Year, curDt.Month))
            //                           select obj;
            //            if (subquery.ToList().Count > 0)
            //            {
            //                float total = subquery.Select(price => price.Price).Average();

            //                stkList.Add(new StockPrice() { Price = total, Date = curDt, ID = i2 });
            //            }
            //            //take average of all the stck prices the subquery...
            //            i2++;
            //            dt1 = dt1.AddMonths(i2);


            //            if (dt1 > toDt)
            //            {

            //                subquery = from obj in query.ToList()
            //                           where obj.Date.Date > new DateTime(curDt.Year, curDt.Month, DateTime.DaysInMonth(curDt.Year, curDt.Month)) && obj.Date.Date <= toDt.Date
            //                           select obj;
            //                if (subquery.ToList().Count > 0)
            //                {
            //                    float total = subquery.Select(price => price.Price).Average();

            //                    stkList.Add(new StockPrice() { Price = total, Date = toDt, ID = i2 });
            //                }
            //            }

            //        }
            //        break;
            //    case "yearly":
            //        DateTime dt2 = fromDt;
            //        int i1 = 0;

            //        if (fromDt.Year == toDt.Year)
            //        {
            //            float total = query.ToList().Select(price => price.Price).Average();

            //            stkList.Add(new StockPrice() { Price = total, Date = toDt, ID = 0 });
            //            return stkList;
            //        }


            //        while (dt2.Date <= toDt.Date)
            //        {
            //            DateTime curDt = dt2;
            //            DateTime prevDt = dt2.AddDays(-1);
            //            var subquery = from obj in query.ToList()
            //                           where obj.Date.Date > prevDt.Date && obj.Date.Date <= new DateTime(curDt.Year, 12, 31)
            //                           select obj;
            //            if (subquery.ToList().Count > 0)
            //            {
            //                float total = subquery.Select(price => price.Price).Average();

            //                stkList.Add(new StockPrice() { Price = total, Date = curDt, ID = i1 });
            //            }
            //            //take average of all the stck prices the subquery...
            //            i1++;
            //            dt2 = dt2.AddYears(i1);

            //            if (dt2.Date > toDt.Date)
            //            {
            //                subquery = from obj in query.ToList()
            //                           where obj.Date.Date > new DateTime(curDt.Year, 12, 31) && obj.Date.Date <= toDt.Date
            //                           select obj;
            //                if (subquery.ToList().Count > 0)
            //                {
            //                    float total = subquery.Select(price => price.Price).Average();

            //                    stkList.Add(new StockPrice() { Price = total, Date = toDt, ID = i1 });
            //                }
            //            }
            //        }
            //        break;
            //}

            return query.ToList();
        }
    }
}
