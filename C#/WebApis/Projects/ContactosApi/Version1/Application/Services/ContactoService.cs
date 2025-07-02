using ContactosApi.Core.DTOs;
using ContactosApi.Core.Entities;
using ContactosApi.Core.Interfaces;

namespace ContactosApi.Application.Services;

public class ContactoService : IContactoService
{
    private readonly IContactoRepository _contactoRepository;

    public ContactoService(IContactoRepository contactoRepository)
    {
        _contactoRepository = contactoRepository;
    }

    public async Task<Contacto> CreateContactoAsync(ContactoDTO contactoDto)
    {
        // Convertir DTO a entidad
        var contacto = new Contacto
        {
            Nombre = contactoDto.Nombre,
            Apellido = contactoDto.Apellido,
            Email = contactoDto.Email,
            Telefono = contactoDto.Telefono
        };

        // Guardar en el repositorio
        return await _contactoRepository.SaveAsync(contacto);
    }

    public async Task<IEnumerable<Contacto>> GetAllContactosAsync()
    {
        return await _contactoRepository.GetAllAsync();
    }

    public async Task<Contacto?> GetContactoByIdAsync(int id)
    {
        return await _contactoRepository.GetByIdAsync(id);
    }

    public async Task<bool> UpdateContactoAsync(int id, ContactoDTO contactoDto)
    {
        // Obtener el contacto existente
        var contactoExistente = await _contactoRepository.GetByIdAsync(id);
        
        if (contactoExistente == null)
            return false;

        // Actualizar propiedades
        contactoExistente.Nombre = contactoDto.Nombre;
        contactoExistente.Apellido = contactoDto.Apellido;
        contactoExistente.Email = contactoDto.Email;
        contactoExistente.Telefono = contactoDto.Telefono;

        // Guardar cambios
        return await _contactoRepository.UpdateAsync(contactoExistente);
    }

    public async Task<bool> DeleteContactoAsync(int id)
    {
        return await _contactoRepository.DeleteByIdAsync(id);
    }
}