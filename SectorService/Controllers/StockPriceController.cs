using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SectorService.Domain.Contracts;
using SectorService.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SectorService.Controllers
{
    [Route("api.sector/stock")]
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
        [ProducesResponseType(400)]
        [ProducesResponseType(201)]
        public IActionResult Post([FromBody] StockPrice price)
        {
            var result = service.AddStockPrice(price);
            if (!result)
                return BadRequest("Error saving Stock Price");
            return StatusCode(201);
        }

        // PUT api.sector/stock/id
        [HttpPut("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public IActionResult Put(int id, [FromBody] StockPrice obj)
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
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
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
