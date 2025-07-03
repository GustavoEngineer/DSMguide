using ContactosApi.Core.DTOs;
using ContactosApi.Core.Entities;
using ContactosApi.Core.Interfaces;

namespace ContactosApi.Application.Services;

public class ContactoService : IContactoService
{
    private readonly IContactoRepository _repository;

    public ContactoService(IContactoRepository repository)
    {
        _repository = repository;
    }

    public async Task<Contacto> SaveAsync(CrearContactoDto dto)
    {
        var existentes = await _repository.GetAllAsync();
        if (existentes.Any(c => c.Email.ToLower() == dto.Email.ToLower()))
            throw new InvalidOperationException("Ya existe un contacto con ese email.");
        if (existentes.Any(c => c.Nombre.ToLower() == dto.Nombre.ToLower() && c.Apellido.ToLower() == dto.Apellido.ToLower()))
            throw new InvalidOperationException("Ya existe un contacto con ese nombre y apellido.");
        
        var contacto = new Contacto
        {
            Nombre = dto.Nombre,
            Apellido = dto.Apellido,
            Email = dto.Email,
            Telefono = dto.Telefono,
            Activo = dto.Activo
        };
        return await _repository.SaveAsync(contacto);
    }

    public async Task<IEnumerable<Contacto>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<PaginatedResponseDto<ContactoDto>> GetPaginatedAsync(PaginationParamsDto paginationParams)
    {
        var todosLosContactos = await _repository.GetAllAsync();
        var totalRegistros = todosLosContactos.Count();
        
        var contactosPaginados = todosLosContactos
            .Skip((paginationParams.Pagina - 1) * paginationParams.RegistrosPorPagina)
            .Take(paginationParams.RegistrosPorPagina)
            .ToList();

        var totalPaginas = (int)Math.Ceiling((double)totalRegistros / paginationParams.RegistrosPorPagina);
        var paginaActual = paginationParams.Pagina;
        var registrosEnPaginaActual = contactosPaginados.Count;

        var respuesta = new PaginatedResponseDto<ContactoDto>
        {
            Data = contactosPaginados.Select(c => new ContactoDto
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Apellido = c.Apellido,
                Email = c.Email,
                Telefono = c.Telefono,
                Activo = c.Activo
            }),
            TotalRegistros = totalRegistros,
            TotalPaginas = totalPaginas,
            PaginaActual = paginaActual,
            RegistrosPorPagina = paginationParams.RegistrosPorPagina,
            RegistrosEnPaginaActual = registrosEnPaginaActual,
            PaginaAnterior = paginaActual > 1 ? paginaActual - 1 : null,
            PaginaSiguiente = paginaActual < totalPaginas ? paginaActual + 1 : null
        };

        return respuesta;
    }

    public async Task<Contacto> GetByIdAsync(int id)
    {
        var contacto = await _repository.GetByIdAsync(id);
        if (contacto == null)
            throw new KeyNotFoundException($"No se encontró un contacto con el ID {id}.");
        return contacto;
    }

    public async Task<bool> UpdateAsync(int id, CrearContactoDto dto)
    {
        var contacto = await _repository.GetByIdAsync(id);
        if (contacto == null)
            throw new KeyNotFoundException($"No se encontró un contacto con el ID {id}.");
        
        contacto.Nombre = dto.Nombre;
        contacto.Apellido = dto.Apellido;
        contacto.Email = dto.Email;
        contacto.Telefono = dto.Telefono;
        contacto.Activo = dto.Activo;
        return await _repository.UpdateAsync(contacto);
    }

    public async Task<bool> DeleteByIdAsync(int id)
    {
        var contacto = await _repository.GetByIdAsync(id);
        if (contacto == null)
            throw new KeyNotFoundException($"No se encontró un contacto con el ID {id}.");
        
        return await _repository.DeleteByIdAsync(id);
    }
}