using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;
using Button = Microsoft.Maui.Controls.Button;

namespace RoutineManager
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();

            // Suscríbete al mensaje usando MessagingCenter
            MessagingCenter.Subscribe<NewRoutineButton.RoutineCreatorViewModel, string>(this, "AddButton", (sender, buttonText) =>
            {
                AddButtonToPage(buttonText);
            });
        }

        private void AddButtonToPage(string buttonText)
        {
            Button newButton = new Button
            {
                Text = buttonText // Usa el texto recibido
            };

            StackLayoutMain.Children.Add(newButton);
        }
    }
}


