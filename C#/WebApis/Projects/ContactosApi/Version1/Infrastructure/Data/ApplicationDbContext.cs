using Microsoft.EntityFrameworkCore;
using ContactosApi.Core.Entities;

namespace ContactosApi.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<Contacto> Contactos { get; set; }
}