using System.Collections.Generic;
using System.Threading.Tasks;
using plane_a_picnic.Domain.Models;

namespace plane_a_picnic.Domain.Services
{
    public interface IRegionService
    {
        Task<IEnumerable<RegionModel>> ListAsync();
        Task<RegionModel> ListOneAsync(int id);    
    }
}