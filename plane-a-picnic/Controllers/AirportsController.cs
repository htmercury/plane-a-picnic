using System;
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
using plane_a_picnic.Utilities;

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
        private AirportWeatherHandler _handler;

        public AirportsController(IAirportService airportService, IMapper mapper, IMemoryCache cache, IOpenWeatherService openWeatherService)
        {
            _airportService = airportService;
            _openWeatherService = openWeatherService;
            _mapper = mapper;
            _cache = cache;
            _handler = new AirportWeatherHandler();
        }

        // GET api/airports
        [HttpGet()]
        public async Task<IEnumerable<AirportBasicResourceModel>> GetAllAsync([FromQuery(Name = "q")] string q)
        {
            var airports = await _airportService.ListAsync();
            var resources = _mapper.Map<IEnumerable<AirportModel>, IEnumerable<AirportBasicResourceModel>>(airports);

            if (q == null)
            {
                return resources;
            }
            else
            {
                return resources.Where(r => r.Name.Contains(q, StringComparison.OrdinalIgnoreCase));
            }
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

        // GET api/airports/5/prediction
        [HttpGet("{id}/prediction")]
        public async Task<IEnumerable<RunwayResourceModel>> PredictLandingRunways(int id)
        {
            // setup
            if (_handler.AirportId != id)
            {
                _handler.AirportId = id;
                var airport = await GetOneAsync(id);
                _handler.Runways = airport.Runways
                    .FindAll(r => r.LeHeadingDegT.HasValue || r.HeHeadingDegT.HasValue)
                    .OrderBy(r => r.LeHeadingDegT)
                    .ToList();
            }

            if (_handler.Runways.Count == 0)
            {
                return new List<RunwayResourceModel>();
            }

            var weather = await GetWeather(id);
            var predictions = new List<RunwayResourceModel>();
            
            // sometimes list can be null
            weather.List = weather.List.Where(l => l != null).ToArray();
            
            for (int i = 0; i < weather.List.Length; i++)
            {
                double windDegree = weather.List[i].Wind.Deg;
                var runway = _handler.CalcLandingRunway(windDegree);
                predictions.Add(runway);
            }
            return predictions;
        }

        // GET api/airports/5/prediction/debug
        [HttpGet("{id}/prediction/debug")]
        public async Task<IEnumerable<RunwayStatsResourceModel>> DebugLandingRunways(int id)
        {
            // setup
            if (_handler.AirportId != id)
            {
                _handler.AirportId = id;
                var airport = await GetOneAsync(id);
                _handler.Runways = airport.Runways
                    .FindAll(r => r.LeHeadingDegT.HasValue || r.HeHeadingDegT.HasValue)
                    .OrderBy(r => r.LeHeadingDegT)
                    .ToList();
            }

            if (_handler.Runways.Count == 0)
            {
                var empty = _handler.DebugLandingRunway(-1);
                return new List<RunwayStatsResourceModel>{empty};
            }

            var weather = await GetWeather(id);
            var stats = new List<RunwayStatsResourceModel>();
            for (int i = 0; i < weather.List.Length; i++)
            {
                var day = _handler.DebugLandingRunway(weather.List[i].Wind.Deg);
                stats.Add(day);
            }
            return stats;
        }
    }
}
