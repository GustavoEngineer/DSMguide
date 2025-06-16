using System;
using System.Collections.Generic;

namespace AsistenteDeHabitos
{
    class Program
    {
        public class HabitosUsuario
        {
            public string Nombre { get; set; }
            public List<bool> checklist { get; set; }

            public HabitosUsuario(string nombre)
            {
                Nombre = nombre;
                checklist = new List<bool>();
            }
        }

        static void Main(string[] args)
        {
            // Mis listas
            List<string> habitos = new List<string>();
            List<int> dias = new List<int>();

            // Flujo del programa al usuario final
            Console.WriteLine("Bienvenido a tu Asistente de Hábitos");
            Console.WriteLine("1.Registrar hábito\n2.Marcar hábito como cumplido hoy\n3.Ver estado de mis hábitos\n4.Avanzar al siguiente día\n5.Salir");


            while (true)
            {
                Console.WriteLine("Seleccionar una opción");
                int opcion = Convert.ToInt32(Console.ReadLine() ?? "");

                switch (opcion)
                {
                    case 1:
                        RegistrarHabito(habitos);
                        break;
                    case 2:
                        MarcarHábito();
                        break;
                    case 3:
                        VerEstado();
                        break;
                    case 4:
                        AvanzarDiaSiguiente();
                        break;
                    case 5:
                        Console.WriteLine("Saliendo...");
                        return;
                    default:
                        Console.WriteLine("Porfavor, pon una opción valida.");
                        continue;
                }
            }
        }
        static void RegistrarHabito(List<string> lista)
        {
            Console.WriteLine("¿Qué hábito te gustaría agregar?");
            string entrada = Console.ReadLine() ?? "";
            lista.Add(entrada);

            int nuevoItem = lista.Count - 1;
            Console.WriteLine($"El nuevo hábito: {lista[nuevoItem]}.\n✅ Se ha agregado exitosamente.\n");
        }

        static void MarcarHábito()
        {

        }

        static void VerEstado()
        {

        }
        static void AvanzarDiaSiguiente()
        {

        }
    }
}