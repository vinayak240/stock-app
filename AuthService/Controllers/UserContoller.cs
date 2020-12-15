using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AuthService.Domain;
using AuthService.Domain.Contracts;
using AuthService.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AuthService.Controllers
{
    [Route("api.auth/user")]
    [ApiController]
    public class UserContoller : ControllerBase
    {
        readonly IUserRepository repo;
        readonly IConfiguration configuration;

        public UserContoller(IUserRepository repo, IConfiguration configuration)
        {
            this.repo = repo;
            this.configuration = configuration;
        }

        [HttpGet("{username}")]
        public IActionResult GetUser(string username)
        {
            var Obj = repo.GetUserDetails(username);
            if (Obj == null)
                return NotFound();

            return Ok(Obj);
        }


        // POST api/<UserContoller>
        [Route("signup")]
        [HttpPost]
        public IActionResult SignUp([FromBody] User user)
        {
            var obj = repo.GetUserDetails(user.Username);
            if (obj != null)
            {
                return BadRequest("User Already Exists");
            }
            user.UserType = "normal";
            var result = repo.AddUser(user);
            if (!result)
                return BadRequest("Error saving User");

            return Created("No URL", GenerateJwtToken(user.Username)); ;
        }
        [Route("login")]
        [HttpPost]
        public IActionResult Login([FromBody] User user)
        {
            var obj = repo.GetUserDetails(user.Username);

            if (obj == null)
            {
                return Unauthorized("User Doesn't Exist");
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
                new Claim("UserType", "normal")
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
                token = new JwtSecurityTokenHandler().WriteToken(token)
            };
            return response;
        }

        // PUT api/<UserContoller>/5
        [HttpPut("{username}")]
        public IActionResult Put(string username, [FromBody] User obj)
        {
            if (obj == null)
                return BadRequest("User is required");

            var com = repo.GetUserDetails(obj.Username);

            if (com == null)
                return NotFound();

            var result = repo.UpdateUser(obj);
            if (result)
                return Ok();
            else
                return BadRequest("Update failed");
        }

        // DELETE api/<UserContoller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
