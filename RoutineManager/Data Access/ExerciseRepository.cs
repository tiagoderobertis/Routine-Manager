using RoutineManager.Connection;
using RoutineManager.Modelos;

namespace RoutineManager.Data_Access
{
    public class ExerciseRepository
    {

        private readonly RManagerDbContext _dbContext;

        public ExerciseRepository(RManagerDbContext dbContext)
        {

            _dbContext = dbContext; 
        }

        public async Task AddExerciseAsync(Exercise exercise)
        {
            _dbContext.Exercises.Add(exercise);
            await _dbContext.SaveChangesAsync();
        }

    }
}
