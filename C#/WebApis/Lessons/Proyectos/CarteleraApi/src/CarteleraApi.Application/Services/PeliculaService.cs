using CarteleraApi.Application.DTOs;
using CarteleraApi.Application.Interfaces;
using CarteleraApi.Domain.Entities;
using CarteleraApi.Domain.interfaces.IRepositories;

namespace CarteleraApi.Application.Services
{
    public class PeliculaService : IPeliculaService
    {
        private readonly IPeliculaRepository _peliculaRepository;

        public PeliculaService(IPeliculaRepository peliculaRepository)
        {
            _peliculaRepository = peliculaRepository ?? throw new ArgumentNullException(nameof(peliculaRepository));
        }

        public async Task<IEnumerable<PeliculaDto>> ObtenerTodasAsync()
        {
            var peliculas = await _peliculaRepository.ObtenerTodasAsync();
            return peliculas.Select(MapearADto);
        }

        public async Task<PeliculaDto?> ObtenerPorIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor a 0", nameof(id));

            var pelicula = await _peliculaRepository.ObtenerPorIdAsync(id);
            return pelicula != null ? MapearADto(pelicula) : null;
        }

        public async Task<PeliculaDto> CrearAsync(CrearPeliculaDto crearPeliculaDto)
        {
            if (crearPeliculaDto == null)
                throw new ArgumentNullException(nameof(crearPeliculaDto));

            var pelicula = new Pelicula(
                crearPeliculaDto.NombrePelicula,
                crearPeliculaDto.Trama ?? string.Empty,
                crearPeliculaDto.Categoria,
                crearPeliculaDto.AnoEmision,
                crearPeliculaDto.Director,
                crearPeliculaDto.TiempoHoras
            );

            var peliculaCreada = await _peliculaRepository.AgregarAsync(pelicula);
            return MapearADto(peliculaCreada);
        }

        public async Task<PeliculaDto?> ActualizarAsync(ActualizarPeliculaDto actualizarPeliculaDto)
        {
            if (actualizarPeliculaDto == null)
                throw new ArgumentNullException(nameof(actualizarPeliculaDto));

            // Verificar que la película existe
            var peliculaExistente = await _peliculaRepository.ObtenerPorIdAsync(actualizarPeliculaDto.Id);
            if (peliculaExistente == null)
                return null;

            var pelicula = new Pelicula
            {
                Id = actualizarPeliculaDto.Id,
                NombrePelicula = actualizarPeliculaDto.NombrePelicula,
                Trama = actualizarPeliculaDto.Trama ?? string.Empty,
                Categoria = actualizarPeliculaDto.Categoria,
                AnoEmision = actualizarPeliculaDto.AnoEmision,
                Director = actualizarPeliculaDto.Director,
                TiempoHoras = actualizarPeliculaDto.TiempoHoras
            };

            var peliculaActualizada = await _peliculaRepository.ActualizarAsync(pelicula);
            return MapearADto(peliculaActualizada);
        }

        public async Task<bool> EliminarAsync(int id)
        {
            if (id <= 0)
                return false;

            return await _peliculaRepository.EliminarAsync(id);
        }

        public async Task<IEnumerable<PeliculaDto>> BuscarPorNombreAsync(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return Enumerable.Empty<PeliculaDto>();

            var peliculas = await _peliculaRepository.BuscarPorNombreAsync(nombre);
            return peliculas.Select(MapearADto);
        }

        public async Task<IEnumerable<PeliculaDto>> BuscarPorCategoriaAsync(string categoria)
        {
            if (string.IsNullOrWhiteSpace(categoria))
                return Enumerable.Empty<PeliculaDto>();

            var peliculas = await _peliculaRepository.BuscarPorCategoriaAsync(categoria);
            return peliculas.Select(MapearADto);
        }

        public async Task<IEnumerable<PeliculaDto>> BuscarPorAñoAsync(int anoEmision)
        {
            if (anoEmision < 1900 || anoEmision > 2030)
                return Enumerable.Empty<PeliculaDto>();

            var peliculas = await _peliculaRepository.BuscarPorAñoAsync(anoEmision);
            return peliculas.Select(MapearADto);
        }

        public async Task<IEnumerable<PeliculaDto>> BuscarPorDirectorAsync(string director)
        {
            if (string.IsNullOrWhiteSpace(director))
                return Enumerable.Empty<PeliculaDto>();

            var peliculas = await _peliculaRepository.BuscarPorDirectorAssync(director);
            return peliculas.Select(MapearADto);
        }

        public async Task<IEnumerable<PeliculaDto>> ObtenerPaginadoAsync(int numeroPagina, int tamañoPagina)
        {
            if (numeroPagina <= 0)
                numeroPagina = 1;
            if (tamañoPagina <= 0)
                tamañoPagina = 10;
            if (tamañoPagina > 100)
                tamañoPagina = 100;

            var peliculas = await _peliculaRepository.ObtenerPaginadoAsync(numeroPagina, tamañoPagina);
            return peliculas.Select(MapearADto);
        }

        private static PeliculaDto MapearADto(Pelicula pelicula)
        {
            return new PeliculaDto(
                pelicula.Id,
                pelicula.NombrePelicula,
                pelicula.Trama,
                pelicula.Categoria,
                pelicula.AnoEmision,
                pelicula.Director,
                pelicula.TiempoHoras
            );
        }
    }
}