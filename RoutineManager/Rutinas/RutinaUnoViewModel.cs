using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using RoutineManager.Dias;

namespace RoutineManager.Rutinas
{
    public class RutinaUnoViewModel : BindableObject
    {
        private ObservableCollection<DayItem> _daysOfWeek;

        public RutinaUnoViewModel()
        {
            // Inicializa la lista de días de la semana
            DaysOfWeek = new ObservableCollection<DayItem>
            {
                new DayItem { DayName = "LUNES", ExerciseTitle = "Espalda", ExerciseDetail = "" },
                new DayItem { DayName = "MARTES", ExerciseTitle = "Pierna", ExerciseDetail = "" },
                new DayItem { DayName = "MIÉRCOLES", ExerciseTitle = "Pecho", ExerciseDetail = "" },
                new DayItem { DayName = "JUEVES", ExerciseTitle = "Músculos Chicos", ExerciseDetail = "" },
                new DayItem { DayName = "VIERNES", ExerciseTitle = "Brazo", ExerciseDetail = "" }
            };

            // Define el comando para manejar los eventos de toque en los elementos
            YourCommand = new Command<DayItem>(async (dayItem) => await OnDayItemTapped(dayItem));
        }

        public ObservableCollection<DayItem> DaysOfWeek
        {
            get => _daysOfWeek;
            set
            {
                _daysOfWeek = value;
                OnPropertyChanged();
            }
        }

        public ICommand YourCommand { get; }

        private async Task OnDayItemTapped(DayItem dayItem)
        {
            Page page = dayItem.DayName switch
            {
                "LUNES" => new Dias.Lunes(),
                // Otros días...
                _ => null
            };

            if (page != null)
            {
                await Shell.Current.Navigation.PushAsync(page);
            }
        }
    }

    public class DayItem
    {
        public string DayName { get; set; }
        public string ExerciseTitle { get; set; }
        public string ExerciseDetail { get; set; }
    }
}
