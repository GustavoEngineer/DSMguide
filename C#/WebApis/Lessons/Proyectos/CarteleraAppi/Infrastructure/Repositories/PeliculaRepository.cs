using CarteleraApi.Domain.Entities;
using CarteleraApi.Domain.interfaces.IRepositories;
using CarteleraApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CarteleraApi.Infrastructure.Repositories
{
    /// <summary>
    /// Implementación del repositorio de películas usando Entity Framework
    /// </summary>
    public class PeliculaRepository : IPeliculaRepository
    {
        private readonly ApplicationDbContext _context;

        public PeliculaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pelicula>> ObtenerTodasAsync()
        {
            return await _context.Peliculas
                .OrderBy(p => p.NombrePelicula)
                .ToListAsync();
        }

        public async Task<Pelicula?> ObtenerPorIdAsync(int id)
        {
            return await _context.Peliculas
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Pelicula> AgregarAsync(Pelicula pelicula)
        {
            _context.Peliculas.Add(pelicula);
            await _context.SaveChangesAsync();
            return pelicula;
        }

        public async Task<Pelicula> ActualizarAsync(Pelicula pelicula)
        {
            _context.Entry(pelicula).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return pelicula;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var pelicula = await _context.Peliculas.FindAsync(id);
            if (pelicula == null)
                return false;

            _context.Peliculas.Remove(pelicula);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Pelicula>> BuscarPorNombreAsync(string nombre)
        {
            return await _context.Peliculas
                .Where(p => p.NombrePelicula.Contains(nombre))
                .OrderBy(p => p.NombrePelicula)
                .ToListAsync();
        }

        public async Task<IEnumerable<Pelicula>> BuscarPorCategoriaAsync(string categoria)
        {
            return await _context.Peliculas
                .Where(p => p.Categoria.Contains(categoria))
                .OrderBy(p => p.NombrePelicula)
                .ToListAsync();
        }

        public async Task<IEnumerable<Pelicula>> BuscarPorAñoAsync(int anioEmision)
        {
            return await _context.Peliculas
                .Where(p => p.AnoEmision == anioEmision)
                .OrderBy(p => p.NombrePelicula)
                .ToListAsync();
        }

        public async Task<IEnumerable<Pelicula>> BuscarPorDirectorAssync(string director)
        {
            return await _context.Peliculas
                .Where(p => p.Director.Contains(director))
                .OrderBy(p => p.NombrePelicula)
                .ToListAsync();
        }

        public async Task<IEnumerable<Pelicula>> ObtenerPaginadoAsync(int numeroPagina, int tamañoPagina)
        {
            return await _context.Peliculas
                .OrderBy(p => p.NombrePelicula)
                .Skip((numeroPagina - 1) * tamañoPagina)
                .Take(tamañoPagina)
                .ToListAsync();
        }
    }
}