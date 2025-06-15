using System;

namespace RetoProgramación4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hola, ingresa el número 10");
            int numero = IngresarNumero();  // Primer ingreso de número

            // Bucle que continuará pidiendo el número hasta que el usuario ingrese 10
            while (numero != 10)
            {
                // Si el número ingresado no es 10, imprime el mensaje de error
                Console.WriteLine($"Error: El número que ingresó fue {numero}, el número solicitado fue el 10.");

                // Vuelve a pedir un nuevo número
                numero = IngresarNumero();
            }

            // Si el número es 10, imprime el mensaje de éxito
            Console.WriteLine("Perfecto: El número ingresado fue el 10");
        }

        // Método para ingresar un número
        static int IngresarNumero()
        {
            int dato;
            string entrada;

            do
            {
                entrada = Console.ReadLine() ?? "";  // Lee la entrada del usuario
                bool resultado = int.TryParse(entrada, out dato);  // Intenta convertir la entrada a un número

                if (resultado)  // Si la entrada es válida (es un número)
                {
                    return dato;  // Retorna el número ingresado
                }
                else  // Si no es un número válido
                {
                    Console.WriteLine("Advertencia: El dato ingresado no era un número, ingrese un número válido.");
                }
            } while (true);  // Continúa pidiendo un número hasta que sea válido
        }
    }
}
