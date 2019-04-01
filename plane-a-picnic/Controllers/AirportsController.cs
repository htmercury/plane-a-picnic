using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using plane_a_picnic.Domain.Models;
using plane_a_picnic.Domain.Services;
using plane_a_picnic.ResourceModels;
using plane_a_picnic.ActionFilters;

namespace plane_a_picnic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportsController : ControllerBase
    {
        private readonly IAirportService _airportService;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public AirportsController(IAirportService airportService, IMapper mapper, IMemoryCache cache)
        {
            _airportService = airportService;
            _mapper = mapper;
            _cache = cache;
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

        // sample route
        // GET: api/airports/memorycache
        [HttpGet("memorycache")]
        [NoCache]
        public string Get()
        {
            var cacheEntry = _cache.GetOrCreate("MyCacheKey", entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(10);
                return LongTimeOperation();
            });
            return cacheEntry;
        }

        private string LongTimeOperation()
        {
            Thread.Sleep(5000);
            return "Long time operation done!";
        }
    }
}