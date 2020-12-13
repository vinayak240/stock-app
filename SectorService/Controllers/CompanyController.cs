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
        readonly ICompanyRepository repo;

        public CompanyController(ICompanyRepository repo)
        {
            this.repo = repo;
        }

        // POST api/company
        [HttpPost]
        public IActionResult AddCompany([FromBody] Company company)
        {
            var result = repo.AddCompany(company);
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

            var com = repo.GetCompany(obj.CompanyCode);

            if (com == null)
                return NotFound();

            var result = repo.UpdateCompany(obj);
            if (result)
                return Ok();
            else
                return BadRequest("Update failed");
        }

        // DELETE api/<CompanyController>/5
        [HttpDelete("{code}")]
        public IActionResult Delete(string code)
        {
            var com = repo.GetCompany(code);

            if (com == null)
                return NotFound();

            var result = repo.DeleteCompany(code);
            if (result)
                return NoContent();
            else
                return BadRequest("Delete failed");
        }
    }
}

