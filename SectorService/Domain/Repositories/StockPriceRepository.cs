﻿using SectorService.DataContext;
using SectorService.Domain.Contracts;
using SectorService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SectorService.Domain.Repositories
{
    public class StockPriceRepository : IStockPriceRepository
    {
        readonly SectorDbContext context;
        public StockPriceRepository(SectorDbContext ctx)
        {
            context = ctx;
        }
        public bool AddStockPrice(StockPrice price)
        {
            context.StockPrices.Add(price);
            int RowsAdded = context.SaveChanges();
            return RowsAdded > 0;
        }

        public bool DeleteStockPrice(int id)
        {
            var Obj = GetStockPrice(id);

            context.StockPrices.Remove(Obj);
            int RowsDeleted = context.SaveChanges();
            return RowsDeleted > 0;
        }

        public StockPrice GetStockPrice(int id)
        {
            var price = context.StockPrices.Find(id);
            return price;
        }

        public bool UpdateStockPrice(StockPrice price)
        {
            var Obj = GetStockPrice(price.ID);
            Obj.Price = price.Price;
            Obj.StockExchange = price.StockExchange;
            Obj.Date = price.Date;
            Obj.CompanyCode = price.CompanyCode;
            int RowsAffected = context.SaveChanges();
            return RowsAffected > 0;
        }

    }
}
