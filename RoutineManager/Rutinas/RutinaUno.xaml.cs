namespace RoutineManager.Rutinas;

public partial class RutinaUno : ContentPage
{
	public RutinaUno()
	{
		InitializeComponent();
        BindingContext = new RutinaUnoViewModel();
    }

}