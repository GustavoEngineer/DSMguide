# Guía Súper Fácil: API para Saber si una Palabra es Palíndroma en .NET

## Requisitos previos
- Tener instalado [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) o superior
- Tener instalado MySQL Server (o acceso a una base de datos MySQL)
- Un editor de código (por ejemplo, [Visual Studio Code](https://code.visualstudio.com/))
- Ganas de aprender

## Índice
1. [¿Qué es una WebAPI y qué es un palíndromo?](#que-es-una-webapi-y-qué-es-un-palíndromo)
2. [Crear la base de datos](#crear-la-base-de-datos)
3. [Crear el espacio de trabajo](#crear-el-espacio-de-trabajo)
4. [Instalar los paquetes NuGet necesarios](#instalar-los-paquetes-nuget-necesarios)
5. [Estructura del proyecto y explicación](#estructura-del-proyecto-y-explicacion)
6. [Crear las carpetas](#crear-las-carpetas)

---

## 1. ¿Qué es una WebAPI y qué es un palíndromo?
Una **WebAPI** es un programa que permite que diferentes aplicaciones se comuniquen entre sí usando internet. Por ejemplo, una app de celular puede pedirle datos a una WebAPI y la WebAPI le responde.

Un **palíndromo** es una palabra o frase que se lee igual de izquierda a derecha que de derecha a izquierda. Ejemplo: "reconocer", "anilina".

---

## 2. Crear la base de datos
Antes de programar, crea una base de datos en MySQL (puedes usar phpMyAdmin, DBeaver, consola, etc). Por ejemplo:

```sql
CREATE DATABASE palindromosdb;
```

---

## 3. Crear el espacio de trabajo
El espacio de trabajo es la carpeta donde estará todo tu proyecto. Puedes crearla así:

```bash
mkdir PalindromosApi
cd PalindromosApi
```

Luego, crea el proyecto base:

```bash
dotnet new webapi -n PalindromosApi
cd PalindromosApi
```

---

## 4. Instalar los paquetes NuGet necesarios
Instala estos paquetes para que todo funcione (todas las versiones son compatibles con .NET 9):

```bash
# Entity Framework Core y herramientas para MySQL
dotnet add package Microsoft.EntityFrameworkCore --version 9.0.6
dotnet add package Pomelo.EntityFrameworkCore.MySql --version 9.0.0-preview.3.efcore.9.0.0
dotnet add package Microsoft.EntityFrameworkCore.Design --version 9.0.6
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 9.0.6

# Swagger/OpenAPI para documentación interactiva
dotnet add package Swashbuckle.AspNetCore --version 7.0.0
dotnet add package Microsoft.AspNetCore.OpenApi --version 9.0.6
```

Verifica que hayas instalado correctamente todos los paquetes

```bash
dotnet list package
```

---

## 5. Estructura del proyecto y explicación
Así debe quedar la estructura de carpetas y archivos:

```
PalindromosApi/
  Application/
    Services/                # Lógica principal (aquí va si es palíndromo)
  Core/
    DTOs/                    # Objetos para transferir datos
    Entities/                # Modelos de la base de datos
    Interfaces/              # Contratos de clases
  Infrastructure/
    Data/                    # Contexto de la base de datos
    Repositories/            # Acceso a datos
  Presentation/
    Controllers/             # Controladores (reciben las peticiones)
  Program.cs                 # Punto de entrada de la app
  appsettings.json           # Configuración de la app
  PalindromosApi.csproj      # Archivo de proyecto de .NET
```

### ¿Para qué sirve cada carpeta y archivo?

- **Application/Services/**: Aquí va la lógica principal de la app, por ejemplo, la función que verifica si una palabra es palíndroma. Es el "cerebro" de la aplicación.
- **Core/DTOs/**: DTO significa "Data Transfer Object". Son clases simples que solo llevan datos de un lado a otro, por ejemplo, lo que recibes en una petición.
- **Core/Entities/**: Aquí están los modelos que representan las tablas de la base de datos. Cada clase es como un molde de los datos que guardas.
- **Core/Interfaces/**: Son los contratos que dicen qué métodos debe tener una clase. Así puedes cambiar la implementación sin romper el código.
- **Infrastructure/Data/**: Aquí está el contexto de la base de datos, que es la clase que conecta tu app con MySQL usando Entity Framework.
- **Infrastructure/Repositories/**: Aquí van las clases que realmente hablan con la base de datos (guardar, leer, etc.).
- **Presentation/Controllers/**: Los controladores reciben las peticiones HTTP (como POST o GET) y responden. Son la "puerta de entrada" a tu API.
- **Program.cs**: Es el punto de inicio de la app, donde se configura todo y se arranca el servidor.
- **appsettings.json**: Aquí pones configuraciones como la cadena de conexión a la base de datos.
- **PalindromosApi.csproj**: Archivo de proyecto de .NET, donde se listan los paquetes y configuraciones globales.

---

## 6. Crear las carpetas

```bash
mkdir -p Application/Services, Core/DTOs, Core/Entities, Core/Interfaces, Infrastructure/Data, Infrastructure/Repositories, Presentation/Controllers
```

