using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using AuthService.Controllers;
using AuthService.Domain.Contracts;
//using AuthService.Domain.Services;
using AuthService.Domain.Repositories;
using AuthService.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using AuthService.Entities;
namespace AuthServiceTests
{
    [TestFixture]
    class AdminControllerTests
    {

        AdminController Ac;
        [OneTimeSetUp]
        public void Initialize()
        {
            IConfiguration ObjConfiguration = new ConfigurationBuilder()
                                               .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                               .AddJsonFile("appsettings.json")
                                               .Build();
            string str = ObjConfiguration.GetConnectionString("MySqlConstr");
            DbContextOptions<UserDbContext> options = new DbContextOptionsBuilder<UserDbContext>().UseMySQL(str).Options;
            UserDbContext ObjContext = new UserDbContext(options);
            IUserRepository ObjRepository = new UserRepository(ObjContext);
            Ac = new AdminController(ObjRepository, ObjConfiguration);
        }

        [Test]
        public void RegisterAdminTest_ForSuccessStatusCode()
        {
            var user = new User()
            {
                Username = "admin-test",
                Password = "test",
                Email = "test-admin@e.com",
                UserType = "admin",
                Confirmed = false
            };
            var Result = Ac.SignUp(user) as ObjectResult;
            Assert.AreEqual(201, Result.StatusCode.Value);
        }

        [Test]
        public void LoginAdminTest_ForSuccessStatusCode()
        {
            var user = new User()
            {
                Username = "admin-test",
                Password = "test",

            };
            var Result = Ac.Login(user) as ObjectResult;
            Assert.AreEqual(200, Result.StatusCode.Value);
        }

    }
}
