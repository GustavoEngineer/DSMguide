using System;

namespace RetoProgramación3
{
    // Definición de la clase 'Program', donde está el punto de entrada del programa.
    class Program
    {
        // Método principal (Main) que se ejecuta cuando se inicia el programa
        static void Main(string[] args)
        {
            // Imprime un mensaje al usuario indicando el propósito del programa
            Console.WriteLine("Este programa imprime los números del 1 al 10");

            // Bucle 'for' que itera desde 1 hasta 10 (inclusive)
            // i = 1: Inicia en 1
            // i <= 10: Continúa mientras i sea menor o igual a 10
            // i++: Incrementa el valor de i en 1 en cada iteración
            for (int i = 1; i <= 10; i++)
            {
                // Imprime el número actual en cada iteración del bucle
                // Se usa interpolación de cadenas con $ para incluir el valor de 'i' en el mensaje
                Console.WriteLine($"Este es el número {i}");
            }
        }
    }
}
