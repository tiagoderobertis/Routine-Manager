using System;
using System.IO;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;

namespace RoutineManager.Utilities
{
    public static class DbPath
    {
        public static string DevolverRuta(string nombreBaseDatos)
        {
            string rutaBaseDatos = string.Empty;

            if (DeviceInfo.Platform == DevicePlatform.Android)
            {
                rutaBaseDatos = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                rutaBaseDatos = Path.Combine(rutaBaseDatos, nombreBaseDatos);
            }
            else if (DeviceInfo.Platform == DevicePlatform.WinUI)
            {
                // Usar la carpeta Documents para Windows
                rutaBaseDatos = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), nombreBaseDatos);
            }

            Console.WriteLine($"Ruta de la base de datos: {rutaBaseDatos}");
            return rutaBaseDatos;
        }
    }
}
