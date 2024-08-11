namespace RoutineManager;

public partial class RoutineCreator : ContentPage
{

    public string text1 {  get; set; }
    public string text2 {  get; set; }

    private string entryValueOne { get; set; }
    private string entryValueTwo { get; set; }
    public RoutineCreator()
    {
        InitializeComponent();
        
    }
    public event Action<string> ValueConfirmed;
    private async void AddRoutineButtonClicked(object sender, EventArgs e)
    {
        ValueConfirmed?.Invoke(entryValue.Text);
        await Navigation.PopAsync(); 
    }

    public void OnEntryCompleted(object sender, EventArgs e)
    {
        entryValueOne = ((Entry)sender).Text;
    }

    public void OnEntryCompletedTwo(object sender, EventArgs e)
    {
        entryValueTwo = ((Entry)sender).Text;
    }
}
