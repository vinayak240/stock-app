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
    [Route("api.sector/sector")]
    [ApiController]
    public class SectorController : ControllerBase
    {
        readonly ISectorRepository repo;

        public SectorController(ISectorRepository repo)
        {
            this.repo = repo;
        }

        // GET: api/<SectorController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(repo.GetSectors());
        }

        // GET api/<SectorController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var Obj = repo.GetSector(id);
            if (Obj == null)
                return NotFound();

            return Ok(Obj);
        }

        // GET api/sector/id/companies
        [HttpGet("{name}/companies")]
        public IActionResult GetCompanyList(string name)
        {
            return Ok(repo.GetSectorCompanies(name));
        }

        // POST api/<SectorController>
        [HttpPost]
        public IActionResult Post([FromBody] Sector sector)
        {
            var result = repo.AddSectors(sector);
            if (!result)
                return BadRequest("Error saving Sector");
            return Created("No Url", new { message = "Sector added" });
        }

       
    }
}
