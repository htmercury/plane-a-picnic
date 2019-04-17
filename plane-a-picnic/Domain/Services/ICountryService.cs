using System.Collections.Generic;
using System.Threading.Tasks;
using plane_a_picnic.Domain.Models;

namespace plane_a_picnic.Domain.Services
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryModel>> ListAsync();
        Task<CountryModel> ListOneAsync(int id);
        Task<CountryModel> ListOneByCodeAsync(string code);
    }
}