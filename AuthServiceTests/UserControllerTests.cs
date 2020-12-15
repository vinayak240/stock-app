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
    class UserControllerTests
    {
        UserContoller Uc;
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
            Uc = new UserContoller(ObjRepository, ObjConfiguration);
        }
        [Test]
        public void RegisterUserTest_ForSuccessStatusCode()
        {
            var user = new User()
            {
               Username = "test-user",
               Password = "test",
               Email = "test@e.com",
               UserType = "normal",
               Confirmed = false
            };
            var Result = Uc.SignUp(user) as ObjectResult;
            Assert.AreEqual(201, Result.StatusCode.Value);
        }

        [Test]
        public void LoginUserTest_ForSuccessStatusCode()
        {
            var user = new User()
            {
                Username = "test-user",
                Password = "test",
               
            };
            var Result = Uc.Login(user) as ObjectResult;
            Assert.AreEqual(200, Result.StatusCode.Value);
        }

        [Test]
        public void GetUserDetailsTest_ForSuccessStatusCode()
        {
            var Result = Uc.GetUser("test-user") as ObjectResult;
            Assert.AreEqual(200, Result.StatusCode.Value);
        }
    }
}
