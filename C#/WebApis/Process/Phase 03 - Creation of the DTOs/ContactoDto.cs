using System.ComponentModel.DataAnnotations;

namespace ContactosApi.Core.DTOs;

// ================================
// DTO BASE - Propiedades comunes
// ================================
// Clase base que contiene las propiedades comunes para todos los DTOs de Contacto
public abstract class ContactoBaseDto
{
    // Nombre del contacto - Entre 3 y 50 caracteres, solo letras
    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 50 caracteres")]
    [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", 
        ErrorMessage = "El nombre solo puede contener letras y espacios")]
    public string Nombre { get; set; } = string.Empty;

    // Apellido del contacto - Entre 2 y 50 caracteres, solo letras
    [Required(ErrorMessage = "El apellido es obligatorio")]
    [StringLength(50, MinimumLength = 2, 
        ErrorMessage = "El apellido debe tener entre 2 y 50 caracteres")]
    [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", 
        ErrorMessage = "El apellido solo puede contener letras y espacios")]
    public string Apellido { get; set; } = string.Empty;

    // Email del contacto - Formato válido, máximo 100 caracteres
    [Required(ErrorMessage = "El email es obligatorio")]
    [EmailAddress(ErrorMessage = "El formato del email no es válido")]
    [StringLength(100, ErrorMessage = "El email no puede exceder 100 caracteres")]
    public string Email { get; set; } = string.Empty;

    // Teléfono del contacto - Números, espacios, guiones y paréntesis permitidos
    [Required(ErrorMessage = "El teléfono es obligatorio")]
    [Phone(ErrorMessage = "El formato del teléfono no es válido")]
    [StringLength(20, ErrorMessage = "El teléfono no puede exceder 20 caracteres")]
    [RegularExpression(@"^[\+]?[0-9\-\(\)\s]+$", 
        ErrorMessage = "El teléfono solo puede contener números, espacios, guiones y paréntesis")]
    public string Telefono { get; set; } = string.Empty;
}