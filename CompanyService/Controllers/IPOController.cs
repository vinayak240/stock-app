using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyService.Domain.Contracts;
using CompanyService.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CompanyService.Controllers
{
    [Route("api/ipo")]
    [ApiController]
    public class IPOController : ControllerBase
    {
        readonly IIPORepository repo;

        public IPOController(IIPORepository repo)
        {
            this.repo = repo;
        }

        // POST api/ipo
        [HttpPost]
        public IActionResult AddIPO([FromBody] IPO ipo)
        {
            //string str = ipo.OpenDate.ToString();
            //ipo.OpenDate = DateTime.Parse(str);
            var result = repo.AddIPO(ipo);
            if (!result)
                return BadRequest("Error saving IPO");
            return StatusCode(201);
        }

    }
}
