# Guía Súper Fácil: API para Saber si una Palabra es Palíndroma en .NET

## Requisitos previos
- Tener instalado [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) o superior
- Tener instalado MySQL Server (o acceso a una base de datos MySQL)
- Un editor de código (por ejemplo, [Visual Studio Code](https://code.visualstudio.com/))
- Ganas de aprender

## Índice
1. [¿Qué es una WebAPI y qué es un palíndromo?](#que-es-una-webapi-y-qué-es-un-palíndromo)
2. [Crear la base de datos](#crear-la-base-de-datos)
3. [Crear el espacio de trabajo](#crear-el-espacio-de-trabajo)
4. [Instalar los paquetes NuGet necesarios](#instalar-los-paquetes-nuget-necesarios)
5. [Estructura del proyecto y explicación](#estructura-del-proyecto-y-explicacion)
6. [Crear los archivos y carpetas](#crear-los-archivos-y-carpetas)
7. [Conectar la base de datos](#conectar-la-base-de-datos)
8. [Ejecutar y probar la API (Swagger y Postman)](#ejecutar-y-probar-la-api-swagger-y-postman)

---

## 1. ¿Qué es una WebAPI y qué es un palíndromo?
Una **WebAPI** es un programa que permite que diferentes aplicaciones se comuniquen entre sí usando internet. Por ejemplo, una app de celular puede pedirle datos a una WebAPI y la WebAPI le responde.

Un **palíndromo** es una palabra o frase que se lee igual de izquierda a derecha que de derecha a izquierda. Ejemplo: "reconocer", "anilina".

---

## 2. Crear la base de datos
Antes de programar, crea una base de datos en MySQL (puedes usar phpMyAdmin, DBeaver, consola, etc). Por ejemplo:

```sql
CREATE DATABASE palindromosdb;
```

---

## 3. Crear el espacio de trabajo
El espacio de trabajo es la carpeta donde estará todo tu proyecto. Puedes crearla así:

```bash
mkdir PalindromosApi
cd PalindromosApi
```

Luego, crea el proyecto base:

```bash
dotnet new webapi -n PalindromosApi
cd PalindromosApi
```

---

## 4. Instalar los paquetes NuGet necesarios
Instala estos paquetes para que todo funcione (todas las versiones son compatibles con .NET 9):

```bash
# Entity Framework Core y herramientas para MySQL
dotnet add package Microsoft.EntityFrameworkCore --version 9.0.6
dotnet add package Pomelo.EntityFrameworkCore.MySql --version 9.0.0-preview.3.efcore.9.0.0
dotnet add package Microsoft.EntityFrameworkCore.Design --version 9.0.6
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 9.0.6

# Swagger/OpenAPI para documentación interactiva
dotnet add package Swashbuckle.AspNetCore --version 7.0.0
dotnet add package Microsoft.AspNetCore.OpenApi --version 9.0.6
```

Verifica que hayas instalado correctamente todos los paquetes

```bash
dotnet list package
```

---

## 5. Estructura del proyecto y explicación
Así debe quedar la estructura de carpetas y archivos:

```
PalindromosApi/
  Application/
    Services/                # Lógica principal (aquí va si es palíndromo)
  Core/
    DTOs/                    # Objetos para transferir datos
    Entities/                # Modelos de la base de datos
    Interfaces/              # Contratos de clases
  Infrastructure/
    Data/                    # Contexto de la base de datos
    Repositories/            # Acceso a datos
  Presentation/
    Controllers/             # Controladores (reciben las peticiones)
  Program.cs                 # Punto de entrada de la app
  appsettings.json           # Configuración de la app
  PalindromosApi.csproj      # Archivo de proyecto de .NET
```

### ¿Para qué sirve cada carpeta y archivo?

- **Application/Services/**: Aquí va la lógica principal de la app, por ejemplo, la función que verifica si una palabra es palíndroma. Es el "cerebro" de la aplicación.
- **Core/DTOs/**: DTO significa "Data Transfer Object". Son clases simples que solo llevan datos de un lado a otro, por ejemplo, lo que recibes en una petición.
- **Core/Entities/**: Aquí están los modelos que representan las tablas de la base de datos. Cada clase es como un molde de los datos que guardas.
- **Core/Interfaces/**: Son los contratos que dicen qué métodos debe tener una clase. Así puedes cambiar la implementación sin romper el código.
- **Infrastructure/Data/**: Aquí está el contexto de la base de datos, que es la clase que conecta tu app con MySQL usando Entity Framework.
- **Infrastructure/Repositories/**: Aquí van las clases que realmente hablan con la base de datos (guardar, leer, etc.).
- **Presentation/Controllers/**: Los controladores reciben las peticiones HTTP (como POST o GET) y responden. Son la "puerta de entrada" a tu API.
- **Program.cs**: Es el punto de inicio de la app, donde se configura todo y se arranca el servidor.
- **appsettings.json**: Aquí pones configuraciones como la cadena de conexión a la base de datos.
- **PalindromosApi.csproj**: Archivo de proyecto de .NET, donde se listan los paquetes y configuraciones globales.

---

## 6. Crear los archivos y carpetas

### 1. Crear carpetas
```bash
mkdir -p Application/Services, Core/DTOs, Core/Entities, Core/Interfaces, Infrastructure/Data, Infrastructure/Repositories, Presentation/Controllers
```

### 2. Entidad (modelo)
Archivo: `Core/Entities/Palindromo.cs`
> **¿Para qué sirve?**
> Es la clase que representa la tabla en la base de datos. Cada vez que guardas una palabra, se crea un objeto de este tipo.
```csharp
namespace PalindromosApi.Core.Entities;

public class Palindromo
{
    public int Id { get; set; }
    public string Palabra { get; set; } = string.Empty;
    public bool EsPalindromo { get; set; }
    public DateTime FechaConsulta { get; set; }
}
```

### 3. DTO
Archivo: `Core/DTOs/PalindromoDto.cs`
> **¿Para qué sirve?**
> Es el objeto que recibes en la petición. Solo lleva la palabra a verificar, nada más.
```csharp
namespace PalindromosApi.Core.DTOs;

public class PalindromoDto
{
    public string Palabra { get; set; } = string.Empty;
}
```

### 4. Interfaz de repositorio
Archivo: `Core/Interfaces/IPalindromoRepository.cs`
> **¿Para qué sirve?**
> Define los métodos que debe tener cualquier clase que quiera guardar o leer palíndromos de la base de datos.
```csharp
using PalindromosApi.Core.Entities;

namespace PalindromosApi.Core.Interfaces;

public interface IPalindromoRepository
{
    Task<Palindromo> GuardarAsync(Palindromo palindromo);
    Task<List<Palindromo>> ObtenerTodosAsync();
    Task<Palindromo?> ObtenerPorIdAsync(int id);
    Task<bool> ActualizarAsync(Palindromo palindromo);
    Task<bool> EliminarAsync(int id);
}
```

### 5. Contexto de base de datos
Archivo: `Infrastructure/Data/ApplicationDbContext.cs`
> **¿Para qué sirve?**
> Es la clase que conecta tu app con la base de datos usando Entity Framework. Aquí se registran las tablas.
```csharp
using Microsoft.EntityFrameworkCore;
using PalindromosApi.Core.Entities;

namespace PalindromosApi.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<Palindromo> Palindromos { get; set; }
}
```

### 6. Repositorio
Archivo: `Infrastructure/Repositories/PalindromoRepository.cs`
> **¿Para qué sirve?**
> Es la clase que implementa la interfaz y realmente guarda y lee datos de la base de datos.
```csharp
using PalindromosApi.Core.Entities;
using PalindromosApi.Core.Interfaces;
using PalindromosApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace PalindromosApi.Infrastructure.Repositories;

public class PalindromoRepository : IPalindromoRepository
{
    private readonly ApplicationDbContext _context;
    public PalindromoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Palindromo> GuardarAsync(Palindromo palindromo)
    {
        _context.Palindromos.Add(palindromo);
        await _context.SaveChangesAsync();
        return palindromo;
    }

    public async Task<List<Palindromo>> ObtenerTodosAsync()
    {
        return await _context.Palindromos.ToListAsync();
    }

    public async Task<Palindromo?> ObtenerPorIdAsync(int id)
    {
        return await _context.Palindromos.FindAsync(id);
    }

    public async Task<bool> ActualizarAsync(Palindromo palindromo)
    {
        var existente = await _context.Palindromos.FindAsync(palindromo.Id);
        if (existente == null) return false;
        existente.Palabra = palindromo.Palabra;
        existente.EsPalindromo = palindromo.EsPalindromo;
        existente.FechaConsulta = palindromo.FechaConsulta;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> EliminarAsync(int id)
    {
        var existente = await _context.Palindromos.FindAsync(id);
        if (existente == null) return false;
        _context.Palindromos.Remove(existente);
        await _context.SaveChangesAsync();
        return true;
    }
}
```

### 7. Servicio
Archivo: `Application/Services/PalindromoService.cs`
> **¿Para qué sirve?**
> Aquí está la lógica que determina si una palabra es palíndroma. Es una clase simple, pero puedes poner más lógica aquí si tu app crece.
```csharp
namespace PalindromosApi.Application.Services;

public class PalindromoService
{
    public bool EsPalindromo(string palabra)
    {
        if (string.IsNullOrWhiteSpace(palabra)) return false;
        var limpia = palabra.Replace(" ", "").ToLower();
        var reversa = new string(limpia.Reverse().ToArray());
        return limpia == reversa;
    }
}
```

### 8. Controlador
Archivo: `Presentation/Controllers/PalindromoController.cs`
> **¿Para qué sirve?**
> Es el "puente" entre el usuario y la lógica de la app. Recibe las peticiones, llama al servicio y al repositorio, y responde.
```csharp
using Microsoft.AspNetCore.Mvc;
using PalindromosApi.Application.Services;
using PalindromosApi.Core.DTOs;
using PalindromosApi.Core.Entities;
using PalindromosApi.Core.Interfaces;

namespace PalindromosApi.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PalindromoController : ControllerBase
{
    private readonly PalindromoService _service;
    private readonly IPalindromoRepository _repo;
    public PalindromoController(PalindromoService service, IPalindromoRepository repo)
    {
        _service = service;
        _repo = repo;
    }

    // GET: api/Palindromo
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var historial = await _repo.ObtenerTodosAsync();
        return Ok(historial);
    }

    // GET: api/Palindromo/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var palindromo = await _repo.ObtenerPorIdAsync(id);
        if (palindromo == null) return NotFound();
        return Ok(palindromo);
    }

    // POST: api/Palindromo
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] PalindromoDto dto)
    {
        var esPalindromo = _service.EsPalindromo(dto.Palabra);
        var registro = new Palindromo
        {
            Palabra = dto.Palabra,
            EsPalindromo = esPalindromo,
            FechaConsulta = DateTime.Now
        };
        await _repo.GuardarAsync(registro);
        return CreatedAtAction(nameof(GetById), new { id = registro.Id }, registro);
    }

    // PUT: api/Palindromo/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] PalindromoDto dto)
    {
        var existente = await _repo.ObtenerPorIdAsync(id);
        if (existente == null) return NotFound();

        var esPalindromo = _service.EsPalindromo(dto.Palabra);
        existente.Palabra = dto.Palabra;
        existente.EsPalindromo = esPalindromo;
        existente.FechaConsulta = DateTime.Now;

        var actualizado = await _repo.ActualizarAsync(existente);
        if (!actualizado) return StatusCode(500, "No se pudo actualizar");
        return NoContent();
    }

    // DELETE: api/Palindromo/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var eliminado = await _repo.EliminarAsync(id);
        if (!eliminado) return NotFound();
        return NoContent();
    }
}
```

### 9. Configuración de la app y conexión a la base de datos
Archivo: `Program.cs`
> **¿Para qué sirve?**
> Aquí se configura todo: la conexión a la base de datos, los servicios, los controladores y Swagger para la documentación.
```csharp
using Microsoft.EntityFrameworkCore;
using PalindromosApi.Infrastructure.Data;
using PalindromosApi.Infrastructure.Repositories;
using PalindromosApi.Core.Interfaces;
using PalindromosApi.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Configurar la cadena de conexión a MySQL
// ⚠️ Solo para desarrollo: puedes usar user-secrets para no poner la contraseña en el código
// dotnet user-secrets set "ConnectionStrings:DefaultConnection" "server=localhost;port=3306;database=palindromosdb;user=TU_USUARIO;password=TU_PASSWORD"

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));

builder.Services.AddScoped<IPalindromoRepository, PalindromoRepository>();
builder.Services.AddScoped<PalindromoService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();
```

En `appsettings.json` pon la cadena de conexión:
> **¿Para qué sirve?**
> Aquí se guarda la información para conectarse a la base de datos. ¡No pongas tu contraseña real en proyectos públicos!
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "server=localhost;port=3306;database=palindromosdb;user=TU_USUARIO;password=TU_PASSWORD"
  }
}
```

---

## Código completo por sección

A continuación tienes el código completo y funcional de cada parte de la WebAPI con CRUD completo (GetAll, GetById, Post, Put, Delete). Puedes copiar y pegar cada bloque en su respectivo archivo.

### 1. Core/Entities/Palindromo.cs
```csharp
namespace PalindromosApi.Core.Entities;

public class Palindromo
{
    public int Id { get; set; }
    public string Palabra { get; set; } = string.Empty;
    public bool EsPalindromo { get; set; }
    public DateTime FechaConsulta { get; set; }
}
```

### 2. Core/DTOs/PalindromoDto.cs
```csharp
namespace PalindromosApi.Core.DTOs;

public class PalindromoDto
{
    public string Palabra { get; set; } = string.Empty;
}
```

### 3. Core/Interfaces/IPalindromoRepository.cs
```csharp
using PalindromosApi.Core.Entities;

namespace PalindromosApi.Core.Interfaces;

public interface IPalindromoRepository
{
    Task<Palindromo> GuardarAsync(Palindromo palindromo);
    Task<List<Palindromo>> ObtenerTodosAsync();
    Task<Palindromo?> ObtenerPorIdAsync(int id);
    Task<bool> ActualizarAsync(Palindromo palindromo);
    Task<bool> EliminarAsync(int id);
}
```

### 4. Infrastructure/Data/ApplicationDbContext.cs
```csharp
using Microsoft.EntityFrameworkCore;
using PalindromosApi.Core.Entities;

namespace PalindromosApi.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<Palindromo> Palindromos { get; set; }
}
```

### 5. Infrastructure/Repositories/PalindromoRepository.cs
```csharp
using PalindromosApi.Core.Entities;
using PalindromosApi.Core.Interfaces;
using PalindromosApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace PalindromosApi.Infrastructure.Repositories;

public class PalindromoRepository : IPalindromoRepository
{
    private readonly ApplicationDbContext _context;
    public PalindromoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Palindromo> GuardarAsync(Palindromo palindromo)
    {
        _context.Palindromos.Add(palindromo);
        await _context.SaveChangesAsync();
        return palindromo;
    }

    public async Task<List<Palindromo>> ObtenerTodosAsync()
    {
        return await _context.Palindromos.ToListAsync();
    }

    public async Task<Palindromo?> ObtenerPorIdAsync(int id)
    {
        return await _context.Palindromos.FindAsync(id);
    }

    public async Task<bool> ActualizarAsync(Palindromo palindromo)
    {
        var existente = await _context.Palindromos.FindAsync(palindromo.Id);
        if (existente == null) return false;
        existente.Palabra = palindromo.Palabra;
        existente.EsPalindromo = palindromo.EsPalindromo;
        existente.FechaConsulta = palindromo.FechaConsulta;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> EliminarAsync(int id)
    {
        var existente = await _context.Palindromos.FindAsync(id);
        if (existente == null) return false;
        _context.Palindromos.Remove(existente);
        await _context.SaveChangesAsync();
        return true;
    }
}
```

### 6. Application/Services/PalindromoService.cs
```csharp
namespace PalindromosApi.Application.Services;

public class PalindromoService
{
    public bool EsPalindromo(string palabra)
    {
        if (string.IsNullOrWhiteSpace(palabra)) return false;
        var limpia = palabra.Replace(" ", "").ToLower();
        var reversa = new string(limpia.Reverse().ToArray());
        return limpia == reversa;
    }
}
```

### 7. Presentation/Controllers/PalindromoController.cs
```csharp
using Microsoft.AspNetCore.Mvc;
using PalindromosApi.Application.Services;
using PalindromosApi.Core.DTOs;
using PalindromosApi.Core.Entities;
using PalindromosApi.Core.Interfaces;

namespace PalindromosApi.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PalindromoController : ControllerBase
{
    private readonly PalindromoService _service;
    private readonly IPalindromoRepository _repo;
    public PalindromoController(PalindromoService service, IPalindromoRepository repo)
    {
        _service = service;
        _repo = repo;
    }

    // GET: api/Palindromo
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var historial = await _repo.ObtenerTodosAsync();
        return Ok(historial);
    }

    // GET: api/Palindromo/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var palindromo = await _repo.ObtenerPorIdAsync(id);
        if (palindromo == null) return NotFound();
        return Ok(palindromo);
    }

    // POST: api/Palindromo
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] PalindromoDto dto)
    {
        var esPalindromo = _service.EsPalindromo(dto.Palabra);
        var registro = new Palindromo
        {
            Palabra = dto.Palabra,
            EsPalindromo = esPalindromo,
            FechaConsulta = DateTime.Now
        };
        await _repo.GuardarAsync(registro);
        return CreatedAtAction(nameof(GetById), new { id = registro.Id }, registro);
    }

    // PUT: api/Palindromo/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] PalindromoDto dto)
    {
        var existente = await _repo.ObtenerPorIdAsync(id);
        if (existente == null) return NotFound();

        var esPalindromo = _service.EsPalindromo(dto.Palabra);
        existente.Palabra = dto.Palabra;
        existente.EsPalindromo = esPalindromo;
        existente.FechaConsulta = DateTime.Now;

        var actualizado = await _repo.ActualizarAsync(existente);
        if (!actualizado) return StatusCode(500, "No se pudo actualizar");
        return NoContent();
    }

    // DELETE: api/Palindromo/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var eliminado = await _repo.EliminarAsync(id);
        if (!eliminado) return NotFound();
        return NoContent();
    }
}
```

### 8. Program.cs
```csharp
using Microsoft.EntityFrameworkCore;
using PalindromosApi.Infrastructure.Data;
using PalindromosApi.Infrastructure.Repositories;
using PalindromosApi.Core.Interfaces;
using PalindromosApi.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Configurar la cadena de conexión a MySQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));

builder.Services.AddScoped<IPalindromoRepository, PalindromoRepository>();
builder.Services.AddScoped<PalindromoService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();
```

### 9. appsettings.json
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "server=localhost;port=3306;database=palindromosdb;user=TU_USUARIO;password=TU_PASSWORD"
  }
}
```

---

Puedes copiar y pegar cada bloque en su archivo correspondiente. Si tienes dudas sobre dónde va cada archivo, revisa la sección de estructura y explicación más arriba en este mismo README.

---

## 7. Conectar la base de datos
Asegúrate de que tu base de datos MySQL esté corriendo y la cadena de conexión sea correcta en `appsettings.json`.

---

## 8. Ejecutar y probar la API (Swagger y Postman)

1. Ejecuta el proyecto:
   ```bash
   dotnet run
   ```
2. Abre tu navegador y entra a:
   - La consola te mostrará la URL de Swagger, normalmente será algo como:
     - [https://localhost:7108/swagger](https://localhost:7108/swagger) o [http://localhost:5232/swagger](http://localhost:5232/swagger)
   - Aquí puedes probar el endpoint POST para verificar si una palabra es palíndroma:
     - **POST** `/api/Palindromo` con un JSON como:
       ```json
       {
         "palabra": "reconocer"
       }
       ```
     - Respuesta:
       ```json
       {
         "palabra": "reconocer",
         "esPalindromo": true
       }
       ```
   - También puedes usar el endpoint GET `/api/Palindromo` para ver el historial de consultas.
3. También puedes usar [Postman](https://www.postman.com/) para probar los endpoints.

---

## 9. ¿Cómo se relacionan y funcionan todas las partes?

Imagina la API como una fábrica:
- El **usuario** manda una palabra (por ejemplo, desde Swagger o Postman) al **controlador**.
- El **controlador** recibe la petición y se la pasa al **servicio** para que haga la lógica (ver si es palíndromo).
- El **servicio** responde si la palabra es o no palíndroma.
- El **controlador** le pide al **repositorio** que guarde el resultado en la base de datos.
- El **repositorio** usa el **contexto de base de datos** para guardar la información en MySQL.
- Si pides el historial, el **controlador** le pide al **repositorio** todos los registros y te los muestra.

**¿Por qué está separado así?**
- Así puedes cambiar la base de datos, la lógica o la forma de recibir peticiones sin romper todo lo demás.
- Es más fácil de mantener, probar y escalar.

**¿Cómo funciona todo junto?**
1. El usuario manda una palabra.
2. El controlador la recibe y llama al servicio.
3. El servicio verifica si es palíndromo.
4. El controlador guarda el resultado usando el repositorio.
5. El repositorio guarda en la base de datos.
6. Puedes consultar el historial de palabras verificadas.

¡Y listo! Así cada parte tiene su función y todo trabaja en equipo para que tu API sea clara, ordenada y fácil de entender.