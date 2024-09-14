using Microsoft.Maui.Controls;
using System.Windows.Input;
using RoutineManager.Vistas;
using RoutineManager.Modelos;
using RoutineManager.Connection;


namespace RoutineManager.ModeloVistas;
public class MainPageViewModel
{
    public ICommand NewRoutineCommand { get; }
    public ICommand RoutineDaysCommand { get; }
    public Routines routine { get; }
    private readonly RManagerDbContext _dbContext;
    public MainPageViewModel()
    {
        NewRoutineCommand = new Command(async () => await OnNewRoutineClicked());
        RoutineDaysCommand = new Command(async () => await OnRoutineDaysClicked());
    }

    


    private async Task OnNewRoutineClicked()
    {
        // Crea y navega a RoutineCreator
        var routineCreator = new Vistas.RoutineCreator();
        await Application.Current.MainPage.Navigation.PushAsync(routineCreator);
    }

    private async Task OnRoutineDaysClicked()
    {
        // Crea y navega a DaysOfRoutine
        var rutinadias = new Routine.DaysOfRoutine();
        await Application.Current.MainPage.Navigation.PushAsync(rutinadias);
    }
}
