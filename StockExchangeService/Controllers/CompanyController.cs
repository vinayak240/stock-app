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
    [Route("api.exchange/company")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        readonly ICompanyService service;

        public CompanyController(ICompanyService service)
        {
            this.service = service;
        }

        // POST api/company
        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201)]
        public IActionResult AddCompany([FromBody] Company company)
        {
            var result = service.AddCompany(company);
            if (!result)
                return BadRequest("Error saving Company");
            return StatusCode(201);
        }

        // PUT api/company/id
        [HttpPut("{code}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public IActionResult UpdateCompany(string code, [FromBody] Company obj)
        {
            if (obj == null)
                return BadRequest("Company is required");

            var com = service.GetCompany(obj.CompanyCode);

            if (com == null)
                return NotFound();

            var result = service.UpdateCompany(obj);
            if (result)
                return Ok();
            else
                return BadRequest("Update failed");
        }

        // DELETE api/<CompanyController>/5
        [HttpDelete("{code}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        public IActionResult Delete(string code)
        {
            var com = service.GetCompany(code);

            if (com == null)
                return NotFound();

            var result = service.DeleteCompany(code);
            if (result)
                return NoContent();
            else
                return BadRequest("Delete failed");
        }
    }
}
