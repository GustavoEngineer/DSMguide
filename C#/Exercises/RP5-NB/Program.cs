using System;

namespace RetoProgramacion5
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] nombres = { "Juan", "Lee", "Jorge", "Uziel", "Erick", "Carlos", "Blanca" };

            foreach (string nombre in nombres)
            {
                Console.WriteLine("El nombre es: " + nombre);
            }
        }
    }
}