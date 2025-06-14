using System;

namespace RetoProgramacion2
{
    // Clase principal que contiene la lógica del programa
    class Program
    {
        // Método principal, punto de entrada del programa
        static void Main(string[] args)
        {
            // Solicita al usuario que ingrese un valor numérico
            Console.WriteLine("Ingresa un valor numérico");

            // Llama a la función IngresarDato para obtener un número entero válido
            int numero = IngresarDato();

            // Condicional que evalúa si el número es positivo, negativo o cero
            if (numero > 0)
            {
                // Si el número es mayor que cero, muestra un mensaje indicando que es positivo
                Console.WriteLine($"El número {numero} es positivo");
            }
            else if (numero < 0)
            {
                // Si el número es menor que cero, muestra un mensaje indicando que es negativo
                Console.WriteLine($"El número {numero} es negativo");
            }
            else
            {
                // Si el número es igual a cero, muestra un mensaje correspondiente
                Console.WriteLine($"El número que ingresaste es 0");
            }
        }

        // Función que solicita al usuario ingresar un número entero válido
        static int IngresarDato()
        {
            // Variable para almacenar el número ingresado
            int dato;
            // Variable para guardar la entrada del usuario como texto
            string entrada;

            // Bucle que continúa solicitando datos hasta que se ingrese un valor válido
            do
            {
                // Lee la entrada del usuario desde la consola
                entrada = Console.ReadLine() ?? "";

                // Intenta convertir la entrada a un número entero
                bool resultado = int.TryParse(entrada, out dato);

                // Si la conversión es válida, retorna el número
                if (resultado)
                {
                    return dato;
                }
                else
                {
                    // Si no es válido, muestra un mensaje de error
                    Console.WriteLine("Ingresar otro número");
                }
            } while (true); // El bucle se repite indefinidamente hasta obtener un número válido
        }
    }
}
