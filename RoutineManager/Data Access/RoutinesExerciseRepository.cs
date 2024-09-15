using Microsoft.EntityFrameworkCore;
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

        public async Task UpdateRoutineExerciseAsync(int id, int series, int reps, TimeSpan restpserie)
        {

            var select = await _dbContext.RoutineExercises
                 .Where(r => r.ID.Equals(id))
                 .FirstOrDefaultAsync();

            if (select != null)
            {
                select.Series = series;
                select.Reps = reps;
                select.Rest_per_serie = restpserie;
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteRoutineExerciseAsync(RoutineExercise routineExercise)
        {
            _dbContext.RoutineExercises.Remove(routineExercise);
            await _dbContext.SaveChangesAsync();
        }

    }
}
