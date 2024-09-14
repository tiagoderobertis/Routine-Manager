using Button = Microsoft.Maui.Controls.Button;
using RoutineManager.Connection;
using Microsoft.EntityFrameworkCore;
using Application = Microsoft.Maui.Controls.Application;
using RoutineManager.ModeloVistas;

namespace RoutineManager
{
    public partial class MainPage : ContentPage
    {

        private readonly RManagerDbContext _context;
        private readonly MainPageViewModel _viewModel;


        public MainPage(RManagerDbContext context)
        {
            _context = context;
            InitializeComponent();
            _viewModel = new MainPageViewModel(); //  se inicializa el viewmodel
            BindingContext = _viewModel; // se bindea con el viewmodel
            CheckCreated(); // se verifica si hay rutinas creadas
            MessagingCenter.Subscribe<ModeloVistas.RoutineCreatorViewModel, string>(this, "AddButton", (sender, buttonText) =>
            {
                AddButtonToPage(buttonText);
            }); // se suscribe al mensaje cuando el usuario agrega una rutina nueva
        }

        private async Task CheckCreated()
        {
            List<int> id = [1, 2, 3, 4, 5, 6];

            
            foreach (var i in id)
            {
                bool exists = await _context.Routines.AnyAsync(r => r.ID_Routine.Equals(i));
                // verifica si hay rutinas creadas, una por una hasta la ultima de la lista id
                if (exists) // si encuentra una rutina creada, construye el boton
                {
                    LabelRutina.IsVisible = false;
                    string nombreRutina = await _context.Routines
                        .Where(r => r.ID_Routine.Equals(i))
                        .Select(r => r.Name)
                        .FirstOrDefaultAsync(); // encuentra el nombre de la rutina por id


                    Button btn_routine = new Button
                    {
                        Text = nombreRutina,
                        Command = new Command(async () => await NavigateToDaySelector(i)),
                        CommandParameter = i

                    }; // se construye el boton
                    StackLayoutMain.Children.Add(btn_routine); // se agrega a la vista
                }
            }

        }
        private async Task NavigateToDaySelector(int routineId)
        {
            // Aquí navegas a la página DaySelector y le pasas el ID de la rutina seleccionada
            await Application.Current.MainPage.Navigation.PushAsync(new Vistas.DaySelector(routineId, _context));
        }

        private async Task OnButtonRoutineClicked()
        {
            // Crea y navega a RoutineCreator
            var routineCreator = new Vistas.RoutineCreator();
            await Application.Current.MainPage.Navigation.PushAsync(routineCreator);
        }

        private void AddButtonToPage(string buttonText) // metodo para añadir el boton apenas el usuario cree su rutina
        {
            Button newButton = new Button
            {
                Text = buttonText,
                
            };

            StackLayoutMain.Children.Add(newButton);  
        }
    }
}


