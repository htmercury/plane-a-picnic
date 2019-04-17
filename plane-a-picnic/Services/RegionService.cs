using System.Collections.Generic;
using System.Threading.Tasks;
using plane_a_picnic.Domain.Models;
using plane_a_picnic.Domain.Repositories;
using plane_a_picnic.Domain.Services;

namespace plane_a_picnic.Services
{
    public class RegionService : IRegionService
    {
        private readonly IRegionRepository _regionRepository;

        public RegionService(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }

        public async Task<IEnumerable<RegionModel>> ListAsync()
        {
            return await _regionRepository.ListAsync();
        }

        public async Task<RegionModel> ListOneAsync(int id)
        {
            return await _regionRepository.ListOneAsync(id);
        }

        public async Task<RegionModel> ListOneByCodeAsync(string code)
        {
            return await _regionRepository.ListOneByCodeAsync(code);
        }
    }
}