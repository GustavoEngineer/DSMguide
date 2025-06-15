using System;
using System.Collections.Generic;

namespace EliminarElementos
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> comidaRefrigerador = new List<string>
            {
                "Lecha",
                "Huevos",
                "Pan",
                "Queso",
                "Jamón"
            };

            // Eliminar por elemento específico
            comidaRefrigerador.Remove("Pan");
            comidaRefrigerador.RemoveAt(0);

            Console.WriteLine("Comida restante");
            foreach (string comida in comidaRefrigerador)
            {
                Console.WriteLine($"- {comida}");
            }

        }
    }
}