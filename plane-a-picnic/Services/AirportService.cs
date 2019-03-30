using System.Collections.Generic;
using System.Threading.Tasks;
using plane_a_picnic.Domain.Models;
using plane_a_picnic.Domain.Repositories;
using plane_a_picnic.Domain.Services;

namespace plane_a_picnic.Services
{
    public class AirportService : IAirportService
    {
        private readonly IAirportRepository _airportRepository;

        public AirportService(IAirportRepository airportRepository)
        {
            _airportRepository = airportRepository;
        }

         public async Task<IEnumerable<AirportModel>> ListAsync()
         {
             return await _airportRepository.ListAsync();
         }

         public async Task<AirportModel> ListOneAsync(int id)
         {
             return await _airportRepository.ListOneAsync(id);
         }
    }
}