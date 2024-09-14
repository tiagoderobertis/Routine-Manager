using RoutineManager.Connection;
using RoutineManager.ModeloVistas;

namespace RoutineManager.Vistas;

public partial class DaySelector : ContentPage
{
	private readonly RManagerDbContext _context;
	private readonly DaySelectorViewModel _viewModel;
    private int _routineId;
    public DaySelector(int routineId, RManagerDbContext context)
	{
		_context = context;
		InitializeComponent();
		_viewModel = new DaySelectorViewModel(_context);
		BindingContext = _viewModel;
        _routineId = routineId;
        _viewModel.RoutineId = routineId;
    }
}  