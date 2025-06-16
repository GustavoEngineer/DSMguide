using System;
using System.Collections.Generic;

namespace AccederElementosPorIndice
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> materiasUniversidad = new List<string>
            {
                "Programación",
                "Base de Datos",
                "Redes",
                "Matemáticas"
            };

            // Los índices empiezan por 0
            Console.WriteLine($"Mi primera materia: {materiasUniversidad[0]}");
            Console.WriteLine($"Mi segunda materia: {materiasUniversidad[1]}");
            Console.WriteLine($"Mi tercera materia: {materiasUniversidad[2]}");
        }
    }
}