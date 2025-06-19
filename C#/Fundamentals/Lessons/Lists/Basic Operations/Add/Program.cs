using System;
using System.Collections.Generic;

namespace BasicOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Agregar Elementos (Add)
            List<string> peliculasFavoritas = new List<string>();

            // Agregar películas
            peliculasFavoritas.Add("Avengers");
            peliculasFavoritas.Add("Spider-Man");
            peliculasFavoritas.Add("Batman");

            Console.WriteLine($"Tengo {peliculasFavoritas.Count} películas favoritas");
            // Resultado: Tengo 3 películas favoritas
        }
    }
}