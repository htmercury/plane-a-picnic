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
    public class RegionsController : ControllerBase
    {
        private readonly IRegionService _regionService;
        private readonly IMapper _mapper;

        public RegionsController(IRegionService regionService, IMapper mapper)
        {
            _regionService = regionService;
            _mapper = mapper;
        }

        // GET api/regions
        [HttpGet]
        public async Task<IEnumerable<RegionBasicResourceModel>> GetAllAsync([FromQuery(Name = "q")] string q)
        {
            var regions = await _regionService.ListAsync();
            var resources = _mapper.Map<IEnumerable<RegionModel>, IEnumerable<RegionBasicResourceModel>>(regions);
            
            if (q == null)
            {
                return resources;
            }
            else
            {
                return resources.Where(r => r.Name.Contains(q, StringComparison.OrdinalIgnoreCase));
            }
        }

        // GET api/regions/5
        [HttpGet("{id}")]
        public async Task<RegionResourceModel> GetOneAsync(int id)
        {
            var region = await _regionService.ListOneAsync(id);
            var resource = _mapper.Map<RegionModel, RegionResourceModel>(region);
            return resource;
        }

        // GET api/regions/iso/us
        [HttpGet("iso/{code}")]
        public async Task<RegionResourceModel> GetOneByCodeAsync(string code)
        {
            var country = await _regionService.ListOneByCodeAsync(code);
            var resource = _mapper.Map<RegionModel, RegionResourceModel>(country);
            return resource;
        }
    }
}