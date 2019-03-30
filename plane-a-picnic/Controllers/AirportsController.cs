using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using plane_a_picnic.Domain.Models;
using plane_a_picnic.Domain.Services;

namespace plane_a_picnic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportsController : ControllerBase
    {
        private readonly IAirportService _airportService;

        public AirportsController(IAirportService airportService)
        {
            _airportService = airportService;
        }
        
        // GET api/airports
        [HttpGet]
        public async Task<IEnumerable<AirportModel>> GetAllAsync()
        {
            var airports = await _airportService.ListAsync();
            return airports;
        }

        // GET api/airports/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/airports
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/airports/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/airports/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
