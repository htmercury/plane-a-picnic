using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using plane_a_picnic.Domain.Models;
using plane_a_picnic.Domain.Repositories;

namespace plane_a_picnic.Repositories
{
    public class AirportRepository : BaseRepository, IAirportRepository
    {
        public AirportRepository(ModelContext context) : base(context)
        {
        }

        public async Task<IEnumerable<AirportModel>> ListAsync(int page, int pageSize)
        {
            int skip = pageSize * (page - 1);
            return await _context.Airports
                .OrderBy(airport => airport.IsoCountry)
                .Skip(skip)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<AirportModel> ListOneAsync(int id)
        {
            return await _context.Airports
                .Where(airport => airport.AirportId == id)
                .Include(airport => airport.Runways)
                .FirstOrDefaultAsync();
        }
    }
}