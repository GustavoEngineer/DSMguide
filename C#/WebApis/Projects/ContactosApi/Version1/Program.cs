using Microsoft.EntityFrameworkCore;
using ContactosApi.Infrastructure.Data;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar Entity Framework
builder.Services.AddDbContext<ContactosApi.Infrastructure.Data.ApplicationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));

// Configurar inyección de dependencias
builder.Services.AddScoped<ContactosApi.Core.Interfaces.IContactoRepository, ContactosApi.Infrastructure.Repositories.ContactoRepository>();
builder.Services.AddScoped<ContactosApi.Core.Interfaces.IContactoService, ContactosApi.Application.Services.ContactoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Configurar rutas de controladores
app.MapControllers();

app.Run();
