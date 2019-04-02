using System.Collections.Generic;
using System.Threading.Tasks;
using plane_a_picnic.Domain.Models;
using plane_a_picnic.Domain.Repositories;
using plane_a_picnic.Domain.Services;

namespace plane_a_picnic.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository CountryRepository)
        {
            _countryRepository = CountryRepository;
        }

        public async Task<IEnumerable<CountryModel>> ListAsync()
        {
            return await _countryRepository.ListAsync();
        }

        public async Task<CountryModel> ListOneAsync(int id)
        {
            return await _countryRepository.ListOneAsync(id);
        }
    }
}