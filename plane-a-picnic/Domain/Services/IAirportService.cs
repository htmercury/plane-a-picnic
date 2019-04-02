using System.Collections.Generic;
using System.Threading.Tasks;
using plane_a_picnic.Domain.Models;

namespace plane_a_picnic.Domain.Services
{
    public interface IAirportService
    {
        Task<IEnumerable<AirportModel>> ListAsync(int page, int pageSize);
        Task<AirportModel> ListOneAsync(int id);

    }
}