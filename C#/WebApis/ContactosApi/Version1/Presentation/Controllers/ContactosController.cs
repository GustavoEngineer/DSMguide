using ContactosApi.Core.DTOs;
using ContactosApi.Core.Entities;
using ContactosApi.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ContactosApi.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactosController : ControllerBase
{
    private readonly IContactoService _contactoService;

    public ContactosController(IContactoService contactoService)
    {
        _contactoService = contactoService;
    }

    // GET: api/contactos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Contacto>>> GetContactos()
    {
        var contactos = await _contactoService.GetAllContactosAsync();
        return Ok(contactos);
    }

    // GET: api/contactos/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Contacto>> GetContacto(int id)
    {
        var contacto = await _contactoService.GetContactoByIdAsync(id);
        
        if (contacto == null)
            return NotFound();

        return Ok(contacto);
    }

    // POST: api/contactos
    [HttpPost]
    public async Task<ActionResult<Contacto>> CreateContacto(ContactoDTO contactoDto)
    {
        var contacto = await _contactoService.CreateContactoAsync(contactoDto);
        return CreatedAtAction(nameof(GetContacto), new { id = contacto.Id }, contacto);
    }

    // PUT: api/contactos/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateContacto(int id, ContactoDTO contactoDto)
    {
        var result = await _contactoService.UpdateContactoAsync(id, contactoDto);
        
        if (!result)
            return NotFound();

        return NoContent();
    }

    // DELETE: api/contactos/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteContacto(int id)
    {
        var result = await _contactoService.DeleteContactoAsync(id);
        
        if (!result)
            return NotFound();

        return NoContent();
    }
} 