using Microsoft.EntityFrameworkCore;
using ContactosApi.Core.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace ContactosApi.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<Contacto> Contactos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Rol> Roles { get; set; }
}

public static class ApplicationDbContextSeed
{
    public static void SeedRoles(this ApplicationDbContext context)
    {
        if (!context.Roles.Any())
        {
            context.Roles.AddRange(
                new Rol { Nombre = "Admin" },
                new Rol { Nombre = "User" }
            );
            context.SaveChanges();
        }
    }

    public static void SeedContactos(this ApplicationDbContext context)
    {
        if (!context.Contactos.Any())
        {
            context.Contactos.AddRange(
                new Contacto
                {
                    Nombre = "Juan",
                    Apellido = "Pérez",
                    Email = "juan.perez@email.com",
                    Telefono = "123456789",
                    Activo = true
                },
                new Contacto
                {
                    Nombre = "María",
                    Apellido = "García",
                    Email = "maria.garcia@email.com",
                    Telefono = "987654321",
                    Activo = true
                },
                new Contacto
                {
                    Nombre = "Carlos",
                    Apellido = "López",
                    Email = "carlos.lopez@email.com",
                    Telefono = "555123456",
                    Activo = true
                },
                new Contacto
                {
                    Nombre = "Ana",
                    Apellido = "Rodríguez",
                    Email = "ana.rodriguez@email.com",
                    Telefono = "777888999",
                    Activo = false
                },
                new Contacto
                {
                    Nombre = "Luis",
                    Apellido = "Martínez",
                    Email = "luis.martinez@email.com",
                    Telefono = "111222333",
                    Activo = true
                },
                new Contacto
                {
                    Nombre = "Carmen",
                    Apellido = "Sánchez",
                    Email = "carmen.sanchez@email.com",
                    Telefono = "444555666",
                    Activo = true
                }
            );
            context.SaveChanges();
        }
    }
}