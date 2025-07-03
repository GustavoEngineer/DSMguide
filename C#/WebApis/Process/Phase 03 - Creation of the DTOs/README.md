# Guía Completa de DTOs (Data Transfer Objects)

## 📋 Tabla de Contenidos
1. [¿Qué es un DTO?](#qué-es-un-dto)
2. [¿Por qué necesitamos DTOs?](#por-qué-necesitamos-dtos)
3. [Diferencias entre Entidad y DTO](#diferencias-entre-entidad-y-dto)
4. [Tipos de DTOs en nuestra API](#tipos-de-dtos-en-nuestra-api)
5. [Estructura del ContactoDto.cs](#estructura-del-contactodtocs)
6. [Explicación detallada del código](#explicación-detallada-del-código)
7. [Cuándo usar cada DTO](#cuándo-usar-cada-dto)
8. [Implementación en Controllers](#implementación-en-controllers)
9. [Mejores prácticas](#mejores-prácticas)

---

## ¿Qué es un DTO?

**DTO** significa **"Data Transfer Object"** (Objeto de Transferencia de Datos).

### Analogía simple:
Imagínate que tienes una **caja fuerte** en tu casa (tu base de datos) donde guardas toda tu información personal, incluidos documentos súper privados. 

Cuando alguien te pide información, ¿le das acceso completo a tu caja fuerte? **¡Por supuesto que no!**

En su lugar:
1. Sacas **solo la información** que esa persona necesita
2. La pones en una **carpeta simple**  
3. Le das **esa carpeta**

**Eso es exactamente lo que hace un DTO.**

---

## ¿Por qué necesitamos DTOs?

### 🔒 Seguridad
- El cliente nunca ve información sensible (como campos internos)
- No puede enviar datos que no debería modificar

### 🚀 Performance
- Solo transferimos los datos necesarios
- Menos datos = respuestas más rápidas

### 🧹 Código limpio
- Separamos la lógica de negocio de la transferencia de datos
- Cada DTO tiene un propósito específico

### 🛡️ Estabilidad
- Si cambiamos la entidad, no afectamos la API
- Los clientes no se rompen con cambios internos

---

## Diferencias entre Entidad y DTO

| **Entidad `Contacto`** (La caja fuerte) | **DTO** (La carpeta simple) |
|------------------------------------------|------------------------------|
| ✅ Tiene **TODA** la información | ✅ Solo datos necesarios |
| ✅ Validaciones complejas | ✅ Validaciones específicas |
| ✅ Conectada a base de datos | ❌ No conexión a BD |
| ✅ Campos internos (`Id`, `Activo`) | ✅ Solo campos públicos |
| ✅ Métodos complejos (`EsValido()`) | ❌ Sin lógica de negocio |
| ❌ Difícil de serializar | ✅ Perfecto para JSON |

---

## Tipos de DTOs en nuestra API

### 1. 📝 `CrearContactoDto`
**Propósito**: Crear contactos nuevos  
**Características**: Sin ID (se genera automáticamente)

### 2. 👁️ `ContactoDto` 
**Propósito**: Mostrar información completa  
**Características**: Con ID para identificación

### 3. ✏️ `ActualizarContactoDto`
**Propósito**: Actualizar contactos existentes  
**Características**: Con ID obligatorio

### 4. 📄 `ContactoResumenDto`
**Propósito**: Listas y resúmenes  
**Características**: Solo información esencial

---

## Estructura del ContactoDto.cs

```
ContactoDto.cs
├── ContactoBaseDto (abstract) ← Propiedades comunes
├── CrearContactoDto ← Para POST
├── ContactoDto ← Para GET (individual)  
├── ActualizarContactoDto ← Para PUT
└── ContactoResumenDto ← Para GET (listas)
```

### ¿Por qué esta estructura?

**`ContactoBaseDto` (abstract)**:
- Contiene propiedades comunes (Nombre, Apellido, Email, Telefono)
- Evita repetir código
- Si cambias una validación, se aplica a todas las clases hijas

---

## Explicación detallada del código

### 🏗️ Clase Base Abstract

```csharp
public abstract class ContactoBaseDto
```

**¿Qué significa `abstract`?**
- NO puedes crear objetos de esta clase directamente
- Es un "molde" o "plantilla" para otras clases
- Las clases hijas heredan sus propiedades

### 🛡️ Validaciones (Atributos)

```csharp
[Required(ErrorMessage = "El nombre es obligatorio")]
[StringLength(50, MinimumLength = 3)]
[RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$")]
```

**¿Qué hacen estos atributos?**
- `[Required]`: "Este campo es obligatorio"
- `[StringLength]`: "Debe tener entre X y Y caracteres"  
- `[EmailAddress]`: "Debe ser un email válido"
- `[RegularExpression]`: "Solo puede contener estos caracteres"

### 📐 Herencia

```csharp
public class CrearContactoDto : ContactoBaseDto
```

**¿Qué significa `: ContactoBaseDto`?**
- `CrearContactoDto` hereda de `ContactoBaseDto`
- Obtiene automáticamente todas sus propiedades
- Como un hijo que hereda características de sus padres

---

## Cuándo usar cada DTO

### 📤 Para **CREAR** contactos (POST)

**DTO**: `CrearContactoDto`

```json
// El cliente envía:
{
  "nombre": "Juan",
  "apellido": "Pérez",
  "email": "juan@email.com", 
  "telefono": "999-123-4567"
}
// Nota: SIN ID (se genera automáticamente)
```

### 👁️ Para **MOSTRAR** un contacto (GET individual)

**DTO**: `ContactoDto`

```json
// El servidor responde:
{
  "id": 5,
  "nombre": "Juan",
  "apellido": "Pérez",
  "email": "juan@email.com",
  "telefono": "999-123-4567" 
}
// Nota: CON ID (ya existe)
```

### ✏️ Para **ACTUALIZAR** contactos (PUT)

**DTO**: `ActualizarContactoDto`

```json  
// El cliente envía:
{
  "id": 5,
  "nombre": "Juan Carlos",     // ← Cambió
  "apellido": "Pérez",
  "email": "juan.carlos@email.com", // ← Cambió
  "telefono": "999-123-4567"
}
// Nota: CON ID (para saber cuál actualizar)
```

### 📄 Para **LISTAS** de contactos (GET lista)

**DTO**: `ContactoResumenDto`

```json
// El servidor responde:
[
  {
    "id": 1,
    "nombreCompleto": "Juan Pérez",
    "email": "juan@email.com"
  },
  {
    "id": 2, 
    "nombreCompleto": "María García",
    "email": "maria@email.com"
  }
]
// Nota: Solo información esencial
```

---

## Implementación en Controllers

### 🎯 Métodos del Controller con DTOs

```csharp
// ✅ CREAR contacto
[HttpPost]
public async Task<ActionResult<ContactoDto>> CrearContacto(CrearContactoDto dto)
{
    // Lógica para crear...
    return Ok(contactoCreado);
}

// ✅ OBTENER un contacto
[HttpGet("{id}")]
public async Task<ActionResult<ContactoDto>> ObtenerContacto(int id)
{
    // Lógica para obtener...
    return Ok(contacto);
}

// ✅ OBTENER lista de contactos  
[HttpGet]
public async Task<ActionResult<List<ContactoResumenDto>>> ObtenerContactos()
{
    // Lógica para listar...
    return Ok(contactos);
}

// ✅ ACTUALIZAR contacto
[HttpPut("{id}")]
public async Task<ActionResult<ContactoDto>> ActualizarContacto(int id, ActualizarContactoDto dto)
{
    // Lógica para actualizar...
    return Ok(contactoActualizado);
}
```

### 🔄 Flujo completo de datos

```
Cliente → DTO → Controller → Entidad → Base de Datos
                     ↓
Base de Datos → Entidad → Controller → DTO → Cliente
```

---

## Mejores prácticas

### ✅ **Hacer**

1. **Un DTO por operación**: Crear, Mostrar, Actualizar, Listar
2. **Usar validaciones específicas** en cada DTO
3. **Documentar con comentarios** qué hace cada DTO
4. **Usar herencia** para evitar código duplicado
5. **Nombres descriptivos**: `CrearContactoDto`, no `ContactoDto1`

### ❌ **No hacer**

1. **Un solo DTO para todo**: Muy inflexible
2. **DTOs sin validaciones**: Datos incorrectos llegarán a la BD
3. **Exponer campos internos**: Como `Activo`, `CreatedAt`
4. **DTOs con lógica de negocio**: Solo para transferir datos
5. **Cambiar DTOs frecuentemente**: Rompes a los clientes

---

## 🎯 Beneficios de esta implementación

### Para el **Desarrollador**:
- Código más organizado y mantenible
- Validaciones específicas por operación
- Menos bugs por datos incorrectos
- API más profesional

### Para el **Cliente** (Frontend/Mobile):
- Respuestas predecibles y consistentes
- Solo recibe los datos que necesita
- Menos datos transferidos = más rápido
- API clara y fácil de usar

### Para la **Empresa**:
- Mayor seguridad de datos
- Mejor performance de la aplicación
- Menos errores en producción
- Fácil mantenimiento y escalabilidad

---

## 🚀 Próximos pasos

1. **Implementa AutoMapper** para convertir entre Entidades y DTOs automáticamente
2. **Agrega versionado** a tus DTOs (`ContactoDtoV1`, `ContactoDtoV2`)
3. **Implementa paginación** en `ContactoResumenDto`
4. **Agrega más validaciones** según las reglas de negocio
5. **Crea DTOs para respuestas de error** estandarizadas

---

**¡Felicidades!** 🎉 Ahora entiendes completamente cómo funcionan los DTOs y por qué son fundamentales para crear APIs de calidad profesional.