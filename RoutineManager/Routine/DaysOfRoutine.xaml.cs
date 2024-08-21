namespace RoutineManager.Routine;

public partial class DaysOfRoutine : ContentPage
{
	public DaysOfRoutine()
	{
		InitializeComponent();
        BindingContext = new DaysOfRoutineVM();
    }

}