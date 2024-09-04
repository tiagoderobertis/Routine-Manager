namespace RoutineManager.NewRoutineButton;

public partial class RoutineCreator : ContentPage
{
    
public event Action<string, string> ValuesConfirmed;

    public RoutineCreator()
    {
        InitializeComponent();
        BindingContext = new RoutineCreatorViewModel();
    }

    

}
