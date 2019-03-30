using plane_a_picnic.Domain.Models;

namespace plane_a_picnic.Domain.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly ModelContext _context;

        public BaseRepository(ModelContext context)
        {
            _context = context;
        }
    }
}