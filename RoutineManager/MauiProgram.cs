using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using RoutineManager.Connection;
using RoutineManager.Data_Access;
using RoutineManager.ModeloVistas;
using Microsoft.EntityFrameworkCore;

namespace RoutineManager
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Preview.otf", "Preview");
                    fonts.AddFont("Accuratist.otf", "Accu");
                });

            // Configura el DbContext para usar SQLite
            builder.Services.AddDbContext<RManagerDbContext>(options =>
                options.UseSqlite($"Filename={Utilities.DbPath.DevolverRuta("RMDB.db")}"));

            builder.Services.AddTransient<ExerciseRepository>();
            builder.Services.AddTransient<RoutinesRepository>();
            builder.Services.AddTransient<RoutinesExerciseRepository>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            var app = builder.Build();

            // Asignar el ServiceProvider a la instancia de la aplicación
            var serviceProvider = app.Services;
            App.SetServiceProvider(serviceProvider);

            return app;
        }
    }
}

