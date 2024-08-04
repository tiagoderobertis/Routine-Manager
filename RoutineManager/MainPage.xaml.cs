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

        private async void OnButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Rutinas.RutinaUno());
        }

    }

}
