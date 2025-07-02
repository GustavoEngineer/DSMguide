using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactosApi.Core.Entities;

// Atributo que mapea esta clase a la tabla "Contactos" en la base de datos
[Table("Contactos")]
public class Contacto
{
    // Clave primaria que se genera automáticamente (auto-incremento)
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    // Validaciones para el nombre:
    // - Required: Campo obligatorio
    // - StringLength: Entre 2 y 50 caracteres
    // - RegularExpression: Solo letras, espacios y acentos
    // - Column: Se mapea a la columna "nombre" en la BD
    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 50 caracteres")]
    [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "El nombre solo puede contener letras y espacios")]
    [Column("nombre", TypeName = "nvarchar(50)")]
    public string Nombre { get; set; } = string.Empty;


    // Validaciones para el apellido (mismas que el nombre)
    [Required(ErrorMessage = "El apellido es obligatorio")]
    [StringLength(50, MinimumLength = 2, 
        ErrorMessage = "El apellido debe tener entre 2 y 50 caracteres")]
    [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", 
        ErrorMessage = "El apellido solo puede contener letras y espacios")]
    [Column("apellido", TypeName = "nvarchar(50)")]
    public string Apellido { get; set; } = string.Empty;


    // Validaciones para el email:
    // - EmailAddress: Valida formato de email (debe contener @, etc.)
    // - StringLength: Máximo 100 caracteres
    [Required(ErrorMessage = "El email es obligatorio")]
    [EmailAddress(ErrorMessage = "El formato del email no es válido")]
    [StringLength(100, ErrorMessage = "El email no puede exceder 100 caracteres")]
    [Column("email", TypeName = "nvarchar(100)")]
    public string Email { get; set; } = string.Empty;


    // Validaciones para el teléfono:
    // - Phone: Valida formato básico de teléfono
    // - RegularExpression: Solo números, espacios, guiones, paréntesis y signo +
    // - NO es Required, por eso es opcional
    [Phone(ErrorMessage = "El formato del teléfono no es válido")]
    [Required(ErrorMessage = "El teléfono es obligatorio")]
    [StringLength(20, ErrorMessage = "El teléfono no puede exceder 20 caracteres")]
    [RegularExpression(@"^[\+]?[0-9\-\(\)\s]+$", ErrorMessage = "El teléfono solo puede contener números, espacios, guiones y paréntesis")]
    [Column("telefono", TypeName = "nvarchar(20)")]
    public string Telefono { get; set; } = string.Empty;

    // Campo para "soft delete" - en lugar de eliminar físicamente,
    // marcamos como inactivo para mantener historial
    [Required]
    [Column("activo")]
    public bool Activo { get; set; } = true;

    // ============ CONSTRUCTORES ============

    // Constructor vacío - necesario para Entity Framework
    // Inicializa valores por defecto
    public Contacto()
    {
        Activo = true;
    }

    // Constructor con los datos esenciales
    // Valida que los parámetros no estén vacíos y los limpia
    // Usa "this(nombre, apellido, email)" para llamar al constructor anterior
    public Contacto(string nombre, string apellido, string email, string telefono)
        : this(nombre, apellido, email)
    {
        // Verifica que el nombre no esté vacío, lo limpia de espacios, o lanza excepción
        Nombre = !string.IsNullOrWhiteSpace(nombre) 
            ? nombre.Trim() 
            : throw new ArgumentException("El nombre no puede estar vacío", nameof(nombre));
            
        // Mismo proceso para apellido
        Apellido = !string.IsNullOrWhiteSpace(apellido) 
            ? apellido.Trim() 
            : throw new ArgumentException("El apellido no puede estar vacío", nameof(apellido));
            
        // Para email, además lo convierte a minúsculas para consistencia
        Email = !string.IsNullOrWhiteSpace(email) 
            ? email.Trim().ToLowerInvariant() 
            : throw new ArgumentException("El email no puede estar vacío", nameof(email));
            
        // El teléfono es opcional, si viene vacío se deja como string.Empty
        Telefono = !string.IsNullOrWhiteSpace(telefono) 
            ? telefono.Trim() 
            : throw new ArgumentException("El teléfono no puede estar vacío", nameof(telefono));
            
        Activo = true;
    }

    // ============ MÉTODOS ÚTILES ============

    // Verifica si el contacto tiene los datos mínimos necesarios
    // Útil para validaciones manuales
    public bool EsValido()
    {
        return  !string.IsNullOrWhiteSpace(Nombre) &&
                !string.IsNullOrWhiteSpace(Apellido) &&
                !string.IsNullOrWhiteSpace(Telefono) &&
                !string.IsNullOrWhiteSpace(Email) &&
               Email.Contains('@'); // Validación básica de email
    }

    // ============ MÉTODOS OVERRIDE ============

    // Define cuándo dos contactos son iguales
    // Se basa en el ID - si tienen el mismo ID, son el mismo contacto
    public override bool Equals(object? obj)
    {
        // Si no es un Contacto, no son iguales
        if (obj is not Contacto otroContacto) return false;
        // Si alguno tiene ID = 0 (no guardado aún), no se pueden comparar
        if (Id == 0 || otroContacto.Id == 0) return false;
        // Son iguales si tienen el mismo ID
        return Id == otroContacto.Id;
    }

    // Genera un código hash basado en el ID
    // Necesario cuando se usan contactos en HashSet, Dictionary, etc.
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}