using RoutineManager.Connection;
using RoutineManager.Modelos;

namespace RoutineManager.Data_Access
{
    public class RoutinesExerciseRepository
    {

        private readonly RManagerDbContext _dbContext;

        public RoutinesExerciseRepository(RManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddRoutineExerciseAsync(RoutineExercise routineExercise)
        {
            _dbContext.RoutineExercises.Add(routineExercise);
            await _dbContext.SaveChangesAsync();
        }
        
    }
}
