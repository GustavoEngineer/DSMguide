# Prompt Maestro para Generar una WebAPI en C# (Clean Architecture)

> **Instrucciones:**
> Copia este prompt y pégalo en Cursor o tu IA favorita. Cambia la sección de "PROBLEMÁTICA" por la que te den en el examen. La IA generará todo el proyecto desde cero, siguiendo las mejores prácticas y la estructura profesional que ves en este repositorio.

---

## PROMPT PARA CURSOR/IA

---

### PROBLEMÁTICA

**Describe aquí la problemática o el dominio de la API.**

* Problemática: 
Estoy desarrollando una aplicación web que actualmente funciona con almacenamiento en localStorage, pero necesito llevar esa lógica a un entorno más robusto y escalable mediante una base de datos relacional.

El flujo del usuario incluye autenticación, navegación por módulos de inteligencia artificial, toma de apuntes, participación en retos, seguimiento de progreso, logros, ranking y eventualmente funciones comunitarias. Dado que la aplicación está creciendo y planeo conectarla a una WebAPI en .NET 9 con Swagger, necesito estructurar correctamente la base de datos desde ahora.

Por lo tanto, ya realicé un análisis completo de la app y con base en eso, necesito que definas la estructura de la base de datos: tablas, atributos, tipos de datos y relaciones. A continuación te comparto toda la información organizada por secciones, flujo de datos, estructuras utilizadas y propuesta inicial de tablas:

### 1. Secciones o módulos funcionales de la app

**A. Autenticación y Registro**
- **Pantallas:** Login (inicio de sesión), Registro, Mensajes de bienvenida.
- **Flujo:** El usuario puede iniciar sesión o registrarse. Tras el registro, se le solicita completar su perfil.

**B. Perfil de Usuario**
- **Pantallas:** Formulario de perfil (`profile-form.html`), Modal de perfil en el dashboard.
- **Flujo:** El usuario completa o edita su perfil con nivel de estudios, carrera, objetivos y tiempo de estudio.

**C. Dashboard Principal**
- **Pantallas:** Dashboard (`Dashboard.html`), con navegación lateral (sidebar).
- **Secciones del Dashboard:**
  - **Inicio:** Bienvenida y resumen del usuario.
  - **Cursos/Módulos:** Listado de módulos de IA, progreso, actividades, historial.
  - **Apuntes:** Gestión de notas personales.
  - **Retos:** Retos diarios, con actividades y posibles entregas.
  - **Comunidad:** Foros, ranking, interacción con otros usuarios.
  - **Premium:** Información y gestión de planes premium.
  - **Configuración:** (Placeholder, no funcionalidad detallada aún).

---

### 2. Datos que intervienen en cada parte del flujo

**A. Autenticación y Registro**
- **Login:** email, password.
- **Registro:** name, email, password.
- **Datos guardados:** `userData` en localStorage (name, email, loginTime/registerTime).

**B. Perfil de Usuario**
- **Formulario:** educationLevel, career (si universidad), objectives, studyTime.
- **Datos guardados:** Se agregan a `userData` en localStorage (profileCompleted, profileCompletedAt).

**C. Dashboard**
- **Usuario:** name, email, educationLevel, career, objectives, studyTime.
- **Módulos:** id, icon, title, number, description, objective, content, activity, duration, difficulty, status, progress, timeSpent, score, lastActivity, history.
- **Notas:** Array de notas por usuario (`notes_{email}` en localStorage).
- **Retos:** Array de retos predefinidos (título, descripción, si requiere upload).
- **Ranking:** Datos de usuarios (position, name, email, level, points, modules, achievements, time, avatar, isFriend).
- **Logros:** Derivados del progreso en módulos.

---

### 3. Formularios, componentes, servicios, objetos o estructuras

- **Formularios:** Login, Registro, Perfil, Notas (crear/editar), posiblemente retos (entrega).
- **Componentes:** Sidebar de navegación, cards de módulos, cards de precios, modales (perfil, retos).
- **Estructuras de datos:**
  - `userData` (objeto usuario)
  - `modulesData` (array de módulos)
  - `notes_{email}` (array de notas)
  - `retosPredefinidos` (array de retos)
  - `rankingData` (objetos de ranking global, amigos, universidad, región)

---

### 4. Eventos clave que cambian el estado o generan datos

- **Login/Registro:** Guarda usuario en localStorage, redirige a dashboard o perfil.
- **Completar/editar perfil:** Actualiza `userData`, redirige a dashboard.
- **Navegación:** Cambia la sección visible en el dashboard.
- **Progreso en módulos:** Cambia estado, progreso, historial y logros.
- **Notas:** Crear, editar, eliminar notas (actualiza localStorage).
- **Retos:** Completar retos, subir archivos (no implementado, pero previsto).
- **Ranking:** Cambia según progreso y logros.
- **Premium:** Cambio de plan (no implementado, pero previsto).

---

## Propuesta de tablas y atributos para la base de datos

### 1. Usuarios (`Users`)
| Campo           | Tipo         | Descripción                                 |
|-----------------|--------------|---------------------------------------------|
| Id              | int (PK)     | Identificador único                         |
| Name            | string       | Nombre del usuario                          |
| Email           | string (UK)  | Correo electrónico                          |
| PasswordHash    | string       | Hash de la contraseña                       |
| RegisterTime    | datetime     | Fecha de registro                           |
| LoginTime       | datetime     | Último inicio de sesión                     |
| ProfileCompleted| bool         | Si completó el perfil                       |
| ProfileCompletedAt | datetime  | Fecha de completar perfil                   |

### 2. Perfiles de Usuario (`UserProfiles`)
| Campo           | Tipo         | Descripción                                 |
|-----------------|--------------|---------------------------------------------|
| UserId          | int (FK)     | Relación con Usuarios                       |
| EducationLevel  | string       | Nivel de estudios                           |
| Career          | string/null  | Carrera (si aplica)                         |
| Objectives      | string       | Objetivos de aprendizaje                    |
| StudyTime       | string       | Tiempo disponible para estudio              |

### 3. Módulos de IA (`Modules`)
| Campo           | Tipo         | Descripción                                 |
|-----------------|--------------|---------------------------------------------|
| Id              | int (PK)     | Identificador único                         |
| Icon            | string       | Icono                                       |
| Title           | string       | Título                                      |
| Number          | string       | Número de módulo                            |
| Description     | string       | Descripción                                 |
| Objective       | string       | Objetivo                                    |
| Content         | string       | Contenido                                   |
| Activity        | string       | Actividad principal                         |
| Duration        | string       | Duración estimada                           |
| Difficulty      | string       | Dificultad                                  |

### 4. Progreso de Módulos por Usuario (`UserModules`)
| Campo           | Tipo         | Descripción                                 |
|-----------------|--------------|---------------------------------------------|
| Id              | int (PK)     | Identificador único                         |
| UserId          | int (FK)     | Relación con Usuarios                       |
| ModuleId        | int (FK)     | Relación con Módulos                        |
| Status          | string       | Estado: not-started, in-progress, completed |
| Progress        | int          | Porcentaje completado                       |
| TimeSpent       | float        | Horas invertidas                            |
| Score           | int          | Puntuación                                  |
| LastActivity    | datetime     | Última actividad                            |

### 5. Historial de Actividades en Módulos (`ModuleHistory`)
| Campo           | Tipo         | Descripción                                 |
|-----------------|--------------|---------------------------------------------|
| Id              | int (PK)     | Identificador único                         |
| UserModuleId    | int (FK)     | Relación con UserModules                    |
| Action          | string       | Acción realizada                            |
| Date            | datetime     | Fecha de la acción                          |
| Score           | int          | Puntuación obtenida (si aplica)             |

### 6. Notas de Usuario (`Notes`)
| Campo           | Tipo         | Descripción                                 |
|-----------------|--------------|---------------------------------------------|
| Id              | int (PK)     | Identificador único                         |
| UserId          | int (FK)     | Relación con Usuarios                       |
| Content         | string       | Contenido de la nota                        |
| CreatedAt       | datetime     | Fecha de creación                           |
| UpdatedAt       | datetime     | Fecha de última actualización               |

### 7. Retos Diarios (`Challenges`)
| Campo           | Tipo         | Descripción                                 |
|-----------------|--------------|---------------------------------------------|
| Id              | int (PK)     | Identificador único                         |
| Title           | string       | Título del reto                             |
| Description     | string       | Descripción                                 |
| RequiresUpload  | bool         | Si requiere entrega de archivo              |

### 8. Participación en Retos (`UserChallenges`)
| Campo           | Tipo         | Descripción                                 |
|-----------------|--------------|---------------------------------------------|
| Id              | int (PK)     | Identificador único                         |
| UserId          | int (FK)     | Relación con Usuarios                       |
| ChallengeId     | int (FK)     | Relación con Retos                          |
| Status          | string       | Estado: not-started, in-progress, completed |
| Submission      | string/null  | URL o referencia a entrega                  |
| Score           | int/null     | Puntuación (si aplica)                      |
| CompletedAt     | datetime     | Fecha de finalización                       |

### 9. Ranking y Logros (`Ranking`, `Achievements`)
- **Ranking:** Puede calcularse dinámicamente, pero si se almacena:
  - UserId, Points, Level, ModulesCompleted, TimeSpent, Position, etc.
- **Achievements:** 
  - Id, UserId, Name, Description, DateAwarded

### 10. Comunidad (Foros, Proyectos, etc.) *(Futuro)*
- **Foros:** Topics, Posts, UserId, Fecha, etc.
- **Galería de Proyectos:** ProjectId, UserId, Title, Description, Feedback, etc.

---

## Resumen

- El flujo principal es: **Login/Registro → Completar Perfil → Dashboard (Navegación entre módulos, apuntes, retos, comunidad, premium) → Progreso y logros**.
- Los datos clave giran en torno a **usuarios, perfiles, módulos, progreso, notas, retos, ranking y logros**.
- La estructura propuesta de tablas cubre todos los datos manipulados y visualizados en la app actual, y es extensible para futuras funcionalidades (comunidad, premium, etc.).


---

### REQUISITOS GENERALES

- Usa Entity Framework Core y MySQL ().
- Implementa autenticación JWT (register y login).
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