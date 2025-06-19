using System;

namespace RelojDigital
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime Today = DateTime.Today;
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("Elige una opción:\n1.Ver fecha\n2.Ver hora\n3.Salir");
                string opcion = Console.ReadLine() ?? "";
                if (!int.TryParse(opcion, out var result))
                {
                    Console.WriteLine("No se pudo realizar la conversión, ingresa otro número");
                    continue;
                }

                switch (result)
                {
                    case 1:
                        Console.WriteLine($"\n============\nLa fecha de hoy es:({Today.ToString("dd/MM/yyyy")}\n============\n");
                        Console.ReadKey();
                        break;
                    case 2:
                        DateTime now = DateTime.Now;
                        string Hora = now.ToString("HH:mm:ss tt");
                        Console.WriteLine("\n============\nLa hora es: " + Hora + "\n============\n");
                        break;
                    case 3:
                        Console.WriteLine("Saliendo...");
                        return;
                    default:
                        Console.WriteLine("Elige otra opción");
                        continue;
                }
            }
        }
    }
}