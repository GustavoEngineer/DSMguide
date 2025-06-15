using System;
using System.Collections.Generic;

namespace Clear
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> estudiantes = new List<string>
            {
                "Carlos",
                "Ana",
                "Bruno",
                "Diana"
            };

            Console.WriteLine("Lista Original:");
            foreach (string estudiante in estudiantes)
            {
                Console.WriteLine($"{estudiante}");
            }

            estudiantes.Sort();
            foreach (string estudiante in estudiantes)
            {
                Console.WriteLine($"{estudiante}");
            }
        }
    }
}