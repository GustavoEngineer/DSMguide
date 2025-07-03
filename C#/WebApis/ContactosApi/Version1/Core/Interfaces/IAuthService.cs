using ContactosApi.Core.DTOs;
using System.Threading.Tasks;

namespace ContactosApi.Core.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDto> RegisterAsync(RegisterDto registerDto);
        Task<AuthResponseDto> LoginAsync(LoginDto loginDto);
    }
} 