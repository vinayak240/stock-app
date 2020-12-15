using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StockExchangeService.Domain.Contracts;
using StockExchangeService.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StockExchangeService.Controllers
{
    [Route("api.exchange/exchange")]
    [ApiController]
    public class StockExchangeController : ControllerBase
    {
        readonly IStockExchangeRepository repo;

        public StockExchangeController(IStockExchangeRepository repo)
        {
            this.repo = repo;
        }
        // GET: api/<StockExchangeController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(repo.GetStockExchanges());
        }

        [HttpGet("{name}/companies")]
        public IActionResult GetStockExchangeCompanies(string name)
        {
            return Ok(repo.GetStockExchangeCompanies(name));
        }

        // POST api/<StockExchangeController>
        [HttpPost]
        public IActionResult Post([FromBody] StockExchange exchange)
        {
            var result = repo.AddStockExchange(exchange);
            if (!result)
                return BadRequest("Error saving Exchange");
            return Created("No Url", new { message = "Stock Exchange addded" });
        }
    }
}
