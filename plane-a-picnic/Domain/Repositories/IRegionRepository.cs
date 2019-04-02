using System.Collections.Generic;
using System.Threading.Tasks;
using plane_a_picnic.Domain.Models;

namespace plane_a_picnic.Domain.Repositories
{
    public interface IRegionRepository
    {
        Task<IEnumerable<RegionModel>> ListAsync();
        Task<RegionModel> ListOneAsync(int id);
    }
}