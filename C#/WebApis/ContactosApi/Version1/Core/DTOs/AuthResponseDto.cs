namespace ContactosApi.Core.DTOs
{
    public class AuthResponseDto
    {
        public string Token { get; set; } = string.Empty;
        public int Id { get; set; }
        public string Correo { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;
    }
} 