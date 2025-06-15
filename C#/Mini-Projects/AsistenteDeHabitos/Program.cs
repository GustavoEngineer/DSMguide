using System;

namespace AsistenteDeHabitos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido a tu Asistente de Hábitos");
            Console.WriteLine("1.Registrar hábito\n2.Marcar hábito como cumplido hoy\n3.Ver estado de mis hábitos\n4.Salir");
            Console.WriteLine("Seleccionar una opción");

            string opcion = Console.ReadLine() ?? "";

            switch (opcion)
            {
                case "1":
                    RegistrarHabito();
                    break;
                case "2":
                    MarcarHábito();
                    break;
                case "3":
                    VerEstado();
                    break;
                case "4":
                    Console.WriteLine("Saliendo...");
                    return;
            }
        }
        static void RegistrarHabito()
        {

        }

        static void MarcarHábito()
        {

        }

        static void VerEstado()
        {

        }
    }
}