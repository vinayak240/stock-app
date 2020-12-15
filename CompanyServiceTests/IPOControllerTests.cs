using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using CompanyService.Controllers;
using CompanyService.Domain.Contracts;
//using CompanyService.Domain.Services;
using CompanyService.Domain.Repositories;
using CompanyService.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using CompanyService.Entities;
using AutoMapper;
using CompanyService.AutoMapperProfiles;
using CompanyService.Domain.Services;
using CompanyService.Dtos;

namespace CompanyServiceTests
{
    [TestFixture]
    class IPOControllerTests
    {
        IPOController Ic;
        IIPORepository repo;

        [OneTimeSetUp]
        public void Initialize()
        {
            IConfiguration ObjConfiguration = new ConfigurationBuilder()
                                               .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                               .AddJsonFile("appsettings.json")
                                               .Build();
            string str = ObjConfiguration.GetConnectionString("MySqlConstr");
            DbContextOptions<CompanyDbContext> options = new DbContextOptionsBuilder<CompanyDbContext>().UseMySQL(str).Options;
            CompanyDbContext ObjContext = new CompanyDbContext(options);
            IIPORepository ObjRepository = new IPORepository(ObjContext);
            repo = new IPORepository(ObjContext);
            Mapper ObjMapper = new Mapper(new MapperConfiguration(config =>
            {
                config.AddProfile(new IPODtoProfile());
            }));

            IIPOService ObjService = new IPOService(ObjRepository, ObjMapper);
            Ic = new IPOController(ObjService);
        }
        [Test]
        public void AddCompanyTest_ForSuccessStatusCode()
        {
            var ipo = new IPODto()
            {
                CompanyCode = "Com1",
                CompanyName = "Test Company",
                PricePerShare = 123,
                StockExchange = "BSE",
                TotalShares = 10000,
                OpenDate = new DateTime(2019, 01, 01, 12, 35, 00, 000),
                Remarks= "No Remarks"
            };
            var Result = Ic.AddIPO(ipo) as ObjectResult;
            Assert.AreEqual(201, Result.StatusCode.GetValueOrDefault());
        }
    }
}
