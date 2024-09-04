using Microsoft.Maui.Controls;
using System.Windows.Input;

namespace RoutineManager;
public class MainPageViewModel
{
    public ICommand NewRoutineCommand { get; }
    public ICommand RoutineDaysCommand { get; }

    public MainPageViewModel()
    {
        NewRoutineCommand = new Command(async () => await OnNewRoutineClicked());
        RoutineDaysCommand = new Command(async () => await OnRoutineDaysClicked());
    }

    private async Task OnNewRoutineClicked()
    {
        // Crea y navega a RoutineCreator
        var routineCreator = new NewRoutineButton.RoutineCreator();
        await Application.Current.MainPage.Navigation.PushAsync(routineCreator);
    }

    private async Task OnRoutineDaysClicked()
    {
        // Crea y navega a DaysOfRoutine
        var rutinadias = new Routine.DaysOfRoutine();
        await Application.Current.MainPage.Navigation.PushAsync(rutinadias);
    }
}
