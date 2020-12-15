using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyService.Domain.Contracts;
using CompanyService.Dtos;
using CompanyService.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyService.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockPriceController : ControllerBase
    {

        readonly IStockPriceService service;

        public StockPriceController(IStockPriceService service)
        {
            this.service = service;
        }

        // POST api.sector/stock/
        [HttpPost]
        public IActionResult Post([FromBody] StockPriceDto price)
        {
            var result = service.AddStockPrice(price);
            if (!result)
                return BadRequest("Error saving Stock Price");
            return StatusCode(201);
        }

        // PUT api.sector/stock/id
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] StockPriceDto obj)
        {
            if (obj == null)
                return BadRequest("Stock Price  is required");

            var com = service.GetStockPrice(id);

            if (com == null)
                return NotFound();
            obj.ID = com.ID; // Add this line to evry ID Entity
            var result = service.UpdateStockPrice(obj);
            if (result)
                return Ok();
            else
                return BadRequest("Update failed");
        }

        // DELETE api/<StockPriceController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var com = service.GetStockPrice(id);

            if (com == null)
                return NotFound();

            var result = service.DeleteStockPrice(id);
            if (result)
                return NoContent();
            else
                return BadRequest("Delete failed");
        }
    }
}
