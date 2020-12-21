using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StockExchangeService.Domain.Contracts;
using StockExchangeService.Dtos;
using StockExchangeService.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StockExchangeService.Controllers
{
    [Route("api.exchange/exchange")]
    [ApiController]
    public class StockExchangeController : ControllerBase
    {
        readonly IStockExchangeService service;

        public StockExchangeController(IStockExchangeService service)
        {
            this.service = service;
        }

        // GET: api/<StockExchangeController>
        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult Get()
        {
            return Ok(service.GetStockExchanges());
        }

        [HttpGet("{name}/companies")]
        [ProducesResponseType(200)]
        public IActionResult GetStockExchangeCompanies(string name)
        {
            return Ok(service.GetStockExchangeCompanies(name));
        }

        // POST api/<StockExchangeController>
        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201)]
        public IActionResult Post([FromBody] StockExchangeDto exchange)
        {
            var result = service.AddStockExchange(exchange);
            if (!result)
                return BadRequest("Error saving Exchange");
            return Created("No Url", new { message = "Stock Exchange addded" });
        }
    }
}
