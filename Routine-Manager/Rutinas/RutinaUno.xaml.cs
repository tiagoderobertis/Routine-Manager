namespace RoutineManager.Rutinas;

public partial class RutinaUno : ContentPage
{
	public RutinaUno()
	{
		InitializeComponent();
    }

    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

}