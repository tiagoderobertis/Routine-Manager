using RoutineManager.Routine;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoutineManager.Modelos
{
    public class RoutineExercise
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("Exercise")]
        public int ID_Exercise { get; set; }
        public Exercise Exercise { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("Routine")]
        public int ID_Routine { get; set; }
        public Routines Routine { get; set; }

        [Required, MaxLength(25)]
        public int Series { get; set; }
        [Required, MaxLength(50)]
        public int Reps { get; set; }
        [Required]
        public TimeSpan Rest_per_serie { get; set; }
        // Rest_per_serie = new TimeSpan(0, 2, 30) // 2 minutos y 30 segundos
        // var restTime = rutinaEjercicio.Rest_per_serie.ToString(@"mm\:ss");
    }
}
