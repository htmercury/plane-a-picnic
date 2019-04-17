using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using plane_a_picnic.Domain.Models;
using plane_a_picnic.Domain.Repositories;

namespace plane_a_picnic.Repositories
{
    public class RegionRepository : BaseRepository, IRegionRepository
    {
        public RegionRepository(ModelContext context) : base(context)
        {
        }

        public async Task<IEnumerable<RegionModel>> ListAsync()
        {
            return await _context.Regions
                .OrderBy(r => r.Name)
                .ToListAsync();
        }

        public async Task<RegionModel> ListOneAsync(int id)
        {
            return await _context.Regions
                .Where(region => region.RegionId == id)
                .Include(region => region.Airports)
                .Include(region => region.Country)
                .FirstOrDefaultAsync();
        }
        
        public async Task<RegionModel> ListOneByCodeAsync(string code)
        {
            return await _context.Regions
                .Where(region => region.Code == code)
                .FirstOrDefaultAsync();
        }
    }
}