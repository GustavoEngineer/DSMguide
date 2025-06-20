# Guía Paso a Paso: Crear una Web API - Recetario Completo

## Índice
- [📋 Ingredientes Necesarios](#-ingredientes-necesarios)
- [🏗️ FASE 1: PREPARACIÓN DEL PROYECTO](#-fase-1-preparación-del-proyecto)
  - [Paso 1: Crear el Proyecto Base](#paso-1-crear-el-proyecto-base)
  - [Paso 2: Limpiar el Proyecto](#paso-2-limpiar-el-proyecto)
- [🏛️ FASE 2: ARQUITECTURA - CREANDO LAS CAPAS](#-fase-2-arquitectura---creando-las-capas)
  - [Paso 3: Crear la Capa de Entidades (Entities)](#paso-3-crear-la-capa-de-entidades-entities)
  - [Paso 4: Crear la Capa de DTOs (Data Transfer Objects)](#paso-4-crear-la-capa-de-dtos-data-transfer-objects)
  - [Paso 5: Crear las Interfaces (Interfaces)](#paso-5-crear-las-interfaces-interfaces)
- [🗄️ FASE 3: ACCESO A DATOS](#-fase-3-acceso-a-datos)
  - [Paso 6: Configurar el Contexto de Base de Datos](#paso-6-configurar-el-contexto-de-base-de-datos)
  - [Paso 7: Implementar los Repositorios](#paso-7-implementar-los-repositorios)
- [🔧 FASE 4: LÓGICA DE NEGOCIO](#-fase-4-lógica-de-negocio)
  - [Paso 8: Crear los Servicios](#paso-8-crear-los-servicios)
- [🎮 FASE 5: CONTROLADORES Y API](#-fase-5-controladores-y-api)
  - [Paso 9: Crear los Controladores](#paso-9-crear-los-controladores)
  - [Paso 10: Configurar las Respuestas HTTP](#paso-10-configurar-las-respuestas-http)
- [⚙️ FASE 6: CONFIGURACIÓN](#-fase-6-configuración)
  - [Paso 11: Configurar la Inyección de Dependencias](#paso-11-configurar-la-inyección-de-dependencias)
  - [Paso 12: Configurar las Cadenas de Conexión](#paso-12-configurar-las-cadenas-de-conexión)
  - [Paso 13: Configurar Opciones Adicionales](#paso-13-configurar-opciones-adicionales)
- [🚀 FASE 7: MIGRACIÓN Y BASE DE DATOS](#-fase-7-migración-y-base-de-datos)
  - [Paso 14: Crear y Aplicar Migraciones](#paso-14-crear-y-aplicar-migraciones)
- [🧪 FASE 8: PRUEBAS Y VALIDACIÓN](#-fase-8-pruebas-y-validación)
  - [Paso 15: Probar la API](#paso-15-probar-la-api)
  - [Paso 16: Validar la Estructura](#paso-16-validar-la-estructura)
- [🎯 RESULTADO FINAL](#-resultado-final)

---

## 📋 Ingredientes Necesarios
- Visual Studio o Visual Studio Code
- .NET SDK instalado
- Conocimientos básicos de C#
- Base de datos (SQL Server, MySQL, etc.)

---

## 🏗️ FASE 1: PREPARACIÓN DEL PROYECTO

### Paso 1: Crear el Proyecto Base
1. Abre tu IDE preferido
2. Crea un nuevo proyecto de tipo "ASP.NET Core Web API"
3. Nombra tu proyecto (en este caso: CARTELERAAPI)
4. Selecciona la versión de .NET que prefieras
5. Configura las opciones iniciales (HTTPS, autenticación, etc.)

### Paso 2: Limpiar el Proyecto
1. Elimina los archivos de ejemplo que vienen por defecto
2. Mantén solo la estructura básica del proyecto
3. Verifica que tengas los archivos de configuración principales

---

## 🏛️ FASE 2: ARQUITECTURA - CREANDO LAS CAPAS

### Paso 3: Crear la Capa de Entidades (Entities)
**Propósito**: Definir los modelos de datos principales de tu aplicación

1. Crea la carpeta "Entities" en la raíz del proyecto
2. Dentro de esta carpeta, crea tus clases de entidades
3. Define las propiedades principales de cada entidad
4. Establece las relaciones entre entidades (llaves foráneas)
5. Añade validaciones básicas usando Data Annotations

**Ejemplo de entidad**: Movie.cs representará una película con sus propiedades básicas

### Paso 4: Crear la Capa de DTOs (Data Transfer Objects)
**Propósito**: Definir los objetos que se intercambiarán entre cliente y servidor

1. Crea la carpeta "DTOs" dentro de "Core"
2. Por cada entidad, crea sus DTOs correspondientes:
   - DTO para creación (sin ID)
   - DTO para actualización
   - DTO para consulta (puede incluir datos relacionados)
3. Los DTOs deben contener solo la información necesaria para cada operación

### Paso 5: Crear las Interfaces (Interfaces)
**Propósito**: Definir los contratos que implementarán los repositorios

1. Crea la carpeta "Interfaces" dentro de "Core"
2. Define la interfaz del repositorio principal (IMovieRepository.cs)
3. Declara los métodos que necesitarás:
   - Obtener todos los registros
   - Obtener por ID
   - Crear nuevo registro
   - Actualizar registro existente
   - Eliminar registro
   - Métodos de búsqueda específicos

---

## 🗄️ FASE 3: ACCESO A DATOS

### Paso 6: Configurar el Contexto de Base de Datos
**Propósito**: Establecer la conexión y configuración con la base de datos

1. Ve a la carpeta "Data" dentro de "Infrastructure"
2. Crea la clase MovieDbContext.cs
3. Hereda de DbContext
4. Define los DbSet para cada entidad
5. Configura las relaciones entre tablas en OnModelCreating
6. Establece las configuraciones de mapeo necesarias

### Paso 7: Implementar los Repositorios
**Propósito**: Crear las clases que manejarán las operaciones de base de datos

1. Ve a la carpeta "Repositories" dentro de "Infrastructure"
2. Crea la clase MovieRepository.cs
3. Implementa la interfaz IMovieRepository
4. Inyecta el contexto de base de datos
5. Implementa cada método definido en la interfaz
6. Maneja las excepciones y validaciones necesarias

---

## 🔧 FASE 4: LÓGICA DE NEGOCIO

### Paso 8: Crear los Servicios
**Propósito**: Implementar la lógica de negocio de la aplicación

1. Ve a la carpeta "Services" dentro de "Application"
2. Crea la clase MovieService.cs
3. Inyecta el repositorio correspondiente
4. Implementa la lógica de negocio:
   - Validaciones complejas
   - Transformaciones de datos
   - Reglas de negocio específicas
5. Maneja la conversión entre entidades y DTOs

---

## 🎮 FASE 5: CONTROLADORES Y API

### Paso 9: Crear los Controladores
**Propósito**: Exponer los endpoints de la API

1. Ve a la carpeta "Controllers" dentro de "Presentation"
2. Crea MovieController.cs
3. Hereda de ControllerBase
4. Añade el atributo [ApiController]
5. Define la ruta base con [Route("api/[controller]")]
6. Inyecta el servicio correspondiente
7. Crea los métodos para cada endpoint:
   - GET para obtener datos
   - POST para crear
   - PUT para actualizar
   - DELETE para eliminar

### Paso 10: Configurar las Respuestas HTTP
1. Implementa códigos de estado HTTP apropiados
2. Maneja las excepciones con try-catch
3. Retorna respuestas consistentes
4. Documenta cada endpoint con comentarios XML

---

## ⚙️ FASE 6: CONFIGURACIÓN

### Paso 11: Configurar la Inyección de Dependencias
**Propósito**: Registrar todos los servicios en el contenedor DI

1. Ve al archivo Program.cs
2. Registra el contexto de base de datos
3. Registra los repositorios con sus interfaces
4. Registra los servicios de aplicación
5. Configura el tiempo de vida de cada dependencia (Scoped, Transient, Singleton)

### Paso 12: Configurar las Cadenas de Conexión
1. Ve a appsettings.json
2. Añade la sección "ConnectionStrings"
3. Define tu cadena de conexión a la base de datos
4. Crea versiones para diferentes entornos (Development, Production)

### Paso 13: Configurar Opciones Adicionales
1. En appsettings.Development.json configura:
   - Logging levels
   - Configuraciones de desarrollo
2. En launchSettings.json ajusta:
   - Puertos de ejecución
   - Variables de entorno
   - Perfiles de lanzamiento

---

## 🚀 FASE 7: MIGRACIÓN Y BASE DE DATOS

### Paso 14: Crear y Aplicar Migraciones
1. Abre la terminal en la raíz del proyecto
2. Ejecuta el comando para crear migración inicial
3. Revisa los archivos de migración generados
4. Aplica la migración a la base de datos
5. Verifica que las tablas se hayan creado correctamente

---

## 🧪 FASE 8: PRUEBAS Y VALIDACIÓN

### Paso 15: Probar la API
1. Ejecuta el proyecto
2. Abre Swagger UI (se abre automáticamente)
3. Prueba cada endpoint:
   - Verifica que respondan correctamente
   - Prueba con datos válidos e inválidos
   - Confirma los códigos de estado HTTP
4. Usa herramientas como Postman para pruebas más detalladas

### Paso 16: Validar la Estructura
1. Revisa que cada carpeta tenga su propósito específico
2. Confirma que las dependencias fluyan correctamente
3. Verifica que no haya referencias circulares
4. Asegúrate de que la separación de responsabilidades sea clara

---

## 🎯 RESULTADO FINAL

Al seguir esta guía paso a paso, tendrás una Web API completamente funcional con:

- **Arquitectura limpia** separada por responsabilidades
- **Acceso a datos** eficiente y organizado
- **Lógica de negocio** centralizada en servicios
- **API REST** bien estructurada y documentada
- **Configuración** flexible para diferentes entornos
- **Base sólida** para escalar y mantener

¡Tu Web API estará lista para recibir peticiones y gestionar datos de películas (o cualquier entidad que hayas definido)!
