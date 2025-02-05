﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AuthService.Domain;
using AuthService.Domain.Contracts;
using AuthService.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AuthService.Controllers
{
    [Route("api.auth/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        readonly IUserRepository repo;
        readonly IConfiguration configuration;

        public AdminController(IUserRepository repo, IConfiguration configuration)
        {
            this.repo = repo;
            this.configuration = configuration;
        }

        // POST api/<UserContoller>
        [Route("signup")]
        [HttpPost]
        public IActionResult SignUp([FromBody] User user)
        {
            var obj = repo.GetUserDetails(user.Username);
            if (obj != null)
            {
                return BadRequest("Admin Already Exists");
            }
            user.UserType = "admin";
            user.Confirmed = false;
            var result = repo.AddUser(user);
            if (!result)
                return BadRequest("Error saving Admin");

            return Created("No Url", GenerateJwtToken(user.Username));
        }
        [Route("login")]
        [HttpPost]
        public IActionResult Login([FromBody] User user)
        {
            var obj = repo.GetUserDetails(user.Username);

            if (obj == null)
            {
                return Unauthorized("Admin Doesn't Exist");
            }

            if (obj.Password == user.Password)
                return Ok(GenerateJwtToken(user.Username));
            else
                return Unauthorized("Incorrect Password!");

        }

        private Token GenerateJwtToken(string uname)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, uname),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, uname),
                new Claim(ClaimTypes.Role,uname),
                new Claim("UserType", "admin")
            };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            // recommended is 5 min
            var expires = DateTime.Now.AddDays(Convert.ToDouble(configuration["JwtExpireDays"]));
            var token = new JwtSecurityToken(
                configuration["JwtIssuer"],
                configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: credentials
            );

            var response = new Token
            {
                uname = uname,
                userType = "admin",
                token = new JwtSecurityTokenHandler().WriteToken(token)
            };
            return response;
        }
    }
}
