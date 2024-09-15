using RoutineManager.Routine;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoutineManager.Modelos
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class RoutineExercise
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [ForeignKey("Exercise")]
        public int ID_Exercise { get; set; }
        public Exercise Exercise { get; set; }

        [Required]
        [ForeignKey("Routine")]
        public int ID_Routine { get; set; }
        public Routines Routine { get; set; }

        [Required]
        public int Series { get; set; }

        [Required]
        public int Reps { get; set; }

        [Required]
        public TimeSpan Rest_per_serie { get; set; }

        // Calcula el Id_day a partir de la rutina asociada
        public int Id_day => Routine?.Id_day ?? 0;
    }

}
