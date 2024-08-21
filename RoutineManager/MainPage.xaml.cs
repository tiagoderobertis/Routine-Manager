using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;
using Button = Microsoft.Maui.Controls.Button;

namespace RoutineManager
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private async void newRoutineOnClicked(object sender, EventArgs e)
        {
            NewRoutineButton.RoutineCreator routineCreator = new NewRoutineButton.RoutineCreator();

            // Suscribirse al evento ValuesConfirmed
            routineCreator.ValuesConfirmed += OnRoutineCreated;

            await Navigation.PushAsync(routineCreator);
        }

        private async void OnButtonClicked(object sender, EventArgs e)
        {
            Routine.DaysOfRoutine rutinadias = new Routine.DaysOfRoutine();
            await Navigation.PushAsync(rutinadias);
        }

        
        private void OnRoutineCreated(string nombre, string descripcion)
        {

            var nuevoBoton = new Button
            {
                Text = nombre,
                WidthRequest = 300,
                HeightRequest = 100,
                BackgroundColor = Color.FromHex("#455a64"),
                BorderColor = Color.FromArgb("#546e7a"),
                BorderWidth = 1,
                FontAutoScalingEnabled = true,
                TextColor = Color.FromRgb(000, 000, 000),
                FontSize = 18,
                FontFamily = "Arial"

            };

            nuevoBoton.Clicked += OnButtonClicked;

            // Añadir el botón a un layout en la MainPage
            stackLayoutBotones.Children.Add(nuevoBoton); // Asumiendo que tienes un StackLayout llamado stackLayoutBotones
        }
    }
}

