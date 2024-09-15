using Microsoft.EntityFrameworkCore;
using RoutineManager.Routine;
using RoutineManager.Modelos;

namespace RoutineManager.Connection
{
    public class RManagerDbContext : DbContext
    {
        public RManagerDbContext(DbContextOptions<RManagerDbContext> options)
        : base(options)
        {
        }

        public DbSet<Exercise> Exercise { get; set; }
        public DbSet<Routines> Routines { get; set; }
        public DbSet<RoutineExercise> RoutineExercises { get; set; }
        public DbSet<Days> Days { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conexionDB = $"Filename={Utilities.DbPath.DevolverRuta("RMDB.db")}";
            optionsBuilder.UseSqlite(conexionDB);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoutineExercise>()
                .HasKey(re => new { re.ID_Routine, re.ID_Exercise });
        }

    }
}
