using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using plane_a_picnic.Domain.Models;
using plane_a_picnic.Domain.Repositories;

namespace plane_a_picnic.Repositories
{
    public class CountryRepository : BaseRepository, ICountryRepository
    {
        public CountryRepository(ModelContext context) : base(context)
        {
        }

        public async Task<IEnumerable<CountryModel>> ListAsync()
        {
            return await _context.Countries.ToListAsync();
        }

        public async Task<CountryModel> ListOneAsync(int id)
        {
            return await _context.Countries
                .Where(country => country.CountryId == id)
                .Include(country => country.Regions)
                .FirstOrDefaultAsync();
        }
    }
}