using CompanyService.DataContext;
using CompanyService.Domain.Contracts;
using CompanyService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyService.Domain.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        readonly CompanyDbContext context;
        public CompanyRepository(CompanyDbContext ctx)
        {
            context = ctx;
        }
        public bool AddCompany(Company company)
        {
            context.Companies.Add(company);
            int RowsAdded = context.SaveChanges();
            return RowsAdded > 0;
        }

        public bool DeleteCompany(string code)
        {
            var Obj = GetCompany(code);
            context.Companies.Remove(Obj);
            int RowsDeleted = context.SaveChanges();
            return RowsDeleted > 0;
        }

        public Company GetCompany(string code)
        {
            var company = context.Companies.Find(code);
            return company;
        }

        public IEnumerable<Company> GetCompanies()
        {
            var query = from obj in context.Companies
                        orderby obj.Name
                        select obj;
            return query.ToList();
        }

        public IEnumerable<Company> GetMatchingCompanies(string filter)
        {
            var query1 = context.Companies.Where(com => com.Name.StartsWith(filter));
            var query2 = context.Companies.Where(com => com.Name.Contains(filter));
            var query = query1.ToList().Concat(query2.ToList());
            return query;
        }



        public IEnumerable<IPO> GetCompanyIPODetails(string code)
        {
            var query = from obj in context.Ipos
                        where obj.CompanyCode == code
                        select obj;
            return query.ToList();
        }

        public IEnumerable<StockPrice> GetCompanyStockPrice(string code, DateTime fromDt, DateTime toDt, string period)
        {
            var stkList = new List<StockPrice>();
            var query = from obj in context.StockPrices
                        where obj.CompanyCode == code && obj.Date.Date >= fromDt.Date && obj.Date.Date <= toDt.Date
                        select obj;
            switch (period) {
                case "daily":
                    //DateTime dt = fromDt;
                    //int n = (toDt - fromDt).Days;


                    //for(int i=0; i < n; i++)
                    //{
                    //    dt = dt.AddDays(i);
                    //    var subquery = from obj in query.ToList()
                    //                   where obj.Date.Date <=dt.Date
                    //                   select obj;
                    //    float total = subquery.Select(price => price.Price).Average();

                    //    stkList.Add(new StockPrice() { Price = total, CompanyCode = code, Date = dt, ID = i }) ;
                    //    //take average of all the stck prices the subquery...

                    //}
                    if (fromDt.Day == toDt.Day && fromDt.Month == toDt.Month && fromDt.Year == toDt.Year)
                    {
                        float total = query.ToList().Select(price => price.Price).Average();

                        stkList.Add(new StockPrice() { Price = total, CompanyCode = code, Date = toDt, ID = 0 });

                        return stkList;
                    }

                    DateTime dt3 = fromDt;
                    int i3 = 0;
                    while (dt3.Date <= toDt.Date)
                    {
                        DateTime curDt = dt3;
                        DateTime prevDt = dt3.AddDays(-1);
                        var subquery = from obj in query.ToList()
                                       where obj.Date.Date > prevDt.Date && obj.Date.Date <= new DateTime(curDt.Year, curDt.Month, curDt.Day, 23,59,59,999)
                                       select obj;
                        if(subquery.ToList().Count > 0)
                        {
                            float total = subquery.Select(price => price.Price).Average();

                            stkList.Add(new StockPrice() { Price = total, CompanyCode = code, Date = curDt, ID = i3 });
                            //take average of all the stck prices the subquery...
                        }

                        i3++;
                        dt3 = dt3.AddDays(i3);


                        if (dt3.Date > toDt.Date)
                        {
                            subquery = from obj in query.ToList()
                                       where obj.Date.Date > new DateTime(curDt.Year, curDt.Month, curDt.Day, 23, 59, 59, 999) && obj.Date.Date <= toDt.Date
                                       select obj;
                            if (subquery.ToList().Count > 0)
                            {
                                float total = subquery.Select(price => price.Price).Average();

                                stkList.Add(new StockPrice() { Price = total, CompanyCode = code, Date = toDt, ID = i3 });
                            }
                        }

                    }

                    break;
                case "monthly":

                    DateTime dt1 = fromDt;
                    int i2 = 0;  
                    if(fromDt.Month == toDt.Month && fromDt.Year == toDt.Year)
                    {
                        float total = query.ToList().Select(price => price.Price).Average();

                        stkList.Add(new StockPrice() { Price = total, CompanyCode = code, Date = toDt, ID = 0 });
                        return stkList;
                    }
                    while(dt1.Date<=toDt.Date)
                    {
                        DateTime curDt = dt1;
                        DateTime prevDt = dt1.AddDays(-1);
                        var subquery = from obj in query.ToList()
                                       where obj.Date.Date > prevDt.Date && obj.Date.Date <= new DateTime(curDt.Year, curDt.Month, DateTime.DaysInMonth(curDt.Year, curDt.Month))
                                       select obj;
                        if (subquery.ToList().Count > 0)
                        {
                            float total = subquery.Select(price => price.Price).Average();

                            stkList.Add(new StockPrice() { Price = total, CompanyCode = code, Date = curDt, ID = i2 });
                        }
                        //take average of all the stck prices the subquery...
                        i2++;
                        dt1 = dt1.AddMonths(i2);
                        

                        if(dt1> toDt)
                        {

                             subquery = from obj in query.ToList()
                                           where obj.Date.Date > new DateTime(curDt.Year, curDt.Month, DateTime.DaysInMonth(curDt.Year, curDt.Month)) && obj.Date.Date <= toDt.Date
                                           select obj;
                            if (subquery.ToList().Count > 0)
                            {
                                float total = subquery.Select(price => price.Price).Average();

                                stkList.Add(new StockPrice() { Price = total, CompanyCode = code, Date = toDt, ID = i2 });
                            }
                        }

                    }
                    break;
                case "yearly":
                    DateTime dt2 = fromDt;
                    int i1 = 0;

                    if (fromDt.Year == toDt.Year)
                    {
                        float total = query.ToList().Select(price => price.Price).Average();

                        stkList.Add(new StockPrice() { Price = total, CompanyCode = code, Date = toDt, ID = 0 });
                        return stkList;
                    }


                    while (dt2.Date <= toDt.Date)
                    {
                        DateTime curDt = dt2;
                        DateTime prevDt = dt2.AddDays(-1);
                        var subquery = from obj in query.ToList()
                                       where obj.Date.Date > prevDt.Date && obj.Date.Date <= new DateTime(curDt.Year, 12, 31)
                                       select obj;
                        if (subquery.ToList().Count > 0)
                        {
                            float total = subquery.Select(price => price.Price).Average();

                            stkList.Add(new StockPrice() { Price = total, CompanyCode = code, Date = curDt, ID = i1 });
                        }
                        //take average of all the stck prices the subquery...
                        i1++;
                        dt2 = dt2.AddYears(i1);

                        if (dt2.Date > toDt.Date)
                        {
                            subquery = from obj in query.ToList()
                                       where obj.Date.Date > new DateTime(curDt.Year, 12, 31) && obj.Date.Date <= toDt.Date
                                       select obj;
                            if (subquery.ToList().Count > 0)
                            {
                                float total = subquery.Select(price => price.Price).Average();

                                stkList.Add(new StockPrice() { Price = total, CompanyCode = code, Date = toDt, ID = i1 });
                            }
                        }
                    }
                    break;
            }

            return stkList;
        }

        public bool UpdateCompany(Company company)
        {
            var Obj = GetCompany(company.CompanyCode);
            Obj.Name = company.Name;
            Obj.Description = company.Description;
            Obj.CEO = company.CEO;
            Obj.SectorName = company.SectorName;
            Obj.StockExchanges = company.StockExchanges;
            Obj.Turnover = company.Turnover;
            Obj.BoardOfDirectors = company.BoardOfDirectors;
            int RowsAffected = context.SaveChanges();
            return RowsAffected > 0;
        }

    }
}
