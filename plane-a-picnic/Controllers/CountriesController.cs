using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using plane_a_picnic.Domain.Models;
using plane_a_picnic.Domain.Services;
using plane_a_picnic.ResourceModels;

namespace plane_a_picnic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;

        public CountriesController(ICountryService countryService, IMapper mapper)
        {
            _countryService = countryService;
            _mapper = mapper;
        }

        // GET api/countries
        [HttpGet]
        public async Task<IEnumerable<CountryBasicResourceModel>> GetAllAsync([FromQuery(Name = "q")] string q)
        {
            var countries = await _countryService.ListAsync();
            var resources = _mapper.Map<IEnumerable<CountryModel>, IEnumerable<CountryBasicResourceModel>>(countries);
            
            if (q == null)
            {
                return resources;
            }
            else
            {
                return resources.Where(r => r.Name.Contains(q, StringComparison.OrdinalIgnoreCase));
            }
        }

        // GET api/countries/5
        [HttpGet("{id}")]
        public async Task<CountryResourceModel> GetOneAsync(int id)
        {
            var country = await _countryService.ListOneAsync(id);
            var resource = _mapper.Map<CountryModel, CountryResourceModel>(country);
            return resource;
        }
    }
}