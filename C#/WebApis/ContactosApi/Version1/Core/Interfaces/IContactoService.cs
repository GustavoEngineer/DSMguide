using ContactosApi.Core.DTOs;
using ContactosApi.Core.Entities;

namespace ContactosApi.Core.Interfaces;

public interface IContactoService
{
    Task<Contacto> CreateContactoAsync(ContactoDTO contactoDto);
    Task<IEnumerable<Contacto>> GetAllContactosAsync();
    Task<Contacto?> GetContactoByIdAsync(int id);
    Task<bool> UpdateContactoAsync(int id, ContactoDTO contactoDto);
    Task<bool> DeleteContactoAsync(int id);
} 