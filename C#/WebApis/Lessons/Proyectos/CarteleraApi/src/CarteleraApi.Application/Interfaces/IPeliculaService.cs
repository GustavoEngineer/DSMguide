using CarteleraApi.Application.DTOs;

namespace CarteleraApi.Application.Interfaces
{
    public interface IPeliculaService
    {
        Task<IEnumerable<PeliculaDto>> ObtenerTodasAsync();
        Task<PeliculaDto?> ObtenerPorIdAsync(int id);
        Task<PeliculaDto> CrearAsync(CrearPeliculaDto crearPeliculaDto);
        Task<PeliculaDto?> ActualizarAsync(ActualizarPeliculaDto actualizarPeliculaDto); // Cambié el tipo de retorno
        Task<bool> EliminarAsync(int id);
        Task<IEnumerable<PeliculaDto>> BuscarPorNombreAsync(string nombre);
        Task<IEnumerable<PeliculaDto>> BuscarPorCategoriaAsync(string categoria);
        Task<IEnumerable<PeliculaDto>> BuscarPorAñoAsync(int anoEmision);
        Task<IEnumerable<PeliculaDto>> BuscarPorDirectorAsync(string director);
        Task<IEnumerable<PeliculaDto>> ObtenerPaginadoAsync(int numeroPagina, int tamañoPagina);
    }
}