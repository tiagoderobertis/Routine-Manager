using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoutineManager.Modelos
{
    public class Exercise
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Exercise { get; set; }
        [Required]
        public string Exercise_Name { get; set; }

        public List<RoutineExercise> RoutineExercises { get; set; }
    }
}
