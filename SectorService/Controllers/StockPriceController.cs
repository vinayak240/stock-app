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

        readonly IStockPriceRepository repo;

        public StockPriceController(IStockPriceRepository repo)
        {
            this.repo = repo;
        }

        // POST api.sector/stock/
        [HttpPost]
        public IActionResult Post([FromBody] StockPrice price)
        {
            var result = repo.AddStockPrice(price);
            if (!result)
                return BadRequest("Error saving Stock Price");
            return StatusCode(201);
        }

        // PUT api.sector/stock/id
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] StockPrice obj)
        {
            if (obj == null)
                return BadRequest("Stock Price  is required");

            var com = repo.GetStockPrice(id);

            if (com == null)
                return NotFound();
            obj.ID = com.ID; // Add this line to evry ID Entity
            var result = repo.UpdateStockPrice(obj);
            if (result)
                return Ok();
            else
                return BadRequest("Update failed");
        }

        // DELETE api/<StockPriceController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var com = repo.GetStockPrice(id);

            if (com == null)
                return NotFound();

            var result = repo.DeleteStockPrice(id);
            if (result)
                return NoContent();
            else
                return BadRequest("Delete failed");
        }
    }
}
