using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;
using RoutineManager.Routine;
using RoutineManager.Connection;

namespace RoutineManager
{
    public partial class App : Application
    {
        public static RManagerDbContext DbContext { get; private set; }
        private static IServiceProvider _serviceProvider;

        public App()
        {
            InitializeComponent();
            var optionsBuilder = new DbContextOptionsBuilder<RManagerDbContext>();
            optionsBuilder.UseSqlite($"Filename={Utilities.DbPath.DevolverRuta("RMDB.db")}");
            DbContext = new RManagerDbContext(optionsBuilder.Options);

            // Crea la instancia de MainPage pasando el contexto
            MainPage = new NavigationPage(new MainPage(DbContext));
        }

        public static void SetServiceProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public static IServiceProvider ServiceProvider => _serviceProvider;
    }
}
