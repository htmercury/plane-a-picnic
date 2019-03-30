using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using plane_a_picnic.Domain.Models;
using plane_a_picnic.Domain.Services;
using plane_a_picnic.ResourceModels;

namespace plane_a_picnic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportsController : ControllerBase
    {
        private readonly IAirportService _airportService;
        private readonly IMapper _mapper;

        public AirportsController(IAirportService airportService, IMapper mapper)
        {
            _airportService = airportService;
            _mapper = mapper;
        }
        
        // GET api/airports
        [HttpGet]
        public async Task<IEnumerable<AirportResourceModel>> GetAllAsync()
        {
            var airports = await _airportService.ListAsync();
            var resources = _mapper.Map<IEnumerable<AirportModel>, IEnumerable<AirportResourceModel>>(airports);
            return resources;
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
