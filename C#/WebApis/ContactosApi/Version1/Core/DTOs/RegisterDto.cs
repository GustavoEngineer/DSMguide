namespace ContactosApi.Core.DTOs
{
    public class RegisterDto
    {
        public string Correo { get; set; } = string.Empty;
        public string Contrasena { get; set; } = string.Empty;
        public string Rol { get; set; } = "User"; // Por defecto "User"
    }
} 