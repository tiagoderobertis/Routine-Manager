using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace RoutineManager.NewRoutineButton
{
    class RoutineCreatorViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        #region properties
        private string _nombreRutina;
        public string NombreRutina
        {
            get => _nombreRutina;
            set
            {
                _nombreRutina = value;
                OnPropertyChanged();
            }
        }
        private string _descripcionRutina;
        public string DescripcionRutina
        {
            get => _descripcionRutina;
            set
            {
                _descripcionRutina = value;
                OnPropertyChanged();
            }
        }

        private int _diasRutina = 4;
        public int DiasRutina
        {
            get => _diasRutina;
            set
            {
                _diasRutina = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region methods
        public ICommand AddRoutineCommand { get; }
        private async Task AddRoutineOnClicked()
        {
            AddButton();
            await Application.Current.MainPage.Navigation.PopAsync();
            // Agrega el comando aquí si es necesario
        }

        public ICommand AddExercisesCommand { get; }

        private async Task AddExercisesOnClicked()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new NewRoutineButton.RoutineAdder());
        }

        
        private void AddButton()
        {
            MessagingCenter.Send(this, "AddButton", "Nuevo Botón");
        }
        #endregion
        public RoutineCreatorViewModel()
        {
            AddRoutineCommand = new Command(async () => await AddRoutineOnClicked());
            AddExercisesCommand = new Command(async () => await AddExercisesOnClicked());
        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
