using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SectorService.Domain.Contracts;
using SectorService.Dtos;
using SectorService.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SectorService.Controllers
{
    [Route("api.sector/sector")]
    [ApiController]
    public class SectorController : ControllerBase
    {
        readonly ISectorService service;

        public SectorController(ISectorService service)
        {
            this.service = service;
        }

        // GET: api/<SectorController>
        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult Get()
        {
            return Ok(service.GetSectors());
        }

        // GET api/<SectorController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public IActionResult GetById(int id)
        {
            var Obj = service.GetSector(id);
            if (Obj == null)
                return NotFound();

            return Ok(Obj);
        }

        // GET api/sector/id/companies
        [HttpGet("{name}/companies")]
        [ProducesResponseType(200)]
        public IActionResult GetCompanyList(string name)
        {
            return Ok(service.GetSectorCompanies(name)); 
        }

        [HttpGet("{name}/stocks/{fromDT}/{toDt}/{period}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public IActionResult GetSectorStockPrice(string name, DateTime fromDt, DateTime toDt, string period)
        {
            if (fromDt > toDt)
            {
                return BadRequest("Invalid Dates");
            }
            return Ok(service.GetSectorStockPrice(name, fromDt, toDt, period));
        }

        // POST api/<SectorController>
        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201)]
        public IActionResult Post([FromBody] SectorDto sector)
        {
            var result = service.AddSectors(sector);
            if (!result)
                return BadRequest("Error saving Sector");
            return Created("No Url", new { message = "Sector added" });
        }

       
    }
}
