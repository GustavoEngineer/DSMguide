using System;

namespace RetoProgramación1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Escribe un número entero");
            int numero = NumeroIngresado();

            if (numero > 10)
            {
                Console.WriteLine("El número es mayor a 10");
            }
            else
            {
                Console.WriteLine("El número no es mayor a 10");
            }

        }

        static int NumeroIngresado()
        {
            int dato;
            bool resultado;

            do
            {
                string entrada = Console.ReadLine() ?? "";
                resultado = int.TryParse(entrada, out dato);
                if (!resultado)
                {
                    Console.WriteLine("El número ingresado es inválido, porfavor ingresar otro");
                }
            } while (!resultado);
            return dato;
        }
    }
}

