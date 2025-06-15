using System;
using System.Collections.Generic;

namespace Clear
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> notificaciones = new List<string>
            {
                "Mensaje de Whatsapp",
                "Email nuevo",
                "Actualización disponible"
            };

            Console.WriteLine($"Notificaciones: {notificaciones.Count}");
            notificaciones.Clear();
            Console.WriteLine($"Notificaciones: {notificaciones.Count}");
        }
    }
}