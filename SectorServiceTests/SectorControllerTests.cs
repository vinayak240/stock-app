using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using SectorService.Controllers;
using SectorService.Domain.Contracts;
//using SectorService.Domain.Services;
using SectorService.Domain.Repositories;
using SectorService.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using SectorService.Entities;
using AutoMapper;
using SectorService.AutoMapperProfiles;
using SectorService.Domain.Services;
using SectorService.Dtos;

namespace SectorServiceTests
{
    [TestFixture]
    class SectorControllerTests
    {
        SectorController Sc;
        [OneTimeSetUp]
        public void Initialize()
        {
            IConfiguration ObjConfiguration = new ConfigurationBuilder()
                                               .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                               .AddJsonFile("appsettings.json")
                                               .Build();
            string str = ObjConfiguration.GetConnectionString("MySqlConstr");
            DbContextOptions<SectorDbContext> options = new DbContextOptionsBuilder<SectorDbContext>().UseMySQL(str).Options;
            SectorDbContext ObjContext = new SectorDbContext(options);
            ISectorRepository ObjRepository = new SectorRepository(ObjContext);
            
            Mapper ObjMapper = new Mapper(new MapperConfiguration(config =>
            {
                config.AddProfile(new SectorDtoProfile());
            }));

            ISectorService ObjService = new SectorService.Domain.Services.SectorService(ObjRepository, ObjMapper);
            Sc = new SectorController(ObjService);
        }

        [Test]
        public void GetSectoesTest_ForSuccessStatusCode()
        {
            var Result = Sc.Get() as ObjectResult;
            Assert.AreEqual(200, Result.StatusCode.Value);
        }

        [Test]
        public void GetByIdTest_ForSuccessStatusCode()
        {
            var Result = Sc.GetById(1) as ObjectResult;
            Assert.AreEqual(200, Result.StatusCode.Value);
        }

        [Test]
        public void GetSectorCompaniesTest_ForSuccessStatusCode()
        {
            var Result = Sc.GetCompanyList("Finance") as ObjectResult;
            Assert.AreEqual(200, Result.StatusCode.Value);
        }

        [Test]
        public void AddSectorTest_ForSuccessStatusCode()
        {
            var sector = new SectorDto()
            {
               Name="Test Sector",
               Description="This is a Test Sector"
            };
            var Result = Sc.Post(sector) as ObjectResult;
            // var res = repo.GetCompany("test-com5");
            //Assert.AreEqual("test-com5", res.CompanyCode);

            Assert.AreEqual(201, Result.StatusCode.Value);
        }


    }
}
