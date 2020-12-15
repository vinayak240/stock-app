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
using CompanyService.Dtos;
//using WebApiDemo.Dtos;

namespace CompanyServiceTests
{
    [TestFixture]
    class CompanyControllerTests
    {
        CompanyController Cs;
        ICompanyRepository repo;
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
            ICompanyRepository ObjRepository = new CompanyRepository(ObjContext);
            repo = new CompanyRepository(ObjContext);
            Mapper ObjMapper = new Mapper(new MapperConfiguration(config =>
            {
                config.AddProfile(new CompanyDtoProfile());
            }));

            ICompanyService ObjService = new CompanyService.Domain.Services.CompanyService(ObjRepository, ObjMapper);
            Cs = new CompanyController(ObjService);
        }

        [Test]
        public void GetCompaniesTest_ForSuccessStatusCode()
        {
            var Result = Cs.Get() as ObjectResult;
            Assert.AreEqual(200, Result.StatusCode.Value);
        }

        [Test]
        public void GetByIdTest_ForSuccessStatusCode()
        {
            var Result = Cs.GetById("Com1") as ObjectResult;
            Assert.AreEqual(200, Result.StatusCode.Value);
        }

        [Test]
        public void GetMatchingCompaniesTest_ForSuccessStatusCode()
        {
            var Result = Cs.GetMatching("Com") as ObjectResult;
            Assert.AreEqual(200, Result.StatusCode.Value);
        }
        
        [Test]
        public void GetCompanyIPODetailsTest_ForSuccessStatusCode()
        {
            var Result = Cs.GetCompanyIPODetails("Com1") as ObjectResult;
            Assert.AreEqual(200, Result.StatusCode.Value);
        }

        [Test]
        public void GetCompanyStockPriceTest_ForSuccessStatusCode()
        {
            var Result = Cs.GetCompanyStockPrice("Com1", new DateTime(2019, 01, 01, 12, 30, 00, 000), new DateTime(2019, 01, 04, 16, 30, 00, 000), "daily") as ObjectResult;
            Assert.AreEqual(200, Result.StatusCode.Value);
        }

        [Test]


        public void AddCompanyTest_ForSuccessStatusCode()
        {
            var com = new CompanyDto()
            {
                CompanyCode = "test-com6",
                BoardOfDirectors = "ABC,DEC,BFG",
                CEO = "ABC",
                Description = "Demo Test Company",
                Name="Test Company",
                SectorName="Finance",
                StockExchanges="BSE",
                Turnover=10000
            };
            var Result = Cs.AddCompany(com) as ObjectResult;
            // var res = repo.GetCompany("test-com5");
            //Assert.AreEqual("test-com5", res.CompanyCode);

            Assert.AreEqual(201, Result.StatusCode.Value);
        }

        [Test]
        public void UpdateCompanyTest_ForSuccessStatusCode()
        {
            CompanyDto com = new CompanyDto()
            {
                CompanyCode = "test-com6",
                BoardOfDirectors = "ABC,DEC,BFG",
                CEO = "ABCUpdated",
                Description = "Demo Test Company",
                Name = "Test Company Updated",
                SectorName = "Finance",
                StockExchanges = "BSE,NSE",
                Turnover = 120000
            };
            var Result = Cs.UpdateCompany("test-com6", com) as ObjectResult;
            //var res = repo.GetCompany("test-com1");
            //Assert.AreEqual("ABCUpdated",res.CEO);

            Assert.AreEqual(200, Result.StatusCode.Value);
        }

        //[Test]
        //public void DeleteCompanyTest_ForSuccessStatusCode()
        //{
        //    var Result = Cs.Delete("test-com6") as ObjectResult;
        //    //var res = repo.Get
        //    Assert.AreEqual(204, Result.StatusCode.Value);
        //}



    }
}


