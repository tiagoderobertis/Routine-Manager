using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace RoutineManager
{
    public class MainPageViewModel : BindableObject
    {

        private ObservableCollection<DayItem> _daysOfWeek;

        public MainPageViewModel()
        {
            // Inicializa la lista de días de la semana
            DaysOfWeek = new ObservableCollection<DayItem>
            {
                new DayItem { DayName = "LUNES", ExerciseDetail = "" },
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
                "" => new Dias.Lunes(),
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
