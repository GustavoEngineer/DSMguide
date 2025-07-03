using ContactosApi.Core.Entities;
using ContactosApi.Core.Interfaces;
using ContactosApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ContactosApi.Infrastructure.Repositories;

public class ContactoRepository : IContactoRepository
{
    private readonly ApplicationDbContext _context;

    public ContactoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Contacto> SaveAsync(Contacto contacto)
    {
        _context.Contactos.Add(contacto);
        await _context.SaveChangesAsync();
        return contacto;
    }

    public async Task<IEnumerable<Contacto>> GetAllAsync()
    {
        return await _context.Contactos.Where(c => c.Activo).ToListAsync();
    }

    public async Task<Contacto?> GetByIdAsync(int id)
    {
        return await _context.Contactos.FirstOrDefaultAsync(c => c.Id == id && c.Activo);
    }

    public async Task<bool> UpdateAsync(Contacto contacto)
    {
        _context.Contactos.Update(contacto);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> DeleteByIdAsync(int id)
    {
        var contacto = await _context.Contactos.FindAsync(id);
        if (contacto == null)
            return false;

        contacto.Activo = false;
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }
} 