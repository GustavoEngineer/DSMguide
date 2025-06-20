using CarteleraApi.Domain.Entities;

namespace CarteleraApi.Domain.interfaces.IRepositories
{
    /// <summary>
    /// CONTRATOS
    /// </summary>
    public interface IPeliculaRepository
    {
        /// <summary>
        /// OBTENER TODAS LAS PELÍCULAS
        /// </summary>
        /// <returns>Lista de todas las películas disponibles</returns>
        Task<IEnumerable<Pelicula>> ObtenerTodasAsync();

        /// <summary>
        /// OBTENER PELÍCULA POR ID
        /// </summary>
        /// <param name="id">El identificador único de la película</param>
        /// <returns>La película encontrada o null si no existe</returns>
        Task<Pelicula?> ObtenerPorIdAsync(int id);

        /// <summary>
        /// AGREGAR UNA NUEVA PELÍCULA
        /// </summary>
        /// <param name="pelicula">La película nueva a agregar</param>
        /// <returns>La película agregada con su id asignado</returns>
        Task<Pelicula> AgregarAsync(Pelicula pelicula);

        /// <summary>
        /// ACTUALIZAR UNA PELÍCULA EXISTENTE
        /// </summary>
        /// <param name="pelicula">La película con los datos actualizados</param>
        /// <returns>La película actualizada</returns>
        Task<Pelicula> ActualizarAsync(Pelicula pelicula);

        /// <summary>
        /// ELIMINAR UNA PELÍCULA
        /// </summary>
        /// <param name="id">Eliminar película por su id</param>
        /// <returns>True si se eliminó exitosamente, False si no se encontró</returns>
        Task<bool> EliminarAsync(int id);

        /// <summary>
        /// OBTENER PELÍCULA POR SU NOMBRE
        /// </summary>
        /// <param name="nombre">Parte del nombre a buscar</param>
        /// <returns>Lista de peliculas que coinciden con la bússqueda</returns>
        Task<IEnumerable<Pelicula>> BuscarPorNombreAsync(string nombre);

        /// <summary>
        /// OBTENER PELÍCULA POR SU CATEGORÍA
        /// </summary>
        /// <param name="categoria">Parte del nombre a buscar</param>
        /// <returns>Lista de peliculas que coinciden con la bússqueda</returns>
        Task<IEnumerable<Pelicula>> BuscarPorCategoriaAsync(string categoria);

        /// <summary>
        /// OBTENER PELÍCULA POR SU AÑO DE EMISION
        /// </summary>
        /// <param name="anoEmision">Parte del nombre a buscar</param>
        /// <returns>Lista de peliculas que coinciden con la bússqueda</returns>
        Task<IEnumerable<Pelicula>> BuscarPorAñoAsync(int anoEmision);

        /// <summary>
        /// OBTENER PELÍCULA POR SU DIRECTOR
        /// </summary>
        /// <param name="director">Parte del nombre a buscar</param>
        /// <returns>Lista de peliculas que coinciden con la bússqueda</returns>
        Task<IEnumerable<Pelicula>> BuscarPorDirectorAssync(string director);

        /// <summary>
        /// OBTENER PELÍCULAS CON PAGINACIÓN
        /// </summary>
        /// <param name="numeroPagina">Número de página (empezando en 1)</param>
        /// <param name="tamañoPagina">Cuántas películas por página</param>
        /// <returns>Lista de películas de esa página específica</returns>
        Task<IEnumerable<Pelicula>> ObtenerPaginadoAsync(int numeroPagina, int tamañoPagina);
    }
}