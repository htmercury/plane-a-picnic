﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using plane_a_picnic.ActionFilters;
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
        private readonly IOpenWeatherService _openWeatherService;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public AirportsController(IAirportService airportService, IMapper mapper, IMemoryCache cache, IOpenWeatherService openWeatherService)
        {
            _airportService = airportService;
            _openWeatherService = openWeatherService;
            _mapper = mapper;
            _cache = cache;
        }

        // GET api/airports
        [HttpGet()]
        public async Task<IEnumerable<AirportBasicResourceModel>> GetAllAsync([FromQuery(Name="page")]int? page, [FromQuery(Name="pageSize")]int? pageSize)
        {
            var airports = await _cache.GetOrCreateAsync("airports", entry => {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(3600);
                return _airportService.ListAsync();
            });
            var resources = _mapper.Map<IEnumerable<AirportModel>, IEnumerable<AirportBasicResourceModel>>(airports);
            int p = page ?? 1;
            int pS = pageSize ?? 20;
            int skip = pS * (p - 1);

            return resources.Skip(skip).Take(pS);
        }

        // GET api/airports/5
        [HttpGet("{id}")]
        public async Task<AirportResourceModel> GetOneAsync(int id)
        {
            var airport = await _airportService.ListOneAsync(id);
            var resource = _mapper.Map<AirportModel, AirportResourceModel>(airport);
            return resource;
        }

        // GET api/airports/5/weather
        [HttpGet("{id}/weather")]
        [NoCache]
        public async Task<WeatherResourceModel> GetWeather(int id)
        {
            var weather = await _cache.GetOrCreateAsync(id, entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(3600);
                return _openWeatherService.GetWeatherAsync(id);
            });
            return weather;
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