using ContactosApi.Core.DTOs;
using ContactosApi.Core.Entities;
using ContactosApi.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ContactosApi.Core.Attributes;

namespace ContactosApi.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ContactosController : ControllerBase
{
    private readonly IContactoService _service;

    public ContactosController(IContactoService service)
    {
        _service = service;
    }

    // GET: api/contactos
    [HttpGet]
    [ValidatedPagination]
    public async Task<ActionResult<PaginatedResponseDto<ContactoDto>>> GetContactos(
        [FromQuery] int pagina = 1, 
        [FromQuery] int registrosPorPagina = 10)
    {
        var paginationParams = new PaginationParamsDto
        {
            Pagina = pagina,
            RegistrosPorPagina = registrosPorPagina
        };

        var resultado = await _service.GetPaginatedAsync(paginationParams);
        return Ok(resultado);
    }

    // GET: api/contactos/todos (sin paginación)
    [HttpGet("todos")]
    public async Task<ActionResult<IEnumerable<ContactoDto>>> GetAllContactos()
    {
        var contactos = await _service.GetAllAsync();
        var dtos = contactos.Select(c => new ContactoDto
        {
            Id = c.Id,
            Nombre = c.Nombre,
            Apellido = c.Apellido,
            Email = c.Email,
            Telefono = c.Telefono,
            Activo = c.Activo
        });
        return Ok(dtos);
    }

    // GET: api/contactos/5
    [HttpGet("{id}")]
    [ValidatedId]
    public async Task<ActionResult<ContactoDto>> GetContacto(int id)
    {
        var contacto = await _service.GetByIdAsync(id);
        var dto = new ContactoDto
        {
            Id = contacto.Id,
            Nombre = contacto.Nombre,
            Apellido = contacto.Apellido,
            Email = contacto.Email,
            Telefono = contacto.Telefono,
            Activo = contacto.Activo
        };
        return Ok(dto);
    }

    // POST: api/contactos
    [HttpPost]
    public async Task<ActionResult<ContactoDto>> CreateContacto(CrearContactoDto dto)
    {
        var result = await _service.SaveAsync(dto);
        var response = new ContactoDto
        {
            Id = result.Id,
            Nombre = result.Nombre,
            Apellido = result.Apellido,
            Email = result.Email,
            Telefono = result.Telefono,
            Activo = result.Activo
        };
        return CreatedAtAction(nameof(GetContacto), new { id = response.Id }, response);
    }

    // PUT: api/contactos/5
    [HttpPut("{id}")]
    [ValidatedId]
    public async Task<IActionResult> UpdateContacto(int id, CrearContactoDto dto)
    {
        await _service.UpdateAsync(id, dto);
        return NoContent();
    }

    // DELETE: api/contactos/5
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    [ValidatedId]
    public async Task<IActionResult> DeleteContacto(int id)
    {
        await _service.DeleteByIdAsync(id);
        return NoContent();
    }
} 