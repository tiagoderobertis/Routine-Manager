using Microsoft.Maui.Controls;
using System.ComponentModel;

namespace RoutineManager
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        private string _motivacion = "dreams come true";

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
