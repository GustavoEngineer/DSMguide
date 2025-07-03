using System.ComponentModel.DataAnnotations;

namespace ContactosApi.Core.DTOs
{
    public class ValidatedIdDto
    {
        [Required(ErrorMessage = "El ID es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID debe ser un número positivo mayor a 0")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "El ID solo puede contener números positivos")]
        public int Id { get; set; }
    }
} 