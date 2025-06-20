# Guía Paso a Paso: Crear una Web API - Recetario Completo

## Índice
- [🏗️ FASE 1: PREPARACIÓN DEL PROYECTO](#-fase-1-preparación-del-proyecto)
  - [Paso 1: Crear el Proyecto Base](#paso-1-crear-el-proyecto-base)
  - [Paso 2: Limpiar el Proyecto](#paso-2-limpiar-el-proyecto)
- [🏛️ FASE 2: ARQUITECTURA - CREANDO LAS CAPAS](#-fase-2-arquitectura---creando-las-capas)
  - [Paso 3: Crear la Capa de Entidades (Entities)](#paso-3-crear-la-capa-de-entidades-entities)
  - [Paso 4: Crear la Capa de DTOs (Data Transfer Objects)](#paso-4-crear-la-capa-de-dtos-data-transfer-objects)
  - [Paso 5: Crear las Interfaces (Interfaces)](#paso-5-crear-las-interfaces-interfaces)
- [🗄️ FASE 3: ACCESO A DATOS](#-fase-3-acceso-a-datos)
  - [Paso 6: Configurar el Contexto de Base de Datos](#paso-6-configurar-el-contexto-de-base-de-datos)
  - [Paso 7: Implementar los Repositorios](#paso-7-implementar-los-repositorios)
- [🔧 FASE 4: LÓGICA DE NEGOCIO](#-fase-4-lógica-de-negocio)
  - [Paso 8: Crear los Servicios](#paso-8-crear-los-servicios)
- [🎮 FASE 5: CONTROLADORES Y API](#-fase-5-controladores-y-api)
  - [Paso 9: Crear los Controladores](#paso-9-crear-los-controladores)
  - [Paso 10: Configurar las Respuestas HTTP](#paso-10-configurar-las-respuestas-http)
- [⚙️ FASE 6: CONFIGURACIÓN](#-fase-6-configuración)
  - [Paso 11: Configurar la Inyección de Dependencias](#paso-11-configurar-la-inyección-de-dependencias)
  - [Paso 12: Configurar las Cadenas de Conexión](#paso-12-configurar-las-cadenas-de-conexión)
  - [Paso 13: Configurar Opciones Adicionales](#paso-13-configurar-opciones-adicionales)
- [🚀 FASE 7: MIGRACIÓN Y BASE DE DATOS](#-fase-7-migración-y-base-de-datos)
  - [Paso 14: Crear y Aplicar Migraciones](#paso-14-crear-y-aplicar-migraciones)
- [🧪 FASE 8: PRUEBAS Y VALIDACIÓN](#-fase-8-pruebas-y-validación)
  - [Paso 15: Probar la API](#paso-15-probar-la-api)
  - [Paso 16: Validar la Estructura](#paso-16-validar-la-estructura)
- [🎯 RESULTADO FINAL](#-resultado-final)

---

## 🏗️ FASE 1: PREPARACIÓN DEL PROYECTO

### Paso 1: Crear el Proyecto Base

**Comandos en orden para la creación:**

```bash
# 1. Crear nuevo proyecto Web API
dotnet new webapi -n CARTELERAAPI

# 2. Navegar al directorio del proyecto
cd CARTELERAAPI

# 3. Agregar paquetes NuGet necesarios
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Design

# 4. Crear la estructura de carpetas
mkdir Entities
mkdir Core
mkdir Core\DTOs
mkdir Core\Interfaces
mkdir Infrastructure
mkdir Infrastructure\Data
mkdir Infrastructure\Repositories
mkdir Application
mkdir Application\Services
mkdir Presentation
mkdir Presentation\Controllers

# 5. Mover Controllers existente a Presentation
move Controllers Presentation\Controllers
```

**Estructura inicial después de la creación:**
```
CARTELERAAPI/
├── 📁 Application/
│   └── 📁 Services/
├── 📁 Core/
│   ├── 📁 DTOs/
│   └── 📁 Interfaces/
├── 📁 Entities/
├── 📁 Infrastructure/
│   ├── 📁 Data/
│   └── 📁 Repositories/
├── 📁 Presentation/
│   └── 📁 Controllers/
├── 📁 Properties/
│   └── launchSettings.json
├── appsettings.json
├── appsettings.Development.json
├── Program.cs
└── CARTELERAAPI.csproj
```

### Paso 2: Limpiar el Proyecto
1. Elimina `WeatherForecastController.cs` si existe
2. Elimina `WeatherForecast.cs` si existe
3. Mantén solo la estructura básica del proyecto
4. Verifica que tengas los archivos de configuración principales

---

## 🏛️ FASE 2: ARQUITECTURA - CREANDO LAS CAPAS

### Paso 3: Crear la Capa de Entidades (Entities)
**Propósito**: Definir los modelos de datos principales de tu aplicación

1. Crea las clases de entidades en la carpeta "Entities"
2. Define las propiedades principales de cada entidad
3. Establece las relaciones entre entidades (llaves foráneas)
4. Añade validaciones básicas usando Data Annotations

**Estructura después de crear entidades:**
```
CARTELERAAPI/
├── 📁 Entities/
│   └── Movie.cs
├── ...
```

**Ejemplo de entidad Movie.cs:**
```csharp
public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public int Duration { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Director { get; set; }
    public decimal Price { get; set; }
}
```

### Paso 4: Crear la Capa de DTOs (Data Transfer Objects)
**Propósito**: Definir los objetos que se intercambiarán entre cliente y servidor

1. Por cada entidad, crea sus DTOs correspondientes:
   - DTO para creación (sin ID)
   - DTO para actualización
   - DTO para consulta (puede incluir datos relacionados)
**Ejemplos de DTOs:**

```csharp
// MovieCreateDto.cs - Para crear película
public class MovieCreateDto
{
    public string Title { get; set; }
    public string Genre { get; set; }
    public int Duration { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Director { get; set; }
    public decimal Price { get; set; }
}

// MovieResponseDto.cs - Para responder datos
public class MovieResponseDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public int Duration { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Director { get; set; }
    public decimal Price { get; set; }
}
```

**Estructura después de crear DTOs:**
```
CARTELERAAPI/
├── 📁 Core/
│   ├── 📁 DTOs/
│   │   ├── MovieCreateDto.cs
│   │   └── MovieResponseDto.cs
│   └── ...
├── ...
```

### Paso 5: Crear las Interfaces (Interfaces)
**Propósito**: Definir los contratos que implementarán los repositorios

1. Define la interfaz del repositorio principal (IMovieRepository.cs)
2. Declara los métodos que necesitarás:
   - Obtener todos los registros
   - Obtener por ID
   - Crear nuevo registro
   - Actualizar registro existente
   - Eliminar registro
**Ejemplo de interfaz IMovieRepository.cs:**
```csharp
public interface IMovieRepository
{
    Task<List<Movie>> GetAllAsync();
    Task<Movie> GetByIdAsync(int id);
    Task<Movie> CreateAsync(Movie movie);
    Task<Movie> UpdateAsync(Movie movie);
    Task<bool> DeleteAsync(int id);
    Task<List<Movie>> GetByGenreAsync(string genre);
}
```

**Estructura después de crear interfaces:**
```
CARTELERAAPI/
├── 📁 Core/
│   ├── 📁 Interfaces/
│   │   ├── IMovieRepository.cs
│   │   └── IMovieService.cs
│   └── ...
├── ...
```

---

## 🗄️ FASE 3: ACCESO A DATOS

### Paso 6: Configurar el Contexto de Base de Datos
**Propósito**: Establecer la conexión y configuración con la base de datos

1. Crea la clase MovieDbContext.cs en "Infrastructure/Data"
2. Hereda de DbContext
3. Define los DbSet para cada entidad
4. Configura las relaciones entre tablas en OnModelCreating
**Ejemplo MovieDbContext.cs:**
```csharp
public class MovieDbContext : DbContext
{
    public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options) { }
    
    public DbSet<Movie> Movies { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Genre).HasMaxLength(50);
            entity.Property(e => e.Director).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
        });
    }
}
```

**Estructura después del contexto:**
```
CARTELERAAPI/
├── 📁 Infrastructure/
│   ├── 📁 Data/
│   │   └── MovieDbContext.cs
│   └── ...
├── ...
```

### Paso 7: Implementar los Repositorios
**Propósito**: Crear las clases que manejarán las operaciones de base de datos

1. Crea las clases de repositorio en "Infrastructure/Repositories"
2. Implementa las interfaces correspondientes
3. Inyecta el contexto de base de datos
4. Implementa cada método definido en la interfaz
5. Maneja las excepciones y validaciones necesarias

**Estructura después de los repositorios:**
```
CARTELERAAPI/
├── 📁 Infrastructure/
│   ├── 📁 Repositories/
│   │   └── MovieRepository.cs
│   └── ...
├── ...
```

---

## 🔧 FASE 4: LÓGICA DE NEGOCIO

### Paso 8: Crear los Servicios
**Propósito**: Implementar la lógica de negocio de la aplicación

1. Crea las clases de servicio en "Application/Services"
2. Inyecta los repositorios correspondientes
3. Implementa la lógica de negocio:
   - Validaciones complejas
   - Transformaciones de datos
   - Reglas de negocio específicas
4. Maneja la conversión entre entidades y DTOs

**Estructura después de los servicios:**
```
CARTELERAAPI/
├── 📁 Application/
│   ├── 📁 Services/
│   │   └── MovieService.cs
│   └── ...
├── ...
```

---

## 🎮 FASE 5: CONTROLADORES Y API

### Paso 9: Crear los Controladores
**Propósito**: Exponer los endpoints de la API

1. Crea los controladores en "Presentation/Controllers"
2. Hereda de ControllerBase
3. Añade el atributo [ApiController]
4. Define la ruta base con [Route("api/[controller]")]
5. Inyecta el servicio correspondiente
6. Crea los métodos para cada endpoint:
   - GET para obtener datos
   - POST para crear
   - PUT para actualizar
**Ejemplo MoviesController.cs:**
```csharp
[ApiController]
[Route("api/[controller]")]
public class MoviesController : ControllerBase
{
    private readonly MovieService _movieService;
    
    public MoviesController(MovieService movieService)
    {
        _movieService = movieService;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<MovieResponseDto>>> GetMovies()
    {
        try
        {
            var movies = await _movieService.GetAllMoviesAsync();
            return Ok(movies);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Error interno del servidor");
        }
    }
    
    [HttpPost]
    public async Task<ActionResult<MovieResponseDto>> CreateMovie(MovieCreateDto createDto)
    {
        try
        {
            var movie = await _movieService.CreateMovieAsync(createDto);
            return CreatedAtAction(nameof(GetMovies), new { id = movie.Id }, movie);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Error interno del servidor");
        }
    }
}
```

**Estructura después de los controladores:**
```
CARTELERAAPI/
├── 📁 Presentation/
│   ├── 📁 Controllers/
│   │   └── MoviesController.cs
│   └── ...
├── ...
```

### Paso 10: Configurar las Respuestas HTTP
1. Implementa códigos de estado HTTP apropiados
2. Maneja las excepciones con try-catch
3. Retorna respuestas consistentes
4. Documenta cada endpoint con comentarios XML

---

## ⚙️ FASE 6: CONFIGURACIÓN

### Paso 11: Configurar la Inyección de Dependencias
**Propósito**: Registrar todos los servicios en el contenedor DI

1. Ve al archivo Program.cs
2. Registra el contexto de base de datos
3. Registra los repositorios con sus interfaces
4. Registra los servicios de aplicación
**Ejemplo de configuración en Program.cs:**
```csharp
var builder = WebApplication.CreateBuilder(args);

// Agregar servicios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar Entity Framework
builder.Services.AddDbContext<MovieDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar repositorios y servicios
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<MovieService>();

var app = builder.Build();

// Configurar pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
```

### Paso 12: Configurar las Cadenas de Conexión
1. Ve a appsettings.json
2. Añade la sección "ConnectionStrings"
3. Define tu cadena de conexión a la base de datos
**Ejemplo appsettings.json:**
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=CarteleraDB;Trusted_Connection=true;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

### Paso 13: Configurar Opciones Adicionales
1. En appsettings.Development.json configura:
   - Logging levels
   - Configuraciones de desarrollo
2. En launchSettings.json ajusta:
   - Puertos de ejecución
   - Variables de entorno
   - Perfiles de lanzamiento

---

## 🚀 FASE 7: MIGRACIÓN Y BASE DE DATOS

### Paso 14: Crear y Aplicar Migraciones

**Comandos en orden:**
```bash
# 1. Crear migración inicial
dotnet ef migrations add InitialCreate

# 2. Aplicar migración a la base de datos
dotnet ef database update

# 3. Verificar que las tablas se crearon
# (Usar SQL Server Management Studio o similar)
```

---

## 🧪 FASE 8: PRUEBAS Y VALIDACIÓN

### Paso 15: Probar la API
1. Ejecuta el proyecto con: `dotnet run`
2. Abre Swagger UI (se abre automáticamente)
3. Prueba cada endpoint:
   - Verifica que respondan correctamente
   - Prueba con datos válidos e inválidos
   - Confirma los códigos de estado HTTP
4. Usa herramientas como Postman para pruebas más detalladas

### Paso 16: Validar la Estructura
1. Revisa que cada carpeta tenga su propósito específico
2. Confirma que las dependencias fluyan correctamente
3. Verifica que no haya referencias circulares
4. Asegúrate de que la separación de responsabilidades sea clara

**Estructura final completa:**
```
CARTELERAAPI/
├── 📁 Application/
│   └── 📁 Services/
│       └── MovieService.cs
├── 📁 Core/
│   ├── 📁 DTOs/
│   │   ├── MovieCreateDto.cs
│   │   └── MovieResponseDto.cs
│   └── 📁 Interfaces/
│       ├── IMovieRepository.cs
│       └── IMovieService.cs
├── 📁 Entities/
│   └── Movie.cs
├── 📁 Infrastructure/
│   ├── 📁 Data/
│   │   └── MovieDbContext.cs
│   └── 📁 Repositories/
│       └── MovieRepository.cs
├── 📁 Migrations/
│   ├── 20240101000000_InitialCreate.cs
│   └── MovieDbContextModelSnapshot.cs
├── 📁 Presentation/
│   └── 📁 Controllers/
│       └── MoviesController.cs
├── 📁 Properties/
│   └── launchSettings.json
├── appsettings.json
├── appsettings.Development.json
├── Program.cs
└── CARTELERAAPI.csproj
```

---

## 🎯 RESULTADO FINAL

Al seguir esta guía paso a paso, tendrás una Web API completamente funcional con:

- **Arquitectura limpia** separada por responsabilidades
- **Acceso a datos** eficiente y organizado
- **Lógica de negocio** centralizada en servicios
- **API REST** bien estructurada y documentada
- **Configuración** flexible para diferentes entornos
- **Base sólida** para escalar y mantener

¡Tu Web API estará lista para recibir peticiones y gestionar datos de películas en tu cartelera!