# 📝 Documentación: Clase Contacto

## 📋 Información General

|-----------------|---------------------------------------|
| Atributo        | Valor                                 |
|-----------------|---------------------------------------|
| **Namespace**   | `ContactosApi.Core.Entities`          |
| **Tipo**        | Clase de Entidad (Entity)             |
| **Propósito**   | Representar un contacto en el sistema |
| **Modificador** | `public`                              |
|-----------------|---------------------------------------|

## 🏗️ Estructura de la Clase

```csharp
namespace ContactosApi.Core.Entities;

public class Contacto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
}
```

## 📐 Arquitectura y Patrones

### Patrón Utilizado
- **POCO (Plain Old CLR Object)**: Clase simple sin lógica de negocio
- **Entidad de Dominio**: Representa un objeto del mundo real
- **Data Transfer Object (DTO)**: Facilita la transferencia de datos

### Ubicación en la Arquitectura
```
ContactosApi/
├── Core/
│   ├── Entities/
│   │   └── Contacto.cs ← AQUÍ
│   ├── Interfaces/
│   └── Services/
├── Infrastructure/
└── Api/
```

## ✅ Mejores Prácticas Implementadas

1. **Naming Convention**: PascalCase para clase y propiedades
2. **Inicialización Segura**: Uso de `string.Empty` para evitar `null`
3. **Auto-Propiedades**: Sintaxis limpia y concisa
4. **Namespace Organizado**: Estructura jerárquica clara
5. **Modificadores Apropiados**: `public` para entidad de datos

## 🔧 Posibles Mejoras

### Validación de Datos

```csharp
using System.ComponentModel.DataAnnotations;

public class Contacto
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(50, ErrorMessage = "El nombre no puede exceder 50 caracteres")]
    public string Nombre { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "El apellido es obligatorio")]
    [StringLength(50, ErrorMessage = "El apellido no puede exceder 50 caracteres")]
    public string Apellido { get; set; } = string.Empty;
    
    [EmailAddress(ErrorMessage = "Formato de email inválido")]
    public string Email { get; set; } = string.Empty;
    
    [Phone(ErrorMessage = "Formato de teléfono inválido")]
    public string Telefono { get; set; } = string.Empty;
}
```

### Constructor Personalizado
```csharp
public class Contacto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
    
    // Constructor por defecto
    public Contacto() { }
    
    // Constructor con parámetros esenciales
    public Contacto(string nombre, string apellido, string email)
    {
        Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
        Apellido = apellido ?? throw new ArgumentNullException(nameof(apellido));
        Email = email ?? throw new ArgumentNullException(nameof(email));
    }
}
```

## 📚 Conceptos Relacionados

### Auto-Propiedades
Las auto-propiedades (`{ get; set; }`) son una característica de C# que:
- Generan automáticamente un campo privado de respaldo
- Proporcionan métodos getter y setter básicos
- Reducen el código repetitivo (boilerplate)

### Tipos de Referencia vs Valor
- `int` (Id): Tipo de valor, se almacena en la pila
- `string` (Nombre, Apellido, Email, Telefono): Tipo de referencia, se almacena en el heap

### Inicialización por Defecto
`string.Empty` vs `null`:
- `string.Empty`: Cadena vacía (""), más seguro
- `null`: Ausencia de valor, puede causar `NullReferenceException`
```

## 📝 Notas Adicionales

- Esta clase es ideal para operaciones CRUD (Create, Read, Update, Delete)
- Compatible con Entity Framework para mapeo a base de datos
- Serializable para APIs REST (JSON)
- Puede ser extendida mediante herencia si se requiere funcionalidad adicional

---
