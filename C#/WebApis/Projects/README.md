# 🎬 Guía Completa: Crear una Web API para Cartelera de Películas

## 🤔 ¿Qué vamos a construir?
Imagina que tienes un cine y quieres crear un sistema digital para manejar todas tus películas. Nuestra Web API será como el **cerebro digital** del cine que puede:
- Guardar información de películas
- Mostrar qué películas tienes
- Añadir nuevas películas
- Modificar información de películas existentes
- Eliminar películas que ya no están en cartelera

Es como tener un **bibliotecario digital súper inteligente** que nunca se cansa y siempre sabe dónde está cada película.

---

## 📚 ¿Qué es una Web API?

**Analogía Simple**: Una Web API es como un **mesero en un restaurante**:
- Tú (el cliente) le pides algo específico
- El mesero va a la cocina (base de datos) 
- Trae exactamente lo que pediste
- Te lo entrega en un formato que entiendes

La diferencia es que en lugar de comida, nuestra API maneja **información de películas**.

---

## 🏗️ FASE 1: PREPARACIÓN DEL PROYECTO

### 🎯 ¿Qué hacemos aquí?
Preparamos nuestro "terreno" para construir nuestra aplicación. Es como **limpiar y organizar tu escritorio antes de hacer la tarea**.

### Paso 1: Crear el Proyecto Base

**¿Por qué estos comandos?**

```bash
# Esto crea una "casa" nueva para nuestra aplicación
dotnet new webapi -n CARTELERAAPI

# Entramos a nuestra "casa"
cd CARTELERAAPI

# Instalamos las "herramientas" que necesitaremos
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Design
```

**Analogía**: Es como comprar una casa nueva y luego ir a la ferretería a comprar todas las herramientas que necesitarás (martillo, destornilladores, etc.).

**¿Qué hace cada paquete?**
- `EntityFrameworkCore`: Es nuestro **traductor** entre C# y la base de datos
- `SqlServer`: Le dice a nuestro traductor que hable el "idioma" de SQL Server
- `Tools` y `Design`: Son como **asistentes** que nos ayudan a crear tablas automáticamente

### Paso 2: Crear Carpetas (Organización)

```bash
# Creamos "cajones" para organizar nuestro código
mkdir Entities          # Aquí van las "cosas" principales (como Movie)
mkdir Core              # El "corazón" de nuestra aplicación
mkdir Infrastructure    # Las "tuberías" que conectan todo
mkdir Application       # La "lógica" de nuestro negocio
mkdir Presentation      # Lo que "ve" el usuario
```

**Analogía**: Es como organizar tu cuarto en diferentes cajones:
- **Entities**: Cajón de juguetes (nuestras películas)
- **Core**: Cajón de cosas importantes (reglas del juego)
- **Infrastructure**: Cajón de cables y conexiones
- **Application**: Cajón donde haces tus tareas
- **Presentation**: Tu escritorio (lo que todos ven)

---

## 🏛️ FASE 2: ARQUITECTURA - LAS CAPAS

### 🎯 ¿Por qué capas?
**Analogía**: Piensa en un **edificio de apartamentos**:
- Cada piso tiene una función específica
- El piso de abajo sostiene al de arriba
- Si necesitas arreglar la plomería, solo trabajas en el piso correspondiente
- No tienes que destruir todo el edificio

### Paso 3: Crear las Entidades

**¿Qué es una Entidad?**
Una entidad es como un **molde para hacer galletas**. Nos dice exactamente cómo debe "verse" cada película en nuestro sistema.

**Ejemplo actualizado de Movie.cs:**

```csharp
using System.ComponentModel.DataAnnotations;

namespace CarteleraApi.Core.Entities
{
    /// <summary>
    /// Esto es como una "plantilla" que describe cómo debe ser cada película
    /// </summary>
    public class Movie
    {
        /// <summary>
        /// Es como el "número de identificación" de cada película
        /// (Como tu cédula, pero para películas)
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// El nombre de la película
        /// </summary>
        [Required(ErrorMessage = "¡Oye! Una película DEBE tener título")]
        [StringLength(200, ErrorMessage = "El título es muy largo (máximo 200 letras)")]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// De qué trata la película
        /// </summary>
        [StringLength(1000, ErrorMessage = "La descripción es muy larga (máximo 1000 letras)")]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// En qué año salió la película
        /// </summary>
        [Range(1900, 2030, ErrorMessage = "El año debe ser entre 1900 y 2030")]
        public int Year { get; set; }

        /// <summary>
        /// Cuántos minutos dura la película
        /// </summary>
        [Range(1, 500, ErrorMessage = "La duración debe ser entre 1 y 500 minutos")]
        public int? Duration { get; set; }

        /// <summary>
        /// Qué tipo de película es (Terror, Comedia, etc.)
        /// </summary>
        [StringLength(100, ErrorMessage = "El género no puede ser muy largo")]
        public string? Genre { get; set; }
    }
}
```

**¿Qué significan esas cosas raras con corchetes [ ]?**
Son como **reglas de la casa**:
- `[Required]`: "Esta información es OBLIGATORIA"
- `[StringLength(200)]`: "No puedes escribir más de 200 caracteres"
- `[Range(1900, 2030)]`: "El número debe estar entre 1900 y 2030"

**Analogía**: Es como las reglas para entrar a una discoteca:
- Debes tener identificación (Required)
- Debes ser mayor de edad (Range)
- Tu nombre no puede tener más de X caracteres en la lista

### Paso 4: Crear los DTOs

**¿Qué es un DTO?**
**Analogía**: Los DTOs son como **diferentes formularios** para la misma información.

Imagina que quieres pedir una pizza:
- **Formulario para PEDIR** pizza: Solo necesitas decir qué quieres (sin número de orden)
- **Formulario de CONFIRMACIÓN**: Te dan el número de orden y todos los detalles
- **Formulario para MODIFICAR**: Puedes cambiar algunos ingredientes

**MovieCreateDto.cs** (Para crear películas):
```csharp
/// <summary>
/// Formulario para CREAR una nueva película
/// (No necesita ID porque el sistema lo asigna automáticamente)
/// </summary>
public class MovieCreateDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Year { get; set; }
    public int? Duration { get; set; }
    public string? Genre { get; set; }
}
```

**MovieResponseDto.cs** (Para mostrar películas):
```csharp
/// <summary>
/// Formulario de RESPUESTA (incluye el ID que asignó el sistema)
/// </summary>
public class MovieResponseDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Year { get; set; }
    public int? Duration { get; set; }
    public string? Genre { get; set; }
}
```

### Paso 5: Crear las Interfaces

**¿Qué es una Interfaz?**
**Analogía**: Una interfaz es como un **contrato de trabajo**.

Imagina que contratas a un jardinero. El contrato dice:
- "DEBES cortar el césped"
- "DEBES regar las plantas"  
- "DEBES podar los arbustos"

No importa QUÉ jardinero contrates, todos DEBEN cumplir estas tareas.

**IMovieRepository.cs:**
```csharp
/// <summary>
/// "Contrato" que dice qué tareas DEBE hacer cualquier repositorio de películas
/// </summary>
public interface IMovieRepository
{
    // "Debes poder traer TODAS las películas"
    Task<List<Movie>> GetAllAsync();
    
    // "Debes poder traer UNA película por su ID"
    Task<Movie?> GetByIdAsync(int id);
    
    // "Debes poder CREAR una nueva película"
    Task<Movie> CreateAsync(Movie movie);
    
    // "Debes poder ACTUALIZAR una película"
    Task<Movie> UpdateAsync(Movie movie);
    
    // "Debes poder ELIMINAR una película"
    Task<bool> DeleteAsync(int id);
    
    // "Debes poder buscar películas por género"
    Task<List<Movie>> GetByGenreAsync(string genre);
}
```

---

## 🗄️ FASE 3: ACCESO A DATOS

### 🎯 ¿Qué hacemos aquí?
Construimos las "tuberías" que conectan nuestra aplicación con la base de datos.

### Paso 6: El Contexto de Base de Datos

**¿Qué es un DbContext?**
**Analogía**: El DbContext es como el **gerente de un banco**.

- Sabe dónde está cada cuenta (tabla)
- Puede depositar dinero (insertar datos)
- Puede retirar dinero (consultar datos)
- Puede transferir entre cuentas (relaciones)
- Tiene las llaves de la bóveda (conexión a la DB)

**MovieDbContext.cs:**
```csharp
/// <summary>
/// El "gerente" que maneja toda la comunicación con la base de datos
/// </summary>
public class MovieDbContext : DbContext
{
    // Constructor: Como darle las llaves del banco al gerente
    public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options) 
    { 
    }
    
    // Esta es nuestra "caja fuerte" donde guardamos todas las películas
    public DbSet<Movie> Movies { get; set; }
    
    /// <summary>
    /// Aquí definimos las "reglas del banco" (cómo se organizan las tablas)
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>(entity =>
        {
            // "La llave principal de cada película es su Id"
            entity.HasKey(e => e.Id);
            
            // "El título es obligatorio y máximo 200 caracteres"
            entity.Property(e => e.Title)
                  .IsRequired()
                  .HasMaxLength(200);
            
            // "El género máximo 100 caracteres"
            entity.Property(e => e.Genre)
                  .HasMaxLength(100);
            
            // "La descripción máximo 1000 caracteres"
            entity.Property(e => e.Description)
                  .HasMaxLength(1000);
        });
    }
}
```

### Paso 7: Implementar los Repositorios

**¿Qué es un Repositorio?**
**Analogía**: El repositorio es como un **bibliotecario especializado**.

- Sabe exactamente dónde están todos los libros (películas)
- Puede buscar libros específicos súper rápido
- Puede añadir nuevos libros al catálogo
- Puede quitar libros que ya no sirven
- Siempre mantiene todo organizado

**MovieRepository.cs:**
```csharp
/// <summary>
/// El "bibliotecario especializado en películas"
/// </summary>
public class MovieRepository : IMovieRepository
{
    private readonly MovieDbContext _context;

    // El bibliotecario necesita acceso a la biblioteca (contexto)
    public MovieRepository(MovieDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// "Dame TODAS las películas que tienes"
    /// </summary>
    public async Task<List<Movie>> GetAllAsync()
    {
        return await _context.Movies.ToListAsync();
    }

    /// <summary>
    /// "Dame la película con este ID específico"
    /// </summary>
    public async Task<Movie?> GetByIdAsync(int id)
    {
        return await _context.Movies.FindAsync(id);
    }

    /// <summary>
    /// "Añade esta nueva película al catálogo"
    /// </summary>
    public async Task<Movie> CreateAsync(Movie movie)
    {
        _context.Movies.Add(movie);
        await _context.SaveChangesAsync();
        return movie;
    }

    /// <summary>
    /// "Actualiza la información de esta película"
    /// </summary>
    public async Task<Movie> UpdateAsync(Movie movie)
    {
        _context.Movies.Update(movie);
        await _context.SaveChangesAsync();
        return movie;
    }

    /// <summary>
    /// "Elimina esta película del catálogo"
    /// </summary>
    public async Task<bool> DeleteAsync(int id)
    {
        var movie = await GetByIdAsync(id);
        if (movie == null) return false;

        _context.Movies.Remove(movie);
        await _context.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// "Dame todas las películas de este género"
    /// </summary>
    public async Task<List<Movie>> GetByGenreAsync(string genre)
    {
        return await _context.Movies
            .Where(m => m.Genre == genre)
            .ToListAsync();
    }
}
```

---

## 🔧 FASE 4: LÓGICA DE NEGOCIO

### 🎯 ¿Qué es la Lógica de Negocio?
**Analogía**: Es como el **chef de un restaurante**.

El mesero (controlador) toma tu pedido, pero el chef:
- Decide si los ingredientes están frescos
- Aplica las recetas secretas del restaurante  
- Se asegura de que la comida esté perfecta
- Puede rechazar hacer un plato si algo está mal

### Paso 8: Crear los Servicios

**MovieService.cs:**
```csharp
/// <summary>
/// El "chef especializado en películas" - aplica todas las reglas del negocio
/// </summary>
public class MovieService
{
    private readonly IMovieRepository _movieRepository;

    public MovieService(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    /// <summary>
    /// "Prepárame el menú completo de películas"
    /// </summary>
    public async Task<List<MovieResponseDto>> GetAllMoviesAsync()
    {
        var movies = await _movieRepository.GetAllAsync();
        
        // Convertimos las "películas crudas" en "películas presentables"
        return movies.Select(movie => new MovieResponseDto
        {
            Id = movie.Id,
            Title = movie.Title,
            Description = movie.Description,
            Year = movie.Year,
            Duration = movie.Duration,
            Genre = movie.Genre
        }).ToList();
    }

    /// <summary>
    /// "Créame una nueva película, pero revisa que todo esté bien"
    /// </summary>
    public async Task<MovieResponseDto> CreateMovieAsync(MovieCreateDto createDto)
    {
        // Reglas del chef (validaciones de negocio):
        
        // "No acepto películas sin título"
        if (string.IsNullOrWhiteSpace(createDto.Title))
            throw new ArgumentException("Una película debe tener título");

        // "No acepto años de película ridículos"
        if (createDto.Year < 1900 || createDto.Year > 2030)
            throw new ArgumentException("El año debe estar entre 1900 y 2030");

        // "Convertir el pedido del cliente en una película real"
        var movie = new Movie
        {
            Title = createDto.Title.Trim(), // Limpiamos espacios extra
            Description = createDto.Description?.Trim() ?? string.Empty,
            Year = createDto.Year,
            Duration = createDto.Duration,
            Genre = createDto.Genre?.Trim()
        };

        // "Darle la película al bibliotecario para que la guarde"
        var savedMovie = await _movieRepository.CreateAsync(movie);

        // "Devolver la película en formato presentable"
        return new MovieResponseDto
        {
            Id = savedMovie.Id,
            Title = savedMovie.Title,
            Description = savedMovie.Description,
            Year = savedMovie.Year,
            Duration = savedMovie.Duration,
            Genre = savedMovie.Genre
        };
    }
}
```

---

## 🎮 FASE 5: CONTROLADORES Y API

### 🎯 ¿Qué es un Controlador?
**Analogía**: El controlador es como el **recepcionista de un hotel**.

- Recibe a todos los visitantes (peticiones HTTP)
- Entiende qué quiere cada visitante
- Los dirige a la persona correcta (servicio)
- Les da la respuesta en un formato que entiendan

### Paso 9: Crear los Controladores

**MoviesController.cs:**
```csharp
/// <summary>
/// El "recepcionista especializado en películas"
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class MoviesController : ControllerBase
{
    private readonly MovieService _movieService;

    public MoviesController(MovieService movieService)
    {
        _movieService = movieService;
    }

    /// <summary>
    /// GET /api/movies - "Dame todas las películas"
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<List<MovieResponseDto>>> GetMovies()
    {
        try
        {
            var movies = await _movieService.GetAllMoviesAsync();
            
            // "Aquí tienes todas las películas, señor"
            return Ok(movies);
        }
        catch (Exception ex)
        {
            // "Disculpe, hubo un problema en la cocina"
            return StatusCode(500, "Error interno del servidor");
        }
    }

    /// <summary>
    /// GET /api/movies/5 - "Dame la película con ID 5"
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<MovieResponseDto>> GetMovie(int id)
    {
        try
        {
            var movie = await _movieService.GetMovieByIdAsync(id);
            
            if (movie == null)
                return NotFound($"No encontré la película con ID {id}");

            return Ok(movie);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Error interno del servidor");
        }
    }

    /// <summary>
    /// POST /api/movies - "Crea una nueva película"
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<MovieResponseDto>> CreateMovie(MovieCreateDto createDto)
    {
        try
        {
            var movie = await _movieService.CreateMovieAsync(createDto);
            
            // "Película creada exitosamente, aquí están los detalles"
            return CreatedAtAction(
                nameof(GetMovie), 
                new { id = movie.Id }, 
                movie
            );
        }
        catch (ArgumentException ex)
        {
            // "Disculpe, pero hay algo mal con su solicitud"
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Error interno del servidor");
        }
    }
}
```

---

## ⚙️ FASE 6: CONFIGURACIÓN

### 🎯 ¿Qué es la Configuración?
**Analogía**: Es como **conectar todos los electrodomésticos de tu casa**.

Tienes la nevera, la lavadora, el microondas... pero necesitas:
- Conectarlos a la electricidad
- Decirles dónde está cada cosa
- Configurar cómo trabajarán juntos

### Paso 11: Configurar Program.cs

**Program.cs actualizado:**
```csharp
var builder = WebApplication.CreateBuilder(args);

// "Contratar" todos nuestros empleados (servicios):

// 1. Contratar al gerente de base de datos
builder.Services.AddDbContext<MovieDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Contratar al bibliotecario
builder.Services.AddScoped<IMovieRepository, MovieRepository>();

// 3. Contratar al chef
builder.Services.AddScoped<MovieService>();

// 4. Configurar la recepción (controladores)
builder.Services.AddControllers();

// 5. Configurar la documentación automática (Swagger)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// "Configurar las reglas de operación del hotel":

if (app.Environment.IsDevelopment())
{
    // En desarrollo, mostrar la documentación
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // Solo conexiones seguras
app.UseAuthorization();    // Verificar permisos
app.MapControllers();      // Conectar los controladores

app.Run(); // ¡Abrir el hotel al público!
```

### Paso 12: Configurar appsettings.json

**appsettings.json actualizado:**
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

**¿Qué significa esto?**
- `ConnectionStrings`: "La dirección de nuestra base de datos"
- `Logging`: "Qué tanto detalle queremos en los reportes"
- `AllowedHosts`: "Qué computadoras pueden conectarse a nosotros"

---

## 🚀 FASE 7: CREAR LA BASE DE DATOS

### 🎯 ¿Qué son las Migraciones?
**Analogía**: Las migraciones son como los **planos de construcción** de una casa.

Cuando quieres construir una casa:
1. Haces los planos (crear migración)
2. Los constructores siguen los planos (aplicar migración)  
3. La casa queda construida exactamente como la diseñaste

### Paso 14: Comandos de Migración

```bash
# 1. "Crear los planos de nuestra base de datos"
dotnet ef migrations add InitialCreate

# 2. "Decirle a los constructores que sigan los planos"
dotnet ef database update
```

**¿Qué pasa internamente?**
1. Entity Framework mira nuestras entidades (Movie)
2. Crea automáticamente el código SQL para crear las tablas
3. Ejecuta ese código en nuestra base de datos
4. ¡Voilà! Tenemos nuestras tablas listas

---

## 🧪 FASE 8: PROBAR TODO

### 🎯 ¿Cómo sabemos que funciona?
**Analogía**: Es como **probar tu carro nuevo** antes de viajar.

Vas a verificar:
- ¿Enciende el motor? (¿La API responde?)
- ¿Funcionan los frenos? (¿Las validaciones funcionan?)
- ¿Prende la radio? (¿Swagger funciona?)

### Paso 15: Ejecutar y Probar

```bash
# Encender nuestro "carro" (API)
dotnet run
```

**¿Qué verás?**
- Se abrirá automáticamente Swagger UI en tu navegador
- Verás todos tus endpoints listados
- Podrás hacer pruebas directamente desde la interfaz

**Pruebas que debes hacer:**
1. **GET /api/movies** - "Dame todas las películas" (debería devolver lista vacía al inicio)
2. **POST /api/movies** - "Crea una película nueva" 
3. **GET /api/movies/{id}** - "Dame la película que acabas de crear"

---

## 🎯 RESULTADO FINAL

**¡Felicidades! 🎉** 

Has construido una Web API completa que es como un **sistema completo de gestión de cine digital**.

**Lo que tienes ahora:**
- Un **recepcionista digital** (Controladores) que atiende clientes
- Un **chef experto** (Servicios) que aplica reglas de negocio  
- Un **bibliotecario** (Repositorios) que organiza todo perfectamente
- Un **gerente de banco** (DbContext) que maneja la base de datos
- Un **sistema de seguridad** (Validaciones) que rechaza datos incorrectos

**Capacidades de tu API:**
✅ Crear películas nuevas  
✅ Ver todas las películas  
✅ Buscar películas específicas  
✅ Actualizar información de películas  
✅ Eliminar películas  
✅ Validar que toda la información sea correcta  
✅ Documentación automática con Swagger  

**¿Qué sigue?**
Puedes expandir tu API añadiendo:
- Autenticación (login de usuarios)
- Más entidades (Actores, Directores, Salas)
- Búsquedas avanzadas
- Subida de imágenes
- ¡Y mucho más!

Tu API está lista para ser el corazón digital de cualquier sistema de cartelera de cine. 🎬🚀