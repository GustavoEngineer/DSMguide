using ContactosApi.Core.DTOs;
using ContactosApi.Core.Entities;

namespace ContactosApi.Core.Interfaces;

public interface IContactoService
{
    Task<Contacto> SaveAsync(CrearContactoDto dto);
    Task<IEnumerable<Contacto>> GetAllAsync();
    Task<PaginatedResponseDto<ContactoDto>> GetPaginatedAsync(PaginationParamsDto paginationParams);
    Task<Contacto> GetByIdAsync(int id);
    Task<bool> UpdateAsync(int id, CrearContactoDto dto);
    Task<bool> DeleteByIdAsync(int id);
} 