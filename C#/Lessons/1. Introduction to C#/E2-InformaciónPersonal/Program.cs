using System;

namespace TarjetaDigital
{
    class Program
    {
        static void Main(string[] args)
        {
            // Inicialización de variables
            string nombre = "[Tu nombre]";
            string edad = "[Tu edad]";
            string carreraUniversitaria = "Ejemplo [Desarrollo de Software]";
            string ciudad = "[Tu ciudad]";
            bool continuar = true;
            string instrucciones = "Las acciones son las siguientes:\n1.Actualizar datos\n2.Visualizar datos\n3.Salir\n";

            Console.WriteLine("Hola, Bienvenido a tu tarjeta digital\nTienes que rellenar los siguientes campos\n");
            Console.WriteLine("========================\nMI TARJETA DIGITAL\n========================");
            Console.WriteLine($"Nombre: {nombre} \nEdad: {edad}\nCarrera: {carreraUniversitaria}\nCiudad: {ciudad}\n========================\n");
            Console.ReadKey();

            while (continuar)
            {
                Console.WriteLine(instrucciones);
                string opcion = Console.ReadLine() ?? "";
                if (!int.TryParse(opcion, out int opcionNumero))
                {
                    Console.WriteLine("Algo salió mál, ingresa un número válido");
                    continue;
                }

                switch (opcionNumero)
                {
                    case 1:
                        // Dato 1
                        Console.WriteLine("¿Quieres modificar tu nombre? escribe (s/n)");
                        string res1 = Console.ReadLine() ?? "";


                        if (res1.Equals("s", StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine("Escribe tu nuevo nombre");
                            string nuevoNombre = Console.ReadLine() ?? "";
                            nombre = nuevoNombre;
                            Console.WriteLine($"El nombre {nombre} se ha modificado con éxito");
                        }
                        else
                        {
                            Console.WriteLine("No se modificará el nombre");
                        }

                        // Dato 2
                        Console.WriteLine("¿Quieres modificar tu edad? escribe (s/n)");
                        string res2 = Console.ReadLine() ?? "";

                        if (res2.Equals("s", StringComparison.OrdinalIgnoreCase))
                        {
                            while (true)
                            {
                                Console.WriteLine("Escribe tu nueva edad");
                                string entradaEdad = Console.ReadLine() ?? "";

                                if (!int.TryParse(entradaEdad, out int nuevaEdad))
                                {
                                    Console.WriteLine("Algo salió mal, ingresa un número válido");
                                }
                                else
                                {
                                    edad = nuevaEdad.ToString();
                                    Console.WriteLine($"La edad {nuevaEdad} se ha modificado con éxito");
                                    break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("No se modificará la edad.");
                        }

                        // Dato 3
                        Console.WriteLine("¿Quieres modificar tu carrera? escribe (s/n)");
                        string res3 = Console.ReadLine() ?? "";


                        if (res3.Equals("s", StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine("Escribe tu nueva carrera");
                            string nuevaCarrera = Console.ReadLine() ?? "";
                            carreraUniversitaria = nuevaCarrera;
                            Console.WriteLine($"El nombre {carreraUniversitaria} se ha modificado con éxito");
                        }
                        else
                        {
                            Console.WriteLine("No se modificará la carrera");
                        }

                        // Dato 4
                        Console.WriteLine("¿Quieres modificar tu ciudad? escribe (s/n)");
                        string res4 = Console.ReadLine() ?? "";


                        if (res4.Equals("s", StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine("Escribe tu nueva ciudad");
                            string nuevaCiudad = Console.ReadLine() ?? "";
                            ciudad = nuevaCiudad;
                            Console.WriteLine($"El nombre {ciudad} se ha modificado con éxito");
                        }
                        else
                        {
                            Console.WriteLine("No se modificará la ciudad");
                        }


                        break;
                    case 2:
                        Console.WriteLine($"Nombre: {nombre} \nEdad: {edad}\nCarrera: {carreraUniversitaria}\nCiudad: {ciudad}\n========================\n");
                        break;
                    case 3:
                        Console.WriteLine("Saliendo...");
                        return;
                    default:
                        Console.Error.WriteLine("Algo salió mal, ingresa un numero válido");
                        continue;
                }
            }
        }
    }
}

