using System;
using System.Collections.Generic;

namespace BuscarElementos
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> aplicacionesCelular = new List<string>
            {
                "Whatsapp",
                "Instagram",
                "Tiktok",
                "Spotify",
                "Netflix"
            };

            // Verificar si existe una aplicación
            if (aplicacionesCelular.Contains("Whatsapp"))
            {
                Console.WriteLine("¡Sí tengo Whatsapp intalado!");
            }

            // Encontrar la pocisión de una aplicación
            int pocision = aplicacionesCelular.IndexOf("Spotify");
            Console.WriteLine($"Spotify está en la pocisión: {pocision}");
        }
    }
}