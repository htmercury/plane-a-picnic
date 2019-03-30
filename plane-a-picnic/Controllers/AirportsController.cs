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
        public async Task<IEnumerable<AirportBasicResourceModel>> GetAllAsync()
        {
            var airports = await _airportService.ListAsync();
            var resources = _mapper.Map<IEnumerable<AirportModel>, IEnumerable<AirportBasicResourceModel>>(airports);
            return resources;
        }

        // GET api/airports/5
        [HttpGet("{id}")]
        public async Task<AirportResourceModel> GetOneAsync(int id)
        {
            var airport = await _airportService.ListOneAsync(id);
            var resource = _mapper.Map<AirportModel, AirportResourceModel>(airport);
            return resource;
        }
    }
}
