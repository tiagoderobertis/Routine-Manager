using Microsoft.EntityFrameworkCore;
using RoutineManager.Connection;
using RoutineManager.Modelos;
using System.Linq;

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
            _dbContext.Exercise.Add(exercise);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateExerciseAsync(int id, string name)
        {
            
            var select = await _dbContext.Exercise
                 .Where(r => r.ID_Exercise.Equals(id))
                 .FirstOrDefaultAsync();

            if (select != null)
            {
                select.Exercise_Name = name;
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteExerciseAsync(Exercise exercise)
        {
            _dbContext.Exercise.Remove(exercise);
            await _dbContext.SaveChangesAsync();
        }


    }
}
