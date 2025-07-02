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

---

## 6. Crear los archivos y carpetas

### 1. Crear carpetas
```bash
mkdir -p Application/Services Core/DTOs Core/Entities Core/Interfaces Infrastructure/Data Infrastructure/Repositories Presentation/Controllers
```

### 2. Entidad (modelo)
Archivo: `Core/Entities/Palindromo.cs`
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
```csharp
namespace PalindromosApi.Core.DTOs;

public class PalindromoDto
{
    public string Palabra { get; set; } = string.Empty;
}
```

### 4. Interfaz de repositorio
Archivo: `Core/Interfaces/IPalindromoRepository.cs`
```csharp
using PalindromosApi.Core.Entities;

namespace PalindromosApi.Core.Interfaces;

public interface IPalindromoRepository
{
    Task<Palindromo> GuardarAsync(Palindromo palindromo);
    Task<List<Palindromo>> ObtenerTodosAsync();
}
```

### 5. Contexto de base de datos
Archivo: `Infrastructure/Data/ApplicationDbContext.cs`
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
}
```

### 7. Servicio
Archivo: `Application/Services/PalindromoService.cs`
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

    // POST: api/Palindromo
    [HttpPost]
    public async Task<IActionResult> VerificarPalindromo([FromBody] PalindromoDto dto)
    {
        var esPalindromo = _service.EsPalindromo(dto.Palabra);
        var registro = new Palindromo
        {
            Palabra = dto.Palabra,
            EsPalindromo = esPalindromo,
            FechaConsulta = DateTime.Now
        };
        await _repo.GuardarAsync(registro);
        return Ok(new { palabra = dto.Palabra, esPalindromo });
    }

    // GET: api/Palindromo
    [HttpGet]
    public async Task<IActionResult> Historial()
    {
        var historial = await _repo.ObtenerTodosAsync();
        return Ok(historial);
    }
}
```

### 9. Configuración de la app y conexión a la base de datos
Archivo: `Program.cs`
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
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "server=localhost;port=3306;database=palindromosdb;user=TU_USUARIO;password=TU_PASSWORD"
  }
}
```

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

¡Listo! Ahora tienes una API en .NET 9 que te dice si una palabra es palíndroma, con base de datos, Swagger y todo explicado paso a paso. Si tienes dudas, revisa cada sección del índice y sigue los pasos.