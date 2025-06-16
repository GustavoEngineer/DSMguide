# Listas en C# – Guía Completa y Métodos Clave 🚀

## 📚 Índice

- [📘 ¿Qué es una Lista?](#-qué-es-una-lista)
- [🎭 Ejemplo Base: Musical de Hamilton](#-ejemplo-base-musical-de-hamilton)
- [🔧 Métodos de Manipulación](#-métodos-de-manipulación)
- [🔍 Métodos de Búsqueda](#-métodos-de-búsqueda)
- [✅ Métodos de Verificación](#-métodos-de-verificación)
- [🔄 Métodos de Conversión](#-métodos-de-conversión)
- [ℹ️ Métodos de Información](#️-métodos-de-información)
- [⚙️ Métodos de Optimización](#️-métodos-de-optimización)
- [🔁 Método de Iteración](#-método-de-iteración)
- [🎯 Conclusión](#-conclusión)

---

## 📘 ¿Qué es una Lista?

Una **lista (`List<T>`) en C#** es una colección genérica que permite almacenar elementos del mismo tipo de forma ordenada y dinámica. A diferencia de los arreglos, las listas pueden crecer y reducirse automáticamente.

### Conceptos Básicos:
- Genérica: `List<string>`, `List<int>`, etc.
- Dinámica: Se expande o reduce sola.
- Indexada: Acceso por índice (desde 0).
- Permite duplicados.

---

## 🎭 Ejemplo Base: Musical de Hamilton

Vamos a trabajar todos los métodos de listas usando un solo ejemplo: una lista de canciones del musical **Hamilton** de Lin-Manuel Miranda.

```csharp
List<string> cancionesHamilton = new List<string>
{
    "Alexander Hamilton",
    "My Shot",
    "The Schuyler Sisters",
    "You'll Be Back",
    "Wait For It"
};
```

---

## 🔧 Métodos de Manipulación

### Add()
Agrega una canción nueva al final:
```csharp
cancionesHamilton.Add("Non-Stop");
```

### AddRange()
Agrega varias canciones nuevas:
```csharp
cancionesHamilton.AddRange(new List<string>{"Helpless", "Satisfied"});
```

### Insert()
Inserta una canción en cierta posición:
```csharp
cancionesHamilton.Insert(1, "The Story of Tonight");
```

### InsertRange()
Inserta varias canciones en una posición:
```csharp
cancionesHamilton.InsertRange(3, new List<string>{"Dear Theodosia", "Guns and Ships"});
```

### Remove()
Elimina una canción específica:
```csharp
cancionesHamilton.Remove("You'll Be Back");
```

### RemoveAt()
Elimina la canción por índice:
```csharp
cancionesHamilton.RemoveAt(0); // Elimina "Alexander Hamilton"
```

### RemoveRange()
Elimina varias canciones desde un índice:
```csharp
cancionesHamilton.RemoveRange(2, 2);
```

### RemoveAll()
Elimina canciones que contengan "Shot":
```csharp
cancionesHamilton.RemoveAll(c => c.Contains("Shot"));
```

### Clear()
Elimina todas las canciones:
```csharp
cancionesHamilton.Clear();
```

### Sort()
Ordena alfabéticamente:
```csharp
cancionesHamilton.Sort();
```

### Reverse()
Invierte el orden actual:
```csharp
cancionesHamilton.Reverse();
```

---

## 🔍 Métodos de Búsqueda

### Contains()
¿Está "Wait For It" en la lista?
```csharp
bool esta = cancionesHamilton.Contains("Wait For It");
```

### IndexOf()
¿En qué índice está "My Shot"?
```csharp
int pos = cancionesHamilton.IndexOf("My Shot");
```

### LastIndexOf()
Última aparición de "My Shot":
```csharp
int ult = cancionesHamilton.LastIndexOf("My Shot");
```

### Find()
Primera canción con más de 15 letras:
```csharp
string larga = cancionesHamilton.Find(c => c.Length > 15);
```

### FindLast()
Última canción que contiene "it":
```csharp
string contieneIt = cancionesHamilton.FindLast(c => c.Contains("it"));
```

### FindAll()
Canciones que terminan en "t":
```csharp
var terminanEnT = cancionesHamilton.FindAll(c => c.EndsWith("t"));
```

### FindIndex()
Índice de primera que empieza con "The":
```csharp
int i = cancionesHamilton.FindIndex(c => c.StartsWith("The"));
```

### FindLastIndex()
Índice de última que contiene "a":
```csharp
int j = cancionesHamilton.FindLastIndex(c => c.Contains("a"));
```

### BinarySearch()
Búsqueda binaria:
```csharp
cancionesHamilton.Sort();
int idx = cancionesHamilton.BinarySearch("Wait For It");
```

### Exists()
¿Hay una canción que tenga "King"?
```csharp
bool existe = cancionesHamilton.Exists(c => c.Contains("King"));
```

---

## ✅ Métodos de Verificación

### TrueForAll()
¿Todas las canciones tienen más de 5 letras?
```csharp
bool todas = cancionesHamilton.TrueForAll(c => c.Length > 5);
```

---

## 🔄 Métodos de Conversión

### ConvertAll()
Longitudes de títulos:
```csharp
var longitudes = cancionesHamilton.ConvertAll(c => c.Length);
```

### ToArray()
Convertir a arreglo:
```csharp
string[] array = cancionesHamilton.ToArray();
```

### AsReadOnly()
Versión solo lectura:
```csharp
var lectura = cancionesHamilton.AsReadOnly();
```

### GetRange()
Obtener canciones de la 2 a la 4:
```csharp
var subLista = cancionesHamilton.GetRange(1, 3);
```

---

## ℹ️ Métodos de Información

### Count
Cantidad de canciones:
```csharp
int total = cancionesHamilton.Count;
```

### Capacity
Capacidad interna:
```csharp
int capacidad = cancionesHamilton.Capacity;
```

---

## ⚙️ Métodos de Optimización

### TrimExcess()
Reducir espacio en memoria:
```csharp
cancionesHamilton.TrimExcess();
```

### CopyTo()
Copiar a arreglo:
```csharp
string[] copia = new string[cancionesHamilton.Count];
cancionesHamilton.CopyTo(copia);
```

---

## 🔁 Método de Iteración

### ForEach()
Imprimir todas las canciones:
```csharp
cancionesHamilton.ForEach(c => Console.WriteLine($"🎵 {c}"));
```

---

## 🎯 Conclusión

Las listas en C# son herramientas poderosas, versátiles y fáciles de usar. Aprendiste a usarlas con ejemplos reales del musical **Hamilton**, dominando manipulación, búsqueda, conversión y recorrido.

Practica con tus propios temas favoritos y verás cómo cada método tiene un propósito claro en la programación del día a día. 🎭💻
