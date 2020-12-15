using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using StockExchangeService.Controllers;
using StockExchangeService.Domain.Contracts;
//using StockExchangeService.Domain.Services;
using StockExchangeService.Domain.Repositories;
using StockExchangeService.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using StockExchangeService.Entities;

namespace StockExchangeServiceTests
{
    [TestFixture]
    class StockExchangeControllerTests
    {
        StockExchangeController Stc;
        [OneTimeSetUp]
        public void Initialize()
        {
            IConfiguration ObjConfiguration = new ConfigurationBuilder()
                                               .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                               .AddJsonFile("appsettings.json")
                                               .Build();
            string str = ObjConfiguration.GetConnectionString("MySqlConstr");
            DbContextOptions<StockExchangeDbContext> options = new DbContextOptionsBuilder<StockExchangeDbContext>().UseMySQL(str).Options;
            StockExchangeDbContext ObjContext = new StockExchangeDbContext(options);
            IStockExchangeRepository ObjRepository = new StockExchangeRepository(ObjContext);
            Stc = new StockExchangeController(ObjRepository);
        }

        [Test]
        public void GetStockExchangesTest_ForSuccessStatusCode()
        {
            var Result = Stc.Get() as ObjectResult;
            Assert.AreEqual(200, Result.StatusCode.Value);
        }

        [Test]
        public void GetStockExchangeCompaniesTest_ForSuccessStatusCode()
        {
            var Result = Stc.GetStockExchangeCompanies("BSE") as ObjectResult;
            Assert.AreEqual(200, Result.StatusCode.Value);
        }

        [Test]
        public void AddStockExchangeTest_ForSuccessStatusCode()
        {
            var exchange = new StockExchange()
            {
                Name = "Test Exchange",
                Description = "This is a Test Sector",
                Address= "Mumbai",
                Remarks= "No Remarks"
            };
            var Result = Stc.Post(exchange) as ObjectResult;
            Assert.AreEqual(201, Result.StatusCode.Value);
        }

    }
}
