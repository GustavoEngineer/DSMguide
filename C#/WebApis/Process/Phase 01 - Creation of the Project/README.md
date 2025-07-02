# Fase 01: Creación y Preparación del Entorno

## 1. Crear el proyecto WebAPI

```bash
mkdir ContactosApi
cd ContactosApi
dotnet new webapi -n ContactosApi
cd ContactosApi
```

## 2. Crear estructura de carpetas

```bash
mkdir -p Application/Services, Core/DTOs, Core/Entities, Core/Interfaces, Infrastructure/Data, Infrastructure/Repositories, Presentation/Controllers
```

## 3. Instalar paquetes necesarios

Ejecuta estos comandos dentro de la carpeta del proyecto (`ContactosApi`):

```bash
dotnet add package Microsoft.AspNetCore.OpenApi --version 9.0.6
```
```bash
dotnet add package Microsoft.EntityFrameworkCore --version 9.0.6
```
```bash
dotnet add package Microsoft.EntityFrameworkCore.Design --version 9.0.6
```
```bash
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 9.0.6
```
```bash
dotnet add package Pomelo.EntityFrameworkCore.MySql --version 9.0.0-preview.3.efcore.9.0.0
```
```bash
dotnet add package Swashbuckle.AspNetCore --version 7.0.0
```

Luego, verifica que todos los paquetes estén correctamente instalados con:

```bash
dotnet list package
```

## 4. Verificar instalación de paquetes

```bash
dotnet list package
```

## 5. Crear archivos base

Crea los siguientes archivos vacíos para dejar listo el entorno:

```bash
type nul > Core/Entities/Contacto.cs
type nul > Core/DTOs/ContactoDto.cs
type nul > Core/Interfaces/IContactoRepository.cs
type nul > Application/Services/ContactoService.cs
type nul > Infrastructure/Data/AppDbContext.cs
type nul > Infrastructure/Repositories/ContactoRepository.cs
```

## 6. Probar que el entorno funciona

```bash
dotnet build
dotnet run
```

Abre en el navegador la URL que indique la consola (por ejemplo, https://localhost:7001/swagger) para comprobar que la API está corriendo.

---

¡Listo! El entorno está preparado para comenzar a desarrollar la WebAPI de Contactos.
