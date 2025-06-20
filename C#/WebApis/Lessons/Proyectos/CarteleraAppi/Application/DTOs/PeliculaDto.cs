using System.ComponentModel.DataAnnotations;

namespace CarteleraApi.Application.DTOs
{
    public record PeliculaDto
    (
        int Id,
        string NombrePelicula,
        string Trama,
        string Categoria,
        int AnoEmision,
        string Director,
        decimal TiempoHoras
    );

    public record CrearPeliculaDto(
        [Required(ErrorMessage = "El nombre de la película es obligatorio")]
        [StringLength(200, ErrorMessage = "El nombre no puede exceder 200 caracteres")]
        string NombrePelicula,

        [StringLength(1000, ErrorMessage = "La trama no puede exceder 1000 caracteres")]
        string Trama,

        [Required(ErrorMessage = "La categoría es obligatoria")]
        [StringLength(50, ErrorMessage = "La categoría no puede exceder 50 caracteres")]
        string Categoria,

        [Range(1900, 2030, ErrorMessage = "El año debe estar entre 1900 y 2030")]
        int AnoEmision,

        [Required(ErrorMessage = "El director es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre del director no puede exceder 100 caracteres")]
        string Director,

        [Range(0.1, 10.0, ErrorMessage = "La duración debe estar entre 0.1 y 10.0 horas")]
        decimal TiempoHoras
    );

    public record ActualizarPeliculaDto(
        [Required]
        int Id,

        [Required(ErrorMessage = "El nombre de la película es obligatorio")]
        [StringLength(200, ErrorMessage = "El nombre no puede exceder 200 caracteres")]
        string NombrePelicula,

        [StringLength(1000, ErrorMessage = "La trama no puede exceder 1000 caracteres")]
        string Trama,

        [Required(ErrorMessage = "La categoría es obligatoria")]
        [StringLength(50, ErrorMessage = "La categoría no puede exceder 50 caracteres")]
        string Categoria,

        [Range(1900, 2030, ErrorMessage = "El año debe estar entre 1900 y 2030")]
        int AnoEmision,

        [Required(ErrorMessage = "El director es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre del director no puede exceder 100 caracteres")]
        string Director,

        [Range(0.1, 10.0, ErrorMessage = "La duración debe estar entre 0.1 y 10.0 horas")]
        decimal TiempoHoras
    );
}