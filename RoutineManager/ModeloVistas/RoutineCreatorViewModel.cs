using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using RoutineManager.Modelos;
using RoutineManager.Routine;
using RoutineManager.Connection;
using RoutineManager.Data_Access;
using RoutineManager.Vistas;
using Microsoft.EntityFrameworkCore;

namespace RoutineManager.ModeloVistas
{
    class RoutineCreatorViewModel : INotifyPropertyChanged
    {


        public event PropertyChangedEventHandler? PropertyChanged;

        private readonly RManagerDbContext _db;
        private readonly RoutinesRepository _routineRepository;
        private readonly ExerciseRepository _exerciseRepository;
        private readonly RoutinesExerciseRepository _routinesExerciseRepository;

        public RoutineCreatorViewModel(
            RoutinesRepository routineRepository,
            ExerciseRepository exerciseRepository,
            RoutinesExerciseRepository routinesExerciseRepository,
            RManagerDbContext db
        )
        {
            _db = db;
            AddRoutineAndVerifyCommand = new Command(async () => await AddRoutineOnClicked());
            AddExercisesCommand = new Command(async () => await AddExercisesOnClicked());
            _routineRepository = routineRepository;
            _exerciseRepository = exerciseRepository;
            _routinesExerciseRepository = routinesExerciseRepository;
        }

        #region Properties
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        private string _description;
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        private string _labelError = "";
        public string LabelError
        {
            get => _labelError;
            set
            {
                _labelError = value;
                OnPropertyChanged();
            }
        }

        
        private int _days = 4;
        public int Days
        {
            get => _days;
            set
            {
                _days = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Methods
        public ICommand AddRoutineAndVerifyCommand { get; }

        private async Task AddRoutineOnClicked()
        {
            try
            {
                int routineCount = await _db.Routines.CountAsync(); // Cuenta la cantidad de rutinas creadas
                if (routineCount < 5) // Si las rutinas son menor a 5
                {
                    if (string.IsNullOrWhiteSpace(_name)) 
                    {
                        LabelError = "Completa los campos";
                    } // Se verifica que los campos esten completos
                    else
                    {
                        var newRoutine = new Routines
                        {
                            Name = _name,
                            Description = _description,
                            Id_day = Days
                        };
                        await _routineRepository.AddRoutineAsync(newRoutine);
                        AddButton();
                        await Application.Current.MainPage.Navigation.PopAsync();
                    } // Cuando los campos esten completos, se crea la rutina nueva
                }
                else
                {
                    LabelError = "Ya existen 5 rutinas creadas";
                } // Si la cantidad de rutinas es igual o mayor a 5, no podras crear mas rutinas.
            }
            catch (Exception ex)
            {
                LabelError = $"Error: {ex.Message}";
                if (ex.InnerException != null)
                {
                    LabelError += $" Inner Error: {ex.InnerException.Message}";
                }
            } // Verificacion de errores temporal
        }


        public ICommand AddExercisesCommand { get; }

        private async Task AddExercisesOnClicked()
        {
            var routineAdder = new RoutineAdder(_db);
            await Application.Current.MainPage.Navigation.PushAsync(routineAdder);
        } // 

        private void AddButton()
        {
            MessagingCenter.Send(this, "AddButton", Name);
        } // Se manda un mensaje al codigo subyacente del mainpage, para que este
          // añada un boton apenas el usuario crea la rutina.
        #endregion

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}

