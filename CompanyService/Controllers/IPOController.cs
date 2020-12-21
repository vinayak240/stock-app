using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyService.Domain.Contracts;
using CompanyService.Dtos;
using CompanyService.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CompanyService.Controllers
{
    [Route("api/ipo")]
    [ApiController]
    public class IPOController : ControllerBase
    {
        readonly IIPOService service;

        public IPOController(IIPOService service)
        {
            this.service = service;
        }

        // GET: api/ipo
        [HttpGet]

        [ProducesResponseType(200, Type = typeof(IPODto[]))]
        public IActionResult Get()
        {
            return Ok(service.GetIpos());
        }

        // POST api/ipo
        [HttpPost]
        [ProducesResponseType(400)]  
        [ProducesResponseType(201)]
        public IActionResult AddIPO([FromBody] IPODto ipo)
        {
            //string str = ipo.OpenDate.ToString();
            //ipo.OpenDate = DateTime.Parse(str);
            var result = service.AddIPO(ipo);
            if (!result)
                return BadRequest("Error saving IPO");
            return Created("No Url", new { message = "IPO addded"});
        }

    }
}
