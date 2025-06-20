using CarteleraApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarteleraApi.Infrastructure.Data
{
    /// <summary>
    /// Contexto de la base de datos - Define las tablas y configuraciones
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // DbSets - Representan las tablas en la base de datos
        public DbSet<Pelicula> Peliculas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de la entidad Pelicula
            modelBuilder.Entity<Pelicula>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(p => p.NombrePelicula)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(p => p.Trama)
                    .HasMaxLength(1000);

                entity.Property(p => p.Categoria)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(p => p.Director)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(p => p.TiempoHoras)
                    .HasPrecision(4, 2); // Permite valores como 99.99
            });

            // Datos de prueba (Seed Data)
            modelBuilder.Entity<Pelicula>().HasData(
                new Pelicula("Avengers: Endgame", "Los Vengadores se enfrentan a Thanos en la batalla final.", "Acción", 2019, "Anthony Russo", 3.01m) { Id = 1 },
                new Pelicula("El Padrino", "La historia de la familia Corleone.", "Drama", 1972, "Francis Ford Coppola", 2.92m) { Id = 2 },
                new Pelicula("Inception", "Un thriller sobre sueños dentro de sueños.", "Ciencia Ficción", 2010, "Christopher Nolan", 2.48m) { Id = 3 }
            );
        }
    }
}
