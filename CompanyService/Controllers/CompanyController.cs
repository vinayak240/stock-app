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
    [Route("api/company")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        readonly ICompanyRepository repo ;

        public CompanyController(ICompanyRepository repo)
        {
            this.repo = repo;
        }

        // GET: api/company
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(repo.GetCompanies());
        }

        // GET api/company/id
        [HttpGet("{code}")]
        public IActionResult GetById(string code)
        {
            var Obj = repo.GetCompany(code);
            if (Obj == null)
                return NotFound();

            return Ok(Obj);
        }

        [HttpGet("filter/{filter}")]
        public IActionResult GetMatching(string filter)
        {
            var Obj = repo.GetMatchingCompanies(filter);
            if (Obj == null)
                return NotFound();

            return Ok(Obj);
        }

        // GET api/company/id/Ipos
        [HttpGet("{code}/ipos")]
        public IActionResult GetCompanyIPODetails(string code)
        {
            return Ok(repo.GetCompanyIPODetails(code));
        }
        [HttpGet("{code}/stocks/{fromDT}/{toDt}/{period}")]
        public IActionResult GetCompanyStockPrice(string code, DateTime fromDt, DateTime toDt, string period)
        {
            if(fromDt > toDt)
            {
                return BadRequest("Invalid Dates");
            }
            return Ok(repo.GetCompanyStockPrice(code, fromDt, toDt, period));
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
