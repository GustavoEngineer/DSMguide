using ContactosApi.Core.Entities;

namespace ContactosApi.Core.Interfaces;

public interface IContactoRepository
{
    Task<Contacto> SaveAsync(Contacto contacto);
    Task<IEnumerable<Contacto>> GetAllAsync();
    Task<Contacto?> GetByIdAsync(int id);
    Task<bool> UpdateAsync(Contacto contacto);
    Task<bool> DeleteByIdAsync(int id);
}