using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContactosApi.Core.Entities
{
    /// <summary>
    /// Representa un rol de usuario (por ejemplo, Admin, Usuario).
    /// </summary>
    public class Rol
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Nombre { get; set; } = string.Empty;

        // Relación con usuarios
        public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }
} 