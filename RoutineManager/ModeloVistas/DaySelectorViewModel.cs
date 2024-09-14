using RoutineManager.Connection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RoutineManager.ModeloVistas
{
 

    public class DaySelectorViewModel : INotifyPropertyChanged
    {
        private readonly RManagerDbContext _db;
        private int _routineId;

        public event PropertyChangedEventHandler? PropertyChanged;

        public int RoutineId
        {
            get => _routineId;
            set
            {
                _routineId = value;
                OnPropertyChanged(nameof(RoutineId));
            }
        }
        public DaySelectorViewModel(RManagerDbContext db)
        {
            _db = db;
            
        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
