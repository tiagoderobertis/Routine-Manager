using RoutineManager.ModeloVistas;
using RoutineManager.Data_Access;
using RoutineManager.Connection;

namespace RoutineManager.Vistas;
public partial class RoutineCreator : ContentPage
{


    public RoutineCreator()
    {
        InitializeComponent();

        var dbContext = App.ServiceProvider.GetRequiredService<RManagerDbContext>();
        var routinesRepository = new RoutinesRepository(dbContext);
        var exerciseRepository = new ExerciseRepository(dbContext);
        var routinesExerciseRepository = new RoutinesExerciseRepository(dbContext);

        BindingContext = new RoutineCreatorViewModel(
            routinesRepository,
            exerciseRepository,
            routinesExerciseRepository,
            dbContext
        );
    }

}
