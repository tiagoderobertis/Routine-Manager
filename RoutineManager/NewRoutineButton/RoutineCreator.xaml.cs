namespace RoutineManager.NewRoutineButton;

public partial class RoutineCreator : ContentPage
{
    public string nombreRutina { get; set; }
    public string descripcionRutina { get; set; }

    public int oneDay { get; set; } = 1;
    public int twoDays { get; set; } = 2;
    public int threeDays { get; set; } = 3;
    public int fourDays{ get; set; } = 4;
    public int fiveDays{ get; set; } = 5;
    public int sixDays{ get; set; } = 6;
    public int sevenDays { get; set; } = 7;


public event Action<string, string> ValuesConfirmed;

    public RoutineCreator()
    {
        InitializeComponent();
    }

    private async void AddRoutineButtonClicked(object sender, EventArgs e)
    {
        ValuesConfirmed?.Invoke(nombreRutina, descripcionRutina);
        await Navigation.PopAsync();
    }


    public async void AddExerciseToRoutineOnClicked(object sender, EventArgs e)
    {
        var daySelector = new DaySelector();
        await Navigation.PushAsync(daySelector);
    }

    public void OnEntryNombreChanged(object sender, EventArgs e)
    {
        nombreRutina = entryNombreValue.Text;
    }

    public void OnEntryDescripcionChanged(object sender, EventArgs e)
    {
        descripcionRutina = entryDescripcionValue.Text;
    }

    private void OnDayCheckedChanged(object sender, EventArgs e)
    {
        
        {
            if (OneDay.IsChecked)
            {
                TwoDays.IsChecked = false;
                ThreeDays.IsChecked = false;
                FourDays.IsChecked = false;
                FiveDays.IsChecked = false;
                SixDays.IsChecked = false;
                SevenDays.IsChecked = false;
            }
            else if (TwoDays.IsChecked)
            {
                OneDay.IsChecked = false;
                ThreeDays.IsChecked = false;
                FourDays.IsChecked = false;
                FiveDays.IsChecked = false;
                SixDays.IsChecked = false;
                SevenDays.IsChecked = false;
            }
            else if (ThreeDays.IsChecked)
            {
                OneDay.IsChecked = false;
                TwoDays.IsChecked = false;
                FourDays.IsChecked = false;
                FiveDays.IsChecked = false;
                SixDays.IsChecked = false;
                SevenDays.IsChecked = false;
            }
            else if (FourDays.IsChecked)
            {
                OneDay.IsChecked = false;
                TwoDays.IsChecked = false;
                ThreeDays.IsChecked = false;
                FiveDays.IsChecked = false;
                SixDays.IsChecked = false;
                SevenDays.IsChecked = false;
            }
            else if (FiveDays.IsChecked)
            {
                OneDay.IsChecked = false;
                TwoDays.IsChecked = false;
                ThreeDays.IsChecked = false;
                FourDays.IsChecked = false;
                SixDays.IsChecked = false;
                SevenDays.IsChecked = false;
            }
            else if (SixDays.IsChecked)
            {
                OneDay.IsChecked = false;
                TwoDays.IsChecked = false;
                ThreeDays.IsChecked = false;
                FourDays.IsChecked = false;
                FiveDays.IsChecked = false;
                SevenDays.IsChecked = false;
            }
            else if (SevenDays.IsChecked)
            {
                OneDay.IsChecked = false;
                TwoDays.IsChecked = false;
                ThreeDays.IsChecked = false;
                FourDays.IsChecked = false;
                FiveDays.IsChecked = false;
                SixDays.IsChecked = false;
            }

            else if (SixDays.IsChecked)
            {
                OneDay.IsChecked = false;
                TwoDays.IsChecked = false;
                ThreeDays.IsChecked = false;
                FourDays.IsChecked = false;
                FiveDays.IsChecked = false;
                SevenDays.IsChecked = false;
            }

            else if (FiveDays.IsChecked)
            {
                OneDay.IsChecked = false;
                TwoDays.IsChecked = false;
                ThreeDays.IsChecked = false;
                FourDays.IsChecked = false;
                SixDays.IsChecked = false;
                SevenDays.IsChecked = false;
            }

            else if (FourDays.IsChecked)
            {
                OneDay.IsChecked = false;
                TwoDays.IsChecked = false;
                ThreeDays.IsChecked = false;
                FiveDays.IsChecked = false;
                SixDays.IsChecked = false;
                SevenDays.IsChecked = false;
            }

            else if (ThreeDays.IsChecked)
            {
                OneDay.IsChecked = false;
                TwoDays.IsChecked = false;
                FourDays.IsChecked = false;
                FiveDays.IsChecked = false;
                SixDays.IsChecked = false;
                SevenDays.IsChecked = false;
            }

            else if (TwoDays.IsChecked)
            {
                OneDay.IsChecked = false;
                ThreeDays.IsChecked = false;
                FourDays.IsChecked = false;
                FiveDays.IsChecked = false;
                SixDays.IsChecked = false;
                SevenDays.IsChecked = false;
            }

            if (OneDay.IsChecked)
            {
                TwoDays.IsChecked = false;
                ThreeDays.IsChecked = false;
                FourDays.IsChecked = false;
                FiveDays.IsChecked = false;
                SixDays.IsChecked = false;
                SevenDays.IsChecked = false;
            }
        }
    }

    bool selectedDay;
    public int OnCheckedCheckboxes(object sender, EventArgs e)
    {

        
        if (OneDay.IsChecked) return oneDay;
        else if (TwoDays.IsChecked) return twoDays;
        else if (ThreeDays.IsChecked) return threeDays;
        else if (FourDays.IsChecked) return fourDays;
        else if (FiveDays.IsChecked) return fiveDays;
        else if (SixDays.IsChecked) return sixDays;
        else if (SevenDays.IsChecked) return sevenDays;

        return 0;
    }

}
