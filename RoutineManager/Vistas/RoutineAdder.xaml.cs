using CommunityToolkit.Maui;
using RoutineManager.Connection;
using RoutineManager.Data_Access;
using RoutineManager.ModeloVistas;
namespace RoutineManager.Vistas;

public partial class RoutineAdder : ContentPage
{
    private readonly RManagerDbContext _db;
    private readonly ExerciseRepository _exerciseRepository;
    private readonly RoutineAdderViewModel _viewModel;

    public RoutineAdder(RManagerDbContext db)
    {
        // Initialize _db and _exerciseRepository
        _db = db;
        _exerciseRepository = new ExerciseRepository(_db); // or get it from dependency injection

        // Create the ViewModel with initialized dependencies
        _viewModel = new RoutineAdderViewModel(_db, _exerciseRepository);
        BindingContext = _viewModel;

        InitializeComponent();
    }
}
