using CarteleraApi.Application.DTOs;
using CarteleraApi.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarteleraApi.API.Controllers
{
    /// <summary>
    /// Controlador para manejar operaciones con películas
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class PeliculasController : ControllerBase
    {
        private readonly IPeliculaService _peliculaService;
        private readonly ILogger<PeliculasController> _logger;

        public PeliculasController(IPeliculaService peliculaService, ILogger<PeliculasController> logger)
        {
            _peliculaService = peliculaService ?? throw new ArgumentNullException(nameof(peliculaService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Obtiene todas las películas
        /// </summary>
        /// <returns>Lista de todas las películas</returns>
        /// <response code="200">Retorna la lista de películas</response>
        /// <response code="500">Error interno del servidor</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PeliculaDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<PeliculaDto>>> ObtenerTodas()
        {
            try
            {
                _logger.LogInformation("Obteniendo todas las películas");
                var peliculas = await _peliculaService.ObtenerTodasAsync();
                return Ok(peliculas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener todas las películas");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        /// <summary>
        /// Obtiene una película por su ID
        /// </summary>
        /// <param name="id">ID de la película</param>
        /// <returns>La película encontrada</returns>
        /// <response code="200">Retorna la película encontrada</response>
        /// <response code="400">ID inválido</response>
        /// <response code="404">Película no encontrada</response>
        /// <response code="500">Error interno del servidor</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PeliculaDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PeliculaDto>> ObtenerPorId(int id)
        {
            try
            {
                if (id <= 0)
                {
                    _logger.LogWarning("ID inválido recibido: {Id}", id);
                    return BadRequest("El ID debe ser mayor a 0");
                }

                _logger.LogInformation("Obteniendo película con ID: {Id}", id);
                var pelicula = await _peliculaService.ObtenerPorIdAsync(id);

                if (pelicula == null)
                {
                    _logger.LogWarning("Película con ID {Id} no encontrada", id);
                    return NotFound($"No se encontró la película con ID {id}");
                }

                return Ok(pelicula);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex, "Argumento inválido para ID: {Id}", id);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener película con ID: {Id}", id);
                return StatusCode(500, "Error interno del servidor");
            }
        }

        /// <summary>
        /// Crea una nueva película
        /// </summary>
        /// <param name="crearPeliculaDto">Datos de la nueva película</param>
        /// <returns>La película creada</returns>
        /// <response code="201">Película creada exitosamente</response>
        /// <response code="400">Datos de entrada inválidos</response>
        /// <response code="500">Error interno del servidor</response>
        [HttpPost]
        [ProducesResponseType(typeof(PeliculaDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PeliculaDto>> Crear([FromBody] CrearPeliculaDto crearPeliculaDto)
        {
            try
            {
                if (crearPeliculaDto == null)
                {
                    _logger.LogWarning("Datos nulos recibidos para crear película");
                    return BadRequest("Los datos de la película son requeridos");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogWarning("Modelo inválido para crear película: {@Errors}", ModelState.Values.SelectMany(v => v.Errors));
                    return BadRequest(ModelState);
                }

                _logger.LogInformation("Creando nueva película: {Nombre}", crearPeliculaDto.NombrePelicula);
                var peliculaCreada = await _peliculaService.CrearAsync(crearPeliculaDto);

                _logger.LogInformation("Película creada exitosamente con ID: {Id}", peliculaCreada.Id);
                return CreatedAtAction(
                    nameof(ObtenerPorId),
                    new { id = peliculaCreada.Id },
                    peliculaCreada);
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogWarning(ex, "Argumento nulo al crear película");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear película: {Nombre}", crearPeliculaDto?.NombrePelicula);
                return StatusCode(500, "Error interno del servidor");
            }
        }

        /// <summary>
        /// Actualiza una película existente
        /// </summary>
        /// <param name="id">ID de la película a actualizar</param>
        /// <param name="actualizarPeliculaDto">Nuevos datos de la película</param>
        /// <returns>La película actualizada</returns>
        /// <response code="200">Película actualizada exitosamente</response>
        /// <response code="400">Datos de entrada inválidos o ID no coincide</response>
        /// <response code="404">Película no encontrada</response>
        /// <response code="500">Error interno del servidor</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(PeliculaDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PeliculaDto>> Actualizar(int id, [FromBody] ActualizarPeliculaDto actualizarPeliculaDto)
        {
            try
            {
                if (actualizarPeliculaDto == null)
                {
                    _logger.LogWarning("Datos nulos recibidos para actualizar película con ID: {Id}", id);
                    return BadRequest("Los datos de la película son requeridos");
                }

                if (id != actualizarPeliculaDto.Id)
                {
                    _logger.LogWarning("ID de URL ({UrlId}) no coincide con ID del objeto ({DtoId})", id, actualizarPeliculaDto.Id);
                    return BadRequest("El ID de la URL no coincide con el ID del objeto");
                }

                if (id <= 0)
                {
                    _logger.LogWarning("ID inválido recibido para actualizar: {Id}", id);
                    return BadRequest("El ID debe ser mayor a 0");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogWarning("Modelo inválido para actualizar película con ID {Id}: {@Errors}", id, ModelState.Values.SelectMany(v => v.Errors));
                    return BadRequest(ModelState);
                }

                _logger.LogInformation("Actualizando película con ID: {Id}", id);
                var peliculaActualizada = await _peliculaService.ActualizarAsync(actualizarPeliculaDto);

                if (peliculaActualizada == null)
                {
                    _logger.LogWarning("Película con ID {Id} no encontrada para actualizar", id);
                    return NotFound($"No se encontró la película con ID {id}");
                }

                _logger.LogInformation("Película con ID {Id} actualizada exitosamente", id);
                return Ok(peliculaActualizada);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex, "Argumento inválido al actualizar película con ID: {Id}", id);
                return BadRequest(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogWarning(ex, "Argumento nulo al actualizar película con ID: {Id}", id);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar película con ID: {Id}", id);
                return StatusCode(500, "Error interno del servidor");
            }
        }

        /// <summary>
        /// Elimina una película
        /// </summary>
        /// <param name="id">ID de la película a eliminar</param>
        /// <returns>Confirmación de eliminación</returns>
        /// <response code="204">Película eliminada exitosamente</response>
        /// <response code="400">ID inválido</response>
        /// <response code="404">Película no encontrada</response>
        /// <response code="500">Error interno del servidor</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                if (id <= 0)
                {
                    _logger.LogWarning("ID inválido recibido para eliminar: {Id}", id);
                    return BadRequest("El ID debe ser mayor a 0");
                }

                _logger.LogInformation("Eliminando película con ID: {Id}", id);
                var eliminado = await _peliculaService.EliminarAsync(id);

                if (!eliminado)
                {
                    _logger.LogWarning("Película con ID {Id} no encontrada para eliminar", id);
                    return NotFound($"No se encontró la película con ID {id}");
                }

                _logger.LogInformation("Película con ID {Id} eliminada exitosamente", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar película con ID: {Id}", id);
                return StatusCode(500, "Error interno del servidor");
            }
        }

        /// <summary>
        /// Busca películas por nombre
        /// </summary>
        /// <param name="nombre">Texto a buscar en el nombre</param>
        /// <returns>Películas que coinciden con la búsqueda</returns>
        /// <response code="200">Retorna las películas encontradas</response>
        /// <response code="400">Parámetro de búsqueda inválido</response>
        /// <response code="500">Error interno del servidor</response>
        [HttpGet("buscar/nombre/{nombre}")]
        [ProducesResponseType(typeof(IEnumerable<PeliculaDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<PeliculaDto>>> BuscarPorNombre(string nombre)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    _logger.LogWarning("Parámetro de búsqueda por nombre vacío o nulo");
                    return BadRequest("El nombre a buscar no puede estar vacío");
                }

                if (nombre.Length < 2)
                {
                    _logger.LogWarning("Parámetro de búsqueda por nombre muy corto: {Nombre}", nombre);
                    return BadRequest("El nombre a buscar debe tener al menos 2 caracteres");
                }

                _logger.LogInformation("Buscando películas por nombre: {Nombre}", nombre);
                var peliculas = await _peliculaService.BuscarPorNombreAsync(nombre);
                return Ok(peliculas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al buscar películas por nombre: {Nombre}", nombre);
                return StatusCode(500, "Error interno del servidor");
            }
        }

        /// <summary>
        /// Busca películas por categoría
        /// </summary>
        /// <param name="categoria">Categoría a buscar</param>
        /// <returns>Películas de la categoría especificada</returns>
        /// <response code="200">Retorna las películas encontradas</response>
        /// <response code="400">Parámetro de búsqueda inválido</response>
        /// <response code="500">Error interno del servidor</response>
        [HttpGet("buscar/categoria/{categoria}")]
        [ProducesResponseType(typeof(IEnumerable<PeliculaDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<PeliculaDto>>> BuscarPorCategoria(string categoria)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(categoria))
                {
                    _logger.LogWarning("Parámetro de búsqueda por categoría vacío o nulo");
                    return BadRequest("La categoría a buscar no puede estar vacía");
                }

                _logger.LogInformation("Buscando películas por categoría: {Categoria}", categoria);
                var peliculas = await _peliculaService.BuscarPorCategoriaAsync(categoria);
                return Ok(peliculas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al buscar películas por categoría: {Categoria}", categoria);
                return StatusCode(500, "Error interno del servidor");
            }
        }

        /// <summary>
        /// Busca películas por año
        /// </summary>
        /// <param name="año">Año de emisión</param>
        /// <returns>Películas del año especificado</returns>
        /// <response code="200">Retorna las películas encontradas</response>
        /// <response code="400">Año inválido</response>
        /// <response code="500">Error interno del servidor</response>
        [HttpGet("buscar/año/{año}")]
        [ProducesResponseType(typeof(IEnumerable<PeliculaDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<PeliculaDto>>> BuscarPorAño(int año)
        {
            try
            {
                if (año < 1900 || año > 2030)
                {
                    _logger.LogWarning("Año inválido recibido: {Año}", año);
                    return BadRequest("El año debe estar entre 1900 y 2030");
                }

                _logger.LogInformation("Buscando películas por año: {Año}", año);
                var peliculas = await _peliculaService.BuscarPorAñoAsync(año);
                return Ok(peliculas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al buscar películas por año: {Año}", año);
                return StatusCode(500, "Error interno del servidor");
            }
        }

        /// <summary>
        /// Busca películas por director
        /// </summary>
        /// <param name="director">Director a buscar</param>
        /// <returns>Películas del director especificado</returns>
        /// <response code="200">Retorna las películas encontradas</response>
        /// <response code="400">Parámetro de búsqueda inválido</response>
        /// <response code="500">Error interno del servidor</response>
        [HttpGet("buscar/director/{director}")]
        [ProducesResponseType(typeof(IEnumerable<PeliculaDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<PeliculaDto>>> BuscarPorDirector(string director)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(director))
                {
                    _logger.LogWarning("Parámetro de búsqueda por director vacío o nulo");
                    return BadRequest("El director a buscar no puede estar vacío");
                }

                if (director.Length < 2)
                {
                    _logger.LogWarning("Parámetro de búsqueda por director muy corto: {Director}", director);
                    return BadRequest("El director a buscar debe tener al menos 2 caracteres");
                }

                _logger.LogInformation("Buscando películas por director: {Director}", director);
                var peliculas = await _peliculaService.BuscarPorDirectorAsync(director);
                return Ok(peliculas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al buscar películas por director: {Director}", director);
                return StatusCode(500, "Error interno del servidor");
            }
        }

        /// <summary>
        /// Obtiene películas con paginación
        /// </summary>
        /// <param name="pagina">Número de página (por defecto 1)</param>
        /// <param name="tamaño">Tamaño de página (por defecto 10, máximo 100)</param>
        /// <returns>Películas paginadas</returns>
        /// <response code="200">Retorna las películas paginadas</response>
        /// <response code="400">Parámetros de paginación inválidos</response>
        /// <response code="500">Error interno del servidor</response>
        [HttpGet("paginado")]
        [ProducesResponseType(typeof(IEnumerable<PeliculaDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<PeliculaDto>>> ObtenerPaginado(
            [FromQuery] int pagina = 1,
            [FromQuery] int tamaño = 10)
        {
            try
            {
                if (pagina <= 0)
                {
                    _logger.LogWarning("Número de página inválido: {Pagina}", pagina);
                    return BadRequest("El número de página debe ser mayor a 0");
                }

                if (tamaño <= 0)
                {
                    _logger.LogWarning("Tamaño de página inválido: {Tamaño}", tamaño);
                    return BadRequest("El tamaño de página debe ser mayor a 0");
                }

                if (tamaño > 100)
                {
                    _logger.LogWarning("Tamaño de página muy grande: {Tamaño}", tamaño);
                    return BadRequest("El tamaño de página no puede ser mayor a 100");
                }

                _logger.LogInformation("Obteniendo películas paginadas - Página: {Pagina}, Tamaño: {Tamaño}", pagina, tamaño);
                var peliculas = await _peliculaService.ObtenerPaginadoAsync(pagina, tamaño);

                // Agregar información de paginación en headers
                Response.Headers.Append("X-Pagination-CurrentPage", pagina.ToString());
                Response.Headers.Append("X-Pagination-PageSize", tamaño.ToString());

                return Ok(peliculas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener películas paginadas - Página: {Pagina}, Tamaño: {Tamaño}", pagina, tamaño);
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}