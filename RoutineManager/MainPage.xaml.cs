using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;

namespace RoutineManager
{
    public partial class MainPage : ContentPage
    {

        private string _motivacion = "";


        public string motivacion
        {
            get => _motivacion;
            set
            {
                if (_motivacion != value)
                {
                    _motivacion = value;
                    OnPropertyChanged();
                }
            }
        }

        

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            
        }

        string text1;

        private async void newRoutineOnClicked(object sender, EventArgs e)
        {
            var routineCreator = new RoutineCreator();

            // Suscribirse al evento ValueConfirmed
            routineCreator.ValueConfirmed += (value) =>
            {
                lblResult.Text = value;
            };

            await Navigation.PushAsync(routineCreator);
        }

    }

}
