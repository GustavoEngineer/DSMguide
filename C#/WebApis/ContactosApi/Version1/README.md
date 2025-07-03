# Prompt Maestro para Generar una WebAPI en C# (Clean Architecture)

> **Instrucciones:**
> Copia este prompt y pégalo en Cursor o tu IA favorita. Cambia la sección de "PROBLEMÁTICA" por la que te den en el examen. La IA generará todo el proyecto desde cero, siguiendo las mejores prácticas y la estructura profesional que ves en este repositorio.

---

## PROMPT PARA CURSOR/IA

---

### PROBLEMÁTICA

**Describe aquí la problemática o el dominio de la API.**

_Ejemplo: "Necesito una WebAPI para gestionar una biblioteca de libros, autores y préstamos, con autenticación de usuarios y roles de administrador y usuario."_

---

### REQUISITOS GENERALES

- Crea una WebAPI en C# (.NET 9+) siguiendo Clean Architecture (carpetas: Core, Application, Infrastructure, Presentation).
- Usa Entity Framework Core y MySQL (Pomelo).
- Implementa autenticación JWT (register, login, refresh token opcional).
- Incluye paginación y filtros en los endpoints de listado.
- Valida atributos de entidades y DTOs (ej: Required, StringLength, Email, etc.).
- Implementa migraciones y comandos para crearlas/aplicarlas.
- Documenta la API con Swagger (OpenAPI).
- Maneja errores globalmente (middleware o filtro).
- Usa DTOs para entrada/salida (no expongas entidades directamente).
- Implementa repositorios y servicios (inyección de dependencias).
- Incluye ejemplos de endpoints RESTful (CRUD completo).
- Incluye roles/claims básicos (ej: admin, user) y restricción de endpoints.
- Provee comandos para instalar todos los paquetes NuGet necesarios.
- Incluye README con instrucciones para correr el proyecto.

---

### ESTRUCTURA DE CARPETAS Y ARCHIVOS

- `/Core` (Entidades, DTOs, Interfaces, Validaciones)
- `/Application` (Servicios, lógica de negocio)
- `/Infrastructure` (Data, Migrations, Repositorios)
- `/Presentation` (Controllers, Middlewares, Filtros)
- `Program.cs`, `appsettings.json`, `README.md`, etc.

---

### PAQUETES NUGET NECESARIOS

- Microsoft.EntityFrameworkCore
- Pomelo.EntityFrameworkCore.MySql
- Microsoft.EntityFrameworkCore.Design
- Microsoft.AspNetCore.Authentication.JwtBearer
- Swashbuckle.AspNetCore
- BCrypt.Net-Next
- System.IdentityModel.Tokens.Jwt

---

### COMANDOS BÁSICOS

```bash
# Crear solución y proyecto
 dotnet new sln -n NOMBRE_SOLUTION
 dotnet new webapi -n NOMBRE_PROYECTO
 dotnet sln add NOMBRE_PROYECTO/NOMBRE_PROYECTO.csproj

# Instalar paquetes
 dotnet add package Microsoft.EntityFrameworkCore
 dotnet add package Pomelo.EntityFrameworkCore.MySql
 dotnet add package Microsoft.EntityFrameworkCore.Design
 dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
 dotnet add package Swashbuckle.AspNetCore
 dotnet add package BCrypt.Net-Next
 dotnet add package System.IdentityModel.Tokens.Jwt

# Crear migraciones y actualizar DB
 dotnet ef migrations add InitialCreate
 dotnet ef database update

# Ejecutar la API
 dotnet run
```

---

### REQUISITOS DE ENDPOINTS Y VALIDACIONES

- Todos los endpoints deben validar los datos de entrada (ej: [Required], [StringLength], [EmailAddress], etc.).
- Los endpoints de creación y actualización deben devolver errores claros si la validación falla.
- Los endpoints de login/register deben devolver JWT y datos del usuario.
- Los endpoints protegidos deben requerir JWT y validar roles/claims.
- Los endpoints de listado deben soportar paginación (page, pageSize) y filtros básicos.
- Los endpoints deben devolver respuestas estándar (200, 201, 400, 401, 403, 404, 500).

---

### AUTENTICACIÓN Y AUTORIZACIÓN

- Implementa endpoints para:
  - Registro de usuario (`/api/auth/register`)
  - Login (`/api/auth/login`)
  - (Opcional) Refresh token
- Usa JWT para proteger endpoints.
- Implementa roles básicos (admin, user) y restricción de endpoints por rol.

---

### PAGINACIÓN Y FILTROS

- Los endpoints de listado deben aceptar parámetros de paginación (`page`, `pageSize`).
- Devuelve la respuesta paginada con total de elementos, total de páginas, página actual, etc.
- Permite filtrar por atributos clave (ej: nombre, email, etc.).

---

### MIGRACIONES Y BASE DE DATOS

- Usa Entity Framework Core para definir entidades y relaciones.
- Crea migraciones para inicializar la base de datos.
- Provee comandos para crear y aplicar migraciones.

---

### SWAGGER Y DOCUMENTACIÓN

- Configura Swagger para documentar todos los endpoints.
- Incluye ejemplos de request/response en la documentación.

---

### MANEJO DE ERRORES

- Implementa un middleware o filtro global para manejar excepciones y devolver errores estándar.

---

### INSTRUCCIONES FINALES

1. Cambia la sección de "PROBLEMÁTICA" por la que te den en el examen.
2. Pega este prompt en Cursor o tu IA favorita.
3. Sigue los pasos y comandos que te genere la IA.
4. Personaliza los modelos, endpoints y validaciones según la problemática.
5. ¡Listo! Tendrás una WebAPI profesional en minutos.

---

> **Tip:** Si tu problemática requiere relaciones entre entidades (uno a muchos, muchos a muchos), pide a la IA que las modele y cree los endpoints correspondientes.

---

¡Éxito en tu examen! 🚀 