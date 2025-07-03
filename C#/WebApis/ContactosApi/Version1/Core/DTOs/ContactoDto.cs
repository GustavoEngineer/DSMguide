using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ContactosApi.Core.DTOs;

/// <summary>
/// DTO para crear un contacto (entrada POST/PUT).
/// </summary>
/// <example>
/// {
///   "nombre": "",
///   "apellido": "",
///   "email": "",
///   "telefono": "",
///   "activo": true
/// }
/// </example>
public class CrearContactoDto
{
    /// <summary>Nombre del contacto. Solo letras y espacios simples.</summary>
    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 50 caracteres")]
    [RegularExpression(@"^(?! )[A-Za-záéíóúÁÉÍÓÚñÑ]+( [A-Za-záéíóúÁÉÍÓÚñÑ]+)*$", ErrorMessage = "El nombre solo puede contener letras y espacios simples, sin espacios al inicio/final ni dobles espacios")]
    public string Nombre { get; set; } = string.Empty;

    /// <summary>Apellido del contacto. Solo letras y espacios simples.</summary>
    [Required(ErrorMessage = "El apellido es obligatorio")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "El apellido debe tener entre 2 y 50 caracteres")]
    [RegularExpression(@"^(?! )[A-Za-záéíóúÁÉÍÓÚñÑ]+( [A-Za-záéíóúÁÉÍÓÚñÑ]+)*$", ErrorMessage = "El apellido solo puede contener letras y espacios simples, sin espacios al inicio/final ni dobles espacios")]
    public string Apellido { get; set; } = string.Empty;

    /// <summary>Email del contacto. Sin espacios.</summary>
    [Required(ErrorMessage = "El email es obligatorio")]
    [EmailAddress(ErrorMessage = "El formato del email no es válido")]
    [StringLength(100, ErrorMessage = "El email no puede exceder 100 caracteres")]
    [RegularExpression(@"^[^\s]+$", ErrorMessage = "El email no debe contener espacios")]
    public string Email { get; set; } = string.Empty;

    /// <summary>Teléfono del contacto. Solo números positivos, sin espacios ni símbolos.</summary>
    [Required(ErrorMessage = "El teléfono es obligatorio")]
    [StringLength(20, MinimumLength = 7, ErrorMessage = "El teléfono debe tener entre 7 y 20 dígitos")]
    [RegularExpression(@"^[0-9]+$", ErrorMessage = "El teléfono solo puede contener números positivos, sin espacios ni símbolos")]
    public string Telefono { get; set; } = string.Empty;

    /// <summary>Indica si el contacto está activo.</summary>
    public bool Activo { get; set; } = true;
}

/// <summary>
/// DTO para mostrar un contacto (respuesta GET).
/// </summary>
public class ContactoDto : CrearContactoDto
{
    /// <summary>Id del contacto.</summary>
    public int Id { get; set; }
}