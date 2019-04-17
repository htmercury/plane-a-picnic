using System.Collections.Generic;
using System.Threading.Tasks;
using plane_a_picnic.Domain.Models;

namespace plane_a_picnic.Domain.Repositories
{
    public interface ICountryRepository
    {
        Task<IEnumerable<CountryModel>> ListAsync();
        Task<CountryModel> ListOneAsync(int id);
    }
}