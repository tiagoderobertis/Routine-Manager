using Microsoft.EntityFrameworkCore.Sqlite;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
namespace RoutineManager.Modelos
{
    public class Routines
    {
        [Key] // clave primaria
        [Required] // not null
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //autoincrement
        public int ID_Routine { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(7)]
        [Required]
        public int Days { get; set; }
        [MaxLength(50)]
        public string Description { get; set; }

        public List<RoutineExercise> RoutineExercises { get; set; }

    }
}
