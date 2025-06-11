/*
📝 Ejercicio 1: Mostrar tu nombre y edad en consola
    -Declarar dos variables (nombre y edad)
    -Asignarles valores
    -Luego imprimirlas en pantalla.
*/

using System;

namespace Ejercicio1
{
    class Program
    {
        static void Main(string[] args)
        {
            string nombre = PedirNombre();
            int edad = PedirEdad();

            Console.WriteLine($"Hola C#. Mi nombre es {nombre} y tengo {edad} años de edad.");
        }

        static string PedirNombre()
        {
            Console.WriteLine("¿Cuál es tu nombre?");
            string nombre = Console.ReadLine() ?? "";
            return nombre;
        }

        static int PedirEdad()
        {
            int edad;
            while (true)
            {
                Console.WriteLine("¿Cuántos años tienes?");
                string entrada = Console.ReadLine() ?? "";
                if (int.TryParse(entrada, out edad) && edad >= 0)
                {
                    return edad;
                }

                Console.WriteLine("Porfavor, ingresar un número valido para edad");
            }
        }
    }
}