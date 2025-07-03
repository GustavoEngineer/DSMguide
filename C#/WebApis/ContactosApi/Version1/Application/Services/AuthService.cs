using ContactosApi.Core.DTOs;
using ContactosApi.Core.Entities;
using ContactosApi.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using ContactosApi.Infrastructure.Data;

namespace ContactosApi.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<AuthResponseDto> RegisterAsync(RegisterDto registerDto)
        {
            if (await _context.Usuarios.AnyAsync(u => u.Correo == registerDto.Correo))
                throw new InvalidOperationException("El correo ya está registrado.");

            var rol = await _context.Roles.FirstOrDefaultAsync(r => r.Nombre == registerDto.Rol) ??
                      await _context.Roles.FirstOrDefaultAsync(r => r.Nombre == "User");

            if (rol == null)
                throw new InvalidOperationException("Rol no válido.");

            var usuario = new Usuario
            {
                Correo = registerDto.Correo,
                ContrasenaHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Contrasena),
                RolId = rol.Id
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return await GenerateAuthResponse(usuario);
        }

        public async Task<AuthResponseDto> LoginAsync(LoginDto loginDto)
        {
            var usuario = await _context.Usuarios.Include(u => u.Rol)
                .FirstOrDefaultAsync(u => u.Correo == loginDto.Correo);
            if (usuario == null || !BCrypt.Net.BCrypt.Verify(loginDto.Contrasena, usuario.ContrasenaHash))
                throw new UnauthorizedAccessException("Credenciales inválidas.");

            return await GenerateAuthResponse(usuario);
        }

        private async Task<AuthResponseDto> GenerateAuthResponse(Usuario usuario)
        {
            var token = GenerateJwtToken(usuario);
            return new AuthResponseDto
            {
                Token = token,
                Id = usuario.Id,
                Correo = usuario.Correo,
                Rol = (await _context.Roles.FindAsync(usuario.RolId))?.Nombre ?? "User"
            };
        }

        private string GenerateJwtToken(Usuario usuario)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.UtcNow.AddMinutes(double.Parse(jwtSettings["ExpiresMinutes"] ?? "60"));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, usuario.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, usuario.Correo),
                new Claim(ClaimTypes.Role, usuario.Rol.Nombre),
                new Claim("id", usuario.Id.ToString()),
                new Claim("correo", usuario.Correo),
                new Claim("rol", usuario.Rol.Nombre)
            };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
} 