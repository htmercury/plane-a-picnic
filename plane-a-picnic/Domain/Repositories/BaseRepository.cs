using plane_a_picnic.Domain.Models;

namespace plane_a_picnic.Domain.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly ModelContext _modelContext;

        public BaseRepository(ModelContext modelContext)
        {
            _modelContext = modelContext;
        }
    }
}