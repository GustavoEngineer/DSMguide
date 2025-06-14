using System;

namespace RetoProgramación1
{
    // Clase principal que contiene la lógica del programa
    class Program
    {
        // Método principal, punto de entrada del programa
        static void Main(string[] args)
        {
            // Solicita al usuario que ingrese un número entero
            Console.WriteLine("Escribe un número entero");

            // Llama a la función NumeroIngresado para obtener un número válido
            int numero = NumeroIngresado();

            // Condicional que verifica si el número es mayor a 10
            if (numero > 10)
            {
                // Si el número es mayor que 10, muestra un mensaje
                Console.WriteLine("El número es mayor a 10");
            }
            else
            {
                // Si el número no es mayor que 10, muestra otro mensaje
                Console.WriteLine("El número no es mayor a 10");
            }
        }

        // Función que pide al usuario ingresar un número entero válido
        static int NumeroIngresado()
        {
            // Variable para almacenar el número ingresado
            int dato;
            // Variable que indica si la conversión fue exitosa
            bool resultado;

            // Bucle que solicita al usuario un número hasta que ingrese uno válido
            do
            {
                // Lee la entrada del usuario como cadena de texto
                string entrada = Console.ReadLine() ?? "";

                // Intenta convertir la cadena de texto a un número entero
                resultado = int.TryParse(entrada, out dato);

                // Si la conversión no fue exitosa, se muestra un mensaje de error
                if (!resultado)
                {
                    Console.WriteLine("El número ingresado es inválido, porfavor ingresar otro");
                }
            } while (!resultado); // El bucle se repite mientras la conversión no sea válida

            // Retorna el número ingresado
            return dato;
        }
    }
}

