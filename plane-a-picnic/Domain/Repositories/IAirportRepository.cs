using System.Collections.Generic;
using System.Threading.Tasks;
using plane_a_picnic.Domain.Models;

namespace plane_a_picnic.Domain.Repositories
{
    public interface IAirportRepository
    {
        Task<IEnumerable<AirportModel>> ListAsync(int page, int pageSize);
        Task<AirportModel> ListOneAsync(int id);
    }
}