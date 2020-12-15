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
    [Route("api/company")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        readonly ICompanyService service ;

        public CompanyController(ICompanyService service)
        {
            this.service = service;
        }

        // GET: api/company
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(service.GetCompanies());
        }

        // GET api/company/id
        [HttpGet("{code}")]
        public IActionResult GetById(string code)
        {
            var Obj = service.GetCompany(code);
            if (Obj == null)
                return NotFound();

            return Ok(Obj);
        }

        [HttpGet("filter/{cname}")]
        public IActionResult GetMatching(string cname)
        {
            var Obj = service.GetMatchingCompanies(cname);
            if (Obj == null)
                return NotFound();

            return Ok(Obj);
        }

        // GET api/company/id/Ipos
        [HttpGet("{code}/ipos")]
        public IActionResult GetCompanyIPODetails(string code)
        {
            return Ok(service.GetCompanyIPODetails(code));
        }
        [HttpGet("{code}/stocks/{fromDT}/{toDt}/{period}")]
        public IActionResult GetCompanyStockPrice(string code, DateTime fromDt, DateTime toDt, string period)
        {
            if(fromDt > toDt)
            {
                return BadRequest("Invalid Dates");
            }
            return Ok(service.GetCompanyStockPrice(code, fromDt, toDt, period));
        }


        // POST api/company
        [HttpPost]
        public IActionResult AddCompany([FromBody] CompanyDto company)
        {
            var result = service.AddCompany(company);
            if (!result)
                return BadRequest("Error saving Company");
            return Created("No Url", new { message = "Company addded" });
        }

        // PUT api/company/id
        [HttpPut("{code}")]
        public IActionResult UpdateCompany(string code, [FromBody] CompanyDto obj)
        {
            if (obj == null)
                return BadRequest("Company is required");

            var com = service.GetCompany(obj.CompanyCode);

            if (com == null)
                return NotFound();

            var result = service.UpdateCompany(obj);
            if (result)
                return Ok("Company Updated");
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
