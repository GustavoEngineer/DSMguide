using System.ComponentModel.DataAnnotations;

namespace ContactosApi.Core.Entities
{
    /// <summary>
    /// Representa un usuario del sistema para autenticación y autorización.
    /// </summary>
    public class Usuario
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Correo { get; set; } = string.Empty;

        [Required, MaxLength(255)]
        public string ContrasenaHash { get; set; } = string.Empty;

        // Relación con Rol
        public int RolId { get; set; }
        public Rol Rol { get; set; } = null!;
    }
} 