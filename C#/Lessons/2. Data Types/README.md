# Variables y Tipos de Datos - Documentación Completa

## 📋 Índice

1. [Introducción](#introducción)
2. [¿Qué es una Variable?](#qué-es-una-variable)
3. [Tipos de Datos Primitivos](#tipos-de-datos-primitivos)
   - [int (Números Enteros)](#int-números-enteros)
   - [double (Números Decimales)](#double-números-decimales)
   - [string (Texto)](#string-texto)
   - [bool (Verdadero o Falso)](#bool-verdadero-o-falso)
   - [char (Un Solo Carácter)](#char-un-solo-carácter)
4. [20 Tipos de Datos Más Usados](#20-tipos-de-datos-más-usados)
5. [Declaración y Asignación de Variables](#declaración-y-asignación-de-variables)
6. [Constantes](#constantes)
7. [Conversiones de Tipos (Casting)](#conversiones-de-tipos-casting)
8. [Operadores](#operadores)
   - [Operadores Aritméticos](#operadores-aritméticos)
   - [Operadores de Comparación](#operadores-de-comparación)
   - [Operadores Lógicos](#operadores-lógicos)
9. [Precedencia de Operadores](#precedencia-de-operadores)
10. [Buenas Prácticas](#buenas-prácticas)

---

## Introducción

Las variables y tipos de datos son los elementos fundamentales de cualquier lenguaje de programación. Son como las cajas etiquetadas donde guardamos información que nuestro programa necesita para funcionar. Imagínate organizando tu cuarto: necesitas diferentes tipos de cajas para diferentes cosas.

---

## ¿Qué es una Variable?

Una variable es un **contenedor etiquetado** donde almacenamos información que puede cambiar durante la ejecución de nuestro programa.

### Analogía del Mundo Real
Es como los compartimentos de tu billetera:
- Un espacio para billetes
- Otro para monedas  
- Otro para tarjetas
- Cada espacio tiene un propósito específico

### Características de las Variables
- **Nombre único:** Cada variable debe tener un identificador único
- **Tipo específico:** Define qué tipo de información puede almacenar
- **Valor variable:** El contenido puede cambiar durante la ejecución
- **Ubicación en memoria:** Ocupa un espacio específico en la memoria del computador

---

## Tipos de Datos Primitivos

### int (Números Enteros)

Almacena números completos, sin decimales.

**Rango típico:** -2,147,483,648 a 2,147,483,647

**Ejemplos de la vida real:**
- Edad de una persona: `23`
- Número de estudiantes: `35`
- Cantidad de likes: `157`
- Piso de un edificio: `8`

```csharp
int edad = 25;
int numeroEstudiantes = 40;
int añoActual = 2024;
```

### double (Números Decimales)

Almacena números con punto decimal de doble precisión.

**Precisión:** Aproximadamente 15-17 dígitos decimales

**Ejemplos de la vida real:**
- Precio de gasolina: `24.50`
- Estatura: `1.75`
- Calificación: `8.7`
- Temperatura: `36.5`

```csharp
double precio = 45.99;
double estatura = 1.68;
double promedio = 8.75;
```

### string (Texto)

Almacena cadenas de caracteres, desde una sola letra hasta párrafos completos.

**Características:**
- Se declara entre comillas dobles `""`
- Puede contener cualquier carácter
- Longitud variable
- Inmutable en muchos lenguajes

**Ejemplos de la vida real:**
- Nombre: `"Juan Carlos"`
- Dirección: `"Calle 5 de Mayo #123"`
- Mensaje: `"Nos vemos en el café"`
- Email: `"usuario@ejemplo.com"`

```csharp
string nombre = "María González";
string email = "maria@email.com";
string mensaje = "¡Hola mundo!";
```

### bool (Verdadero o Falso)

Almacena únicamente dos valores posibles: `true` (verdadero) o `false` (falso).

**Analogía:** Como un interruptor de luz que solo puede estar encendido o apagado.

**Ejemplos de la vida real:**
- ¿Está lloviendo?: `true` o `false`
- ¿Terminaste la tarea?: `true` o `false`  
- ¿Usuario conectado?: `true` o `false`
- ¿Mayor de edad?: `true` o `false`

```csharp
bool estaLloviendo = false;
bool usuarioConectado = true;
bool mayorDeEdad = true;
```

### char (Un Solo Carácter)

Almacena un único carácter Unicode.

**Características:**
- Se declara entre comillas simples `''`
- Almacena exactamente un carácter
- Puede ser letra, número, símbolo o espacio

**Ejemplos de la vida real:**
- Calificación con letra: `'A'`
- Inicial del nombre: `'J'`
- Símbolo de moneda: `'$'`
- Respuesta múltiple: `'c'`

```csharp
char inicial = 'M';
char calificacion = 'A';
char simbolo = '$';
```

---

## 20 Tipos de Datos Más Usados

### Tipos Numéricos Enteros

#### 1. **byte**
- **Rango:** 0 a 255
- **Uso:** Almacenar datos pequeños, colores RGB, edades
- **Ejemplo:** `byte edad = 25;`

#### 2. **sbyte** 
- **Rango:** -128 a 127
- **Uso:** Números pequeños con signo
- **Ejemplo:** `sbyte temperatura = -15;`

#### 3. **short**
- **Rango:** -32,768 a 32,767
- **Uso:** Números medianos, años
- **Ejemplo:** `short año = 2024;`

#### 4. **ushort**
- **Rango:** 0 a 65,535
- **Uso:** Números medianos sin signo
- **Ejemplo:** `ushort puerto = 8080;`

#### 5. **long**
- **Rango:** -9,223,372,036,854,775,808 a 9,223,372,036,854,775,807
- **Uso:** Números muy grandes, IDs únicos, timestamps
- **Ejemplo:** `long numeroTelefono = 5551234567890;`

#### 6. **ulong**
- **Rango:** 0 a 18,446,744,073,709,551,615
- **Uso:** Números muy grandes sin signo
- **Ejemplo:** `ulong habitantes = 7800000000;`

### Tipos Numéricos Decimales

#### 7. **float**
- **Precisión:** ~7 dígitos decimales
- **Uso:** Cálculos que no requieren alta precisión
- **Ejemplo:** `float peso = 70.5f;`

#### 8. **decimal**
- **Precisión:** 28-29 dígitos decimales
- **Uso:** Cálculos financieros, moneda
- **Ejemplo:** `decimal saldo = 1500.75m;`

### Tipos de Fecha y Tiempo

#### 9. **DateTime**
- **Uso:** Fechas y horas completas
- **Ejemplo:** `DateTime nacimiento = new DateTime(1995, 5, 20);`

#### 10. **TimeSpan**
- **Uso:** Intervalos de tiempo, duraciones
- **Ejemplo:** `TimeSpan duracion = TimeSpan.FromHours(2);`

#### 11. **DateOnly** (C# 6.0+)
- **Uso:** Solo fechas, sin hora
- **Ejemplo:** `DateOnly fecha = new DateOnly(2024, 12, 25);`

#### 12. **TimeOnly** (C# 6.0+)
- **Uso:** Solo hora, sin fecha
- **Ejemplo:** `TimeOnly hora = new TimeOnly(14, 30, 0);`

### Tipos de Identificadores

#### 13. **Guid**
- **Uso:** Identificadores únicos globales
- **Ejemplo:** `Guid id = Guid.NewGuid();`

### Tipos Especiales

#### 14. **object**
- **Uso:** Tipo base de todos los tipos, puede almacenar cualquier valor
- **Ejemplo:** `object valor = "Cualquier cosa";`

#### 15. **var**
- **Uso:** Inferencia de tipos, el compilador determina el tipo
- **Ejemplo:** `var nombre = "Juan"; // Se infiere como string`

#### 16. **dynamic**
- **Uso:** Tipo dinámico, se resuelve en tiempo de ejecución
- **Ejemplo:** `dynamic dato = 42;`

### Tipos Nullable

#### 17. **int?** (Nullable Int)
- **Uso:** Enteros que pueden ser null
- **Ejemplo:** `int? edad = null;`

#### 18. **double?** (Nullable Double)
- **Uso:** Decimales que pueden ser null
- **Ejemplo:** `double? precio = null;`

#### 19. **bool?** (Nullable Bool)
- **Uso:** Booleanos que pueden ser null (true, false, null)
- **Ejemplo:** `bool? activo = null;`

#### 20. **DateTime?** (Nullable DateTime)
- **Uso:** Fechas que pueden ser null
- **Ejemplo:** `DateTime? ultimaConexion = null;`

### Tabla Resumen de Tamaños

| Tipo | Tamaño (bytes) | Rango/Descripción |
|------|----------------|-------------------|
| byte | 1 | 0 a 255 |
| sbyte | 1 | -128 a 127 |
| short | 2 | -32,768 a 32,767 |
| ushort | 2 | 0 a 65,535 |
| int | 4 | ±2.1 billones aprox |
| uint | 4 | 0 a 4.3 billones aprox |
| long | 8 | ±9.2 quintillones aprox |
| ulong | 8 | 0 a 18.4 quintillones aprox |
| float | 4 | 7 dígitos de precisión |
| double | 8 | 15-17 dígitos de precisión |
| decimal | 16 | 28-29 dígitos de precisión |
| char | 2 | Un carácter Unicode |
| bool | 1 | true o false |

---

## Declaración y Asignación de Variables

### Declaración
Es el proceso de crear una variable y especificar su tipo.

```csharp
// Declaración simple
int edad;
string nombre;
double saldo;
bool activo;
```

### Asignación
Es el proceso de dar un valor a la variable.

```csharp
// Asignación después de declaración
edad = 25;
nombre = "Juan";
saldo = 1500.50;
activo = true;
```

### Declaración e Inicialización Simultánea
```csharp
// Declaración e inicialización en una línea
int edad = 25;
string nombre = "Juan";
double saldo = 1500.50;
bool activo = true;
```

### Múltiples Variables del Mismo Tipo
```csharp
// Declarar múltiples variables del mismo tipo
int x, y, z;
x = 10;
y = 20; 
z = 30;

// O inicializar directamente
int a = 1, b = 2, c = 3;
```

---

## Constantes

Las constantes son valores que **nunca cambian** durante la ejecución del programa.

### Características
- Se declaran con la palabra clave `const`
- Deben inicializarse al momento de la declaración
- Su valor no puede modificarse
- Por convención se escriben en MAYÚSCULAS

### Ejemplos Prácticos
```csharp
const double PI = 3.14159;
const int DIAS_SEMANA = 7;
const string NOMBRE_EMPRESA = "TechCorp";
const double IVA = 0.16;
const int VELOCIDAD_LUZ = 299792458; // m/s
```

### Diferencia: const vs readonly
- **const:** Se evalúa en tiempo de compilación
- **readonly:** Se puede inicializar en tiempo de ejecución

```csharp
const int VALOR_CONSTANTE = 100;          // Tiempo de compilación
readonly DateTime FECHA_INICIO = DateTime.Now; // Tiempo de ejecución
```

---

## Conversiones de Tipos (Casting)

### Conversión Implícita
El compilador convierte automáticamente cuando no hay pérdida de datos.

```csharp
int numero = 42;
double decimal = numero; // int → double (automático)
```

### Conversión Explícita (Cast)
El programador fuerza la conversión, puede haber pérdida de datos.

```csharp
double decimal = 42.7;
int entero = (int)decimal; // Resultado: 42 (se pierde .7)
```

### Métodos de Conversión
```csharp
// string a tipos numéricos
string textoNumero = "123";
int numero = int.Parse(textoNumero);
int numero2 = Convert.ToInt32(textoNumero);

// TryParse - conversión segura
string textoInvalido = "abc";
if (int.TryParse(textoInvalido, out int resultado))
{
    // Conversión exitosa
}
else
{
    // Conversión falló
}

// Tipos numéricos a string
int edad = 25;
string edadTexto = edad.ToString();
string edadFormateada = edad.ToString("00"); // "25"
```

### Tabla de Conversiones Comunes

| Desde | Hacia | Método |
|-------|-------|--------|
| string | int | `int.Parse()` o `Convert.ToInt32()` |
| string | double | `double.Parse()` o `Convert.ToDouble()` |
| string | bool | `bool.Parse()` o `Convert.ToBoolean()` |
| int | string | `.ToString()` |
| double | string | `.ToString()` |
| bool | string | `.ToString()` |
| double | int | `(int)valor` o `Convert.ToInt32()` |
| int | double | Automático o `Convert.ToDouble()` |

---

## Operadores

### Operadores Aritméticos

Realizan operaciones matemáticas básicas.

| Operador | Descripción | Ejemplo | Resultado |
|----------|-------------|---------|-----------|
| `+` | Suma | `5 + 3` | `8` |
| `-` | Resta | `5 - 3` | `2` |
| `*` | Multiplicación | `5 * 3` | `15` |
| `/` | División | `15 / 3` | `5` |
| `%` | Módulo (residuo) | `15 % 4` | `3` |
| `++` | Incremento | `x++` | `x = x + 1` |
| `--` | Decremento | `x--` | `x = x - 1` |

#### Ejemplos Prácticos
```csharp
// Calculadora de propina
double cuentaRestaurante = 250.00;
double porcentajePropina = 0.15;
double propina = cuentaRestaurante * porcentajePropina; // 37.50
double total = cuentaRestaurante + propina; // 287.50

// Verificar si un año es bisiesto
int año = 2024;
bool esBisiesto = (año % 4 == 0 && año % 100 != 0) || (año % 400 == 0);
```

### Operadores de Comparación

Comparan dos valores y devuelven un valor booleano.

| Operador | Descripción | Ejemplo | Resultado |
|----------|-------------|---------|-----------|
| `==` | Igual a | `5 == 5` | `true` |
| `!=` | Diferente de | `5 != 3` | `true` |
| `>` | Mayor que | `8 > 5` | `true` |
| `<` | Menor que | `3 < 7` | `true` |
| `>=` | Mayor o igual | `5 >= 5` | `true` |
| `<=` | Menor o igual | `4 <= 6` | `true` |

#### Ejemplos Prácticos
```csharp
// Verificar edad para votar
int edad = 18;
bool puedeVotar = edad >= 18; // true

// Comparar calificaciones
double calificacion = 8.5;
bool aprobo = calificacion >= 6.0; // true
bool excelencia = calificacion >= 9.0; // false

// Verificar contraseña
string contraseñaIngresada = "123456";
string contraseñaCorrecta = "MiContraseña";
bool accesoPermitido = contraseñaIngresada == contraseñaCorrecta; // false
```

### Operadores Lógicos

Combinan o modifican valores booleanos.

| Operador | Descripción | Ejemplo | Resultado |
|----------|-------------|---------|-----------|
| `&&` | AND (Y) | `true && false` | `false` |
| `\|\|` | OR (O) | `true \|\| false` | `true` |
| `!` | NOT (NO) | `!true` | `false` |

#### Tabla de Verdad

| A | B | A && B | A \|\| B |
|---|---|---------|----------|
| true | true | true | true |
| true | false | false | true |
| false | true | false | true |
| false | false | false | false |

#### Ejemplos Prácticos
```csharp
// Verificar acceso a club
int edad = 25;
bool tieneMembresía = true;
bool puedeEntrar = edad >= 18 && tieneMembresía; // true

// Descuento por estudiante o adulto mayor
bool esEstudiante = false;
bool esAdultoMayor = true;
bool tieneDescuento = esEstudiante || esAdultoMayor; // true

// Verificar día laboral
string diaSemana = "Sábado";
bool esFinDeSemana = diaSemana == "Sábado" || diaSemana == "Domingo";
bool esDiaLaboral = !esFinDeSemana; // false
```

---

## Precedencia de Operadores

Los operadores se evalúan en un orden específico, similar a las matemáticas.

### Orden de Precedencia (Mayor a Menor)

1. **Paréntesis** `()`
2. **Unarios** `!`, `++`, `--`, `+`, `-`
3. **Multiplicativos** `*`, `/`, `%`
4. **Aditivos** `+`, `-`
5. **Relacionales** `<`, `>`, `<=`, `>=`
6. **Igualdad** `==`, `!=`
7. **AND lógico** `&&`
8. **OR lógico** `||`
9. **Asignación** `=`, `+=`, `-=`

### Ejemplos de Precedencia
```csharp
// Sin paréntesis
int resultado1 = 5 + 3 * 2;      // Resultado: 11 (3*2=6, luego 5+6=11)
int resultado2 = 10 / 2 + 3;     // Resultado: 8 (10/2=5, luego 5+3=8)

// Con paréntesis para cambiar precedencia
int resultado3 = (5 + 3) * 2;    // Resultado: 16 (5+3=8, luego 8*2=16)
int resultado4 = 10 / (2 + 3);   // Resultado: 2 (2+3=5, luego 10/5=2)

// Ejemplo complejo
bool resultado5 = 5 > 3 && 4 < 6 || 2 == 1;
// Evaluación paso a paso:
// 1. 5 > 3 = true
// 2. 4 < 6 = true  
// 3. 2 == 1 = false
// 4. true && true = true
// 5. true || false = true
// Resultado final: true
```

### Consejos para Manejar Precedencia
1. **Usa paréntesis** cuando tengas dudas
2. **Divide expresiones complejas** en pasos más simples
3. **Documenta expresiones complejas** con comentarios
4. **Mantén la claridad** sobre la velocidad de ejecución

```csharp
// Mejor práctica: usar paréntesis para claridad
bool puedeComprar = (saldo >= precio) && (edad >= 18) && !estaBloqueado;

// En lugar de confiar en la precedencia
bool puedeComprar2 = saldo >= precio && edad >= 18 && !estaBloqueado;
```

---

## Buenas Prácticas

### Nomenclatura de Variables
```csharp
// ✅ Correcto - Descriptivo y claro
int edadUsuario = 25;
string nombreCompleto = "Juan Pérez";
double precioProducto = 99.99;
bool estaActivo = true;

// ❌ Incorrecto - Nombres poco descriptivos
int x = 25;
string n = "Juan Pérez";
double p = 99.99;
bool flag = true;
```

### Convenciones de Nombres
- **camelCase** para variables locales: `nombreUsuario`
- **PascalCase** para constantes: `PRECIO_MAXIMO`
- **Nombres descriptivos** que expliquen el propósito
- **Evitar abreviaciones** confusas

### Inicialización de Variables
```csharp
// ✅ Correcto - Inicializar al declarar
int contador = 0;
string mensaje = "";
bool procesado = false;

// ❌ Incorrecto - Variables sin inicializar
int contador;        // Puede causar errores
string mensaje;      // Valor null por defecto
bool procesado;      // Valor false por defecto
```

### Uso de Constantes
```csharp
// ✅ Correcto - Usar constantes para valores fijos
const double IVA = 0.16;
const int EDAD_MINIMA_VOTAR = 18;
const string MENSAJE_ERROR = "Usuario no encontrado";

double precio = 100.0;
double total = precio + (precio * IVA);

// ❌ Incorrecto - Números mágicos
double total2 = precio + (precio * 0.16); // ¿Qué es 0.16?
```

### Validación de Datos
```csharp
// ✅ Correcto - Validar entrada de usuario
string edadTexto = Console.ReadLine();
if (int.TryParse(edadTexto, out int edad))
{
    if (edad >= 0 && edad <= 120)
    {
        Console.WriteLine($"Edad válida: {edad}");
    }
    else
    {
        Console.WriteLine("Edad fuera del rango válido");
    }
}
else
{
    Console.WriteLine("Por favor ingrese un número válido");
}
```

### Comentarios Efectivos
```csharp
// ✅ Correcto - Comentarios que explican el "por qué"
const double FACTOR_CONVERSION = 2.20462; // Kilogramos a libras

// Calcular el IMC según la fórmula estándar de la OMS
double imc = peso / (altura * altura);

// ❌ Incorrecto - Comentarios que explican el "qué" obvio
int edad = 25; // Asignar 25 a la variable edad
```

### Manejo de Tipos Nullable
```csharp
// ✅ Correcto - Verificar valores null
int? edad = ObtenerEdadUsuario();
if (edad.HasValue)
{
    Console.WriteLine($"La edad es: {edad.Value}");
}
else
{
    Console.WriteLine("Edad no disponible");
}

// Operador null-coalescing
string nombre = nombreUsuario ?? "Usuario Anónimo";
```

---

*Esta documentación cubre los conceptos fundamentales de variables y tipos de datos. Practica con ejemplos reales y siempre busca escribir código claro y mantenible.*