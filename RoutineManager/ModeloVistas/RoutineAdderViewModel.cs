using RoutineManager.Connection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using RoutineManager.Data_Access;
using RoutineManager.Modelos;

namespace RoutineManager.ModeloVistas
{
    public class RoutineAdderViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private readonly ExerciseRepository _exerciseRepository;
        private readonly RManagerDbContext _db;
        public RoutineAdderViewModel(RManagerDbContext db, ExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
            _db = db;
            SaveCommand = new Command(async () => await SaveExercise());
        }

        #region Properties

        private string _exerciseName;
        public string ExerciseName
        {
            get => _exerciseName;
            set
            {
                if (_exerciseName != value)
                {
                    _exerciseName = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _minutesInput;
        public string MinutesInput
        {
            get => _minutesInput;
            set
            {
                if (_minutesInput != value)
                {
                    _minutesInput = value;
                    OnPropertyChanged();
                    UpdateExerciseDuration();
                }
            }
        }

        private string _secondsInput;
        public string SecondsInput
        {
            get => _secondsInput;
            set
            {
                if (_secondsInput != value)
                {
                    _secondsInput = value;
                    OnPropertyChanged();
                    UpdateExerciseDuration();
                }
            }
        }

        private TimeSpan _exerciseDuration;
        public TimeSpan ExerciseDuration
        {
            get => _exerciseDuration;
            private set
            {
                if (_exerciseDuration != value)
                {
                    _exerciseDuration = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region Methods

        private void UpdateExerciseDuration()
        {
            int minutes = int.TryParse(MinutesInput, out int m) ? m : 0;
            int seconds = int.TryParse(SecondsInput, out int s) ? s : 0;
            ExerciseDuration = new TimeSpan(0, minutes, seconds);
        }

        public ICommand SaveCommand { get; }

        private async Task SaveExercise()
        {
            // Verifica que el nombre del ejercicio no esté vacío
            if (string.IsNullOrWhiteSpace(ExerciseName))
            {
                throw new InvalidOperationException("El nombre del ejercicio no puede estar vacío.");
            }

            // Crea un nuevo ejercicio
            var newExercise = new Exercise
            {
                Exercise_Name = ExerciseName
            };

            // Guarda el nuevo ejercicio en la base de datos
            await _exerciseRepository.AddExerciseAsync(newExercise);
            await _db.SaveChangesAsync();
        }
        

        #endregion

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
