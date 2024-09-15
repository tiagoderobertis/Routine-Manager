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
        
        [MaxLength(50)]
        public string Description { get; set; }

        public List<RoutineExercise> RoutineExercises { get; set; }

        [Required]
        public int Id_day { get; set; } // Clave foránea

        [ForeignKey("Id_day")]
        public Days Days { get; set; } // Propiedad de navegación

    }
}
