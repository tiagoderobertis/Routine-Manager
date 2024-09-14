using CommunityToolkit.Maui;
namespace RoutineManager.Vistas;

public partial class RoutineAdder : ContentPage
{
	public RoutineAdder()
	{
		InitializeComponent();
		BindingContext = new ModeloVistas.RoutineAdderViewModel();
	}
}