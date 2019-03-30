using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using plane_a_picnic.Domain.Models;
using plane_a_picnic.Domain.Repositories;

namespace plane_a_picnic.Repositories
{
    public class AirportRepository : BaseRepository, IAirportRepository
    {
        public AirportRepository(ModelContext modelContext) : base(modelContext)
        {
        }

        public async Task<IEnumerable<AirportModel>> ListAsync()
        {
            return await _modelContext.Airports.ToListAsync();
        }
    }
}