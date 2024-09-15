using Microsoft.EntityFrameworkCore;
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

        public async Task UpdateRoutineAsync(int id, string name, int days, string description)
        {

            var select = await _dbContext.Routines
                 .Where(r => r.ID_Routine.Equals(id))
                 .FirstOrDefaultAsync();

            if (select != null)
            {
                select.Name = name;
                select.Id_day = days;
                select.Description = description;
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteRoutineAsync(Routines routines)
        {
            _dbContext.Routines.Remove(routines);
            await _dbContext.SaveChangesAsync();
        }
    }
}
