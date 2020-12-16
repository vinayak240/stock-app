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
    [Route("api.sector/company")]
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
        public IActionResult AddCompany([FromBody] Company company)
        {
            var result = service.AddCompany(company);
            if (!result)
                return BadRequest("Error saving Company");
            return StatusCode(201);
        }

        // PUT api/company/id
        [HttpPut("{code}")]
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

