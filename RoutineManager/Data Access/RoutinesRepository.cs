using RoutineManager.Connection;
using RoutineManager.Modelos;

namespace RoutineManager.Data_Access
{
    public class RoutinesRepository
    {

        private readonly RManagerDbContext _dbContext;

        public RoutinesRepository(RManagerDbContext dbContext)
        {

            _dbContext = dbContext;
        }

        public async Task AddRoutineAsync(Routines routines)
        {
            _dbContext.Routines.Add(routines);
            await _dbContext.SaveChangesAsync();
        }
    }
}
