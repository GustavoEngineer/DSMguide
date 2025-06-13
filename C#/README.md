
# Documentación de Conceptos Básicos de Programación en C#

Bienvenido a la guía básica de programación en C#. Esta documentación está diseñada para ayudarte a entender los conceptos fundamentales de programación de una manera sencilla y práctica.

## Índice

1. [Sintaxis Básica](#sintaxis-básica)
2. [Tipos de Datos](#tipos-de-datos)
3. [Operadores](#operadores)
4. [Estructuras de Control](#estructuras-de-control)
   - [Condicionales](#condicionales)
   - [Bucles](#bucles)
   - [Switch](#switch)

## Sintaxis Básica

La sintaxis es como la gramática de un lenguaje de programación. Te dice cómo debes escribir tus instrucciones para que el computador las entienda.

### Ejemplo de un "Hola Mundo"

```csharp
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Hola Mundo");
    }
}
```

- `using System;`: Esto es como decirle al programa: "Oye, voy a necesitar algunas herramientas que están en esta caja llamada `System"."
- `class Program`: Imagina que esto es como el plano de una casa. Aquí definimos cómo será nuestra casa (programa).
- `static void Main()`: Es la puerta principal de tu casa. Todo lo que quieras que pase en tu casa debe empezar por aquí.
- `Console.WriteLine("Hola Mundo");`: Esto es como gritar "¡Hola Mundo!" en tu casa. Es una instrucción que le dice al computador que muestre ese mensaje en la pantalla.

## Tipos de Datos

Los tipos de datos son como los diferentes tipos de contenedores que puedes usar para guardar cosas. Cada contenedor es adecuado para un tipo específico de cosa.

### Los 10 tipos de datos más comunes

| Tipo | Descripción | Ejemplo |
|------|-------------|---------|
| int | Para números enteros | `int edad = 25;` |
| float | Para números con decimales | `float altura = 1.75f;` |
| double | Para números con decimales más grandes | `double distancia = 123456789.87654321;` |
| char | Para un solo carácter | `char letra = 'A';` |
| string | Para texto | `string nombre = "Juan";` |
| bool | Para valores booleanos (verdadero o falso) | `bool esEstudiante = true;` |
| byte | Para números pequeños (0 a 255) | `byte numeroPequeno = 200;` |
| short | Para números enteros pequeños | `short numeroCorto = 32767;` |
| long | Para números enteros grandes | `long numeroGrande = 123456789L;` |
| decimal | Para números decimales con alta precisión | `decimal precio = 19.99m;` |

## Operadores

Los operadores son como las herramientas que usas para manipular los datos. Hay varios tipos:

### Operadores Aritméticos

```csharp
int a = 10;
int b = 3;

Console.WriteLine(a + b); // Suma: 13
Console.WriteLine(a - b); // Resta: 7
Console.WriteLine(a * b); // Multiplicación: 30
Console.WriteLine(a / b); // División: 3
Console.WriteLine(a % b); // Módulo: 1
```

### Operadores de Comparación

```csharp
Console.WriteLine(a == b); // Igual a: False
Console.WriteLine(a != b); // Diferente de: True
Console.WriteLine(a > b);  // Mayor que: True
Console.WriteLine(a < b);  // Menor que: False
Console.WriteLine(a >= b); // Mayor o igual que: True
Console.WriteLine(a <= b); // Menor o igual que: False
```

### Operadores Lógicos

```csharp
bool x = true;
bool y = false;

Console.WriteLine(x && y); // AND lógico: False
Console.WriteLine(x || y); // OR lógico: True
Console.WriteLine(!x);     // NOT lógico: False
```

## Estructuras de Control

Las estructuras de control son como las reglas del juego. Te dicen qué hacer en diferentes situaciones.

### Condicionales

#### Definición

Los condicionales permiten que un programa tome decisiones basadas en ciertas condiciones. Si una condición es verdadera, se ejecuta un bloque de código; si es falsa, se puede ejecutar otro bloque de código diferente.

#### Casos de Uso

- Validar entradas de usuario.
- Implementar lógica de negocio.
- Controlar el flujo de un programa basado en diferentes escenarios.

#### Ejemplo: Decidir qué ropa ponerse

Imagina que estás decidiendo qué ropa ponerte basado en el clima.

```csharp
string clima = "lluvioso";

if (clima == "soleado")
{
    Console.WriteLine("Ponte una camiseta y shorts.");
}
else if (clima == "lluvioso")
{
    Console.WriteLine("Ponte un impermeable y botas.");
}
else if (clima == "nublado")
{
    Console.WriteLine("Ponte una sudadera y jeans.");
}
else
{
    Console.WriteLine("Ponte lo que quieras.");
}
```

### Bucles

#### Definición

Los bucles permiten ejecutar un bloque de código repetidamente mientras se cumpla una condición específica. Son útiles para automatizar tareas repetitivas.

#### Casos de Uso

- Procesar elementos en una lista o array.
- Realizar una tarea un número específico de veces.
- Leer datos hasta que se encuentre un valor específico.

#### Ejemplo: Regar las plantas

Supongamos que tienes que regar 5 plantas.

```csharp
for (int i = 1; i <= 5; i++)
{
    Console.WriteLine($"Regando la planta {i}.");
}
```

#### Ejemplo: Revisar el correo electrónico

Imagina que estás revisando tu correo electrónico hasta que no haya más correos nuevos.

```csharp
int correosNuevos = 10;

while (correosNuevos > 0)
{
    Console.WriteLine($"Revisando correo {correosNuevos}.");
    correosNuevos--;
}
```

#### Ejemplo: Hacer ejercicio

Supongamos que quieres hacer ejercicio hasta que hayas quemado al menos 200 calorías.

```csharp
int caloriasQuemadas = 0;
int caloriasPorEjercicio = 50;

do
{
    Console.WriteLine("Haciendo ejercicio...");
    caloriasQuemadas += caloriasPorEjercicio;
} while (caloriasQuemadas < 200);

Console.WriteLine($"Has quemado {caloriasQuemadas} calorías.");
```

### Switch

#### Definición

La estructura `switch` permite evaluar una expresión y, basado en su valor, ejecutar diferentes bloques de código. Es útil cuando tienes múltiples condiciones que evaluar contra una sola variable.

#### Casos de Uso

- Menús de selección.
- Manejo de diferentes tipos de datos o entradas.
- Implementar lógica basada en estados o códigos de error.

#### Ejemplo: Planificar actividades del fin de semana

Imagina que estás planificando diferentes actividades para cada día del fin de semana.

```csharp
string dia = "sábado";

switch (dia)
{
    case "viernes":
        Console.WriteLine("Ir al cine.");
        break;
    case "sábado":
        Console.WriteLine("Hacer una excursión al campo.");
        break;
    case "domingo":
        Console.WriteLine("Quedarse en casa y leer un libro.");
        break;
    default:
        Console.WriteLine("Día no válido.");
        break;
}
```
