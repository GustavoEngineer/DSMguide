# 📚 Guía Completa de Bases de Datos
## Conceptos Fundamentales y Formas Normales

> **Autor:** Gustavo Bryan Marrufo Amaro (Universitario) 
> **Fecha:** Junio 2025  
> **Propósito:** Guía de estudio para conceptos fundamentales de bases de datos

---

## 📖 Tabla de Contenidos

1. [🎯 Introducción](#-introducción)
2. [🏗️ Modelos de Base de Datos](#️-modelos-de-base-de-datos)
   - [2.1 Modelo Entidad-Relación (E-R)](#21-modelo-entidad-relación-e-r)
   - [2.2 Modelo Relacional](#22-modelo-relacional)
3. [🔗 Relaciones y Grados](#-relaciones-y-grados)
   - [3.1 Tipos de Relaciones](#31-tipos-de-relaciones)
   - [3.2 Grados de Relaciones](#32-grados-de-relaciones)
4. [📊 Entidades y Atributos](#-entidades-y-atributos)
   - [4.1 Entidades](#41-entidades)
   - [4.2 Atributos](#42-atributos)
5. [🔢 Cardinalidad](#-cardinalidad)
6. [💾 Tipos de Datos](#-tipos-de-datos)
7. [🔑 Claves (Keys)](#-claves-keys)
   - [7.1 Primary Key vs Unique Key](#71-primary-key-vs-unique-key)
8. [📋 Formas Normales (1FN - 5FN)](#-formas-normales-1fn---5fn)
   - [8.1 Primera Forma Normal (1FN)](#81-primera-forma-normal-1fn)
   - [8.2 Segunda Forma Normal (2FN)](#82-segunda-forma-normal-2fn)
   - [8.3 Tercera Forma Normal (3FN)](#83-tercera-forma-normal-3fn)
   - [8.4 Forma Normal Boyce-Codd (FNBC)](#84-forma-normal-boyce-codd-fnbc)
   - [8.5 Cuarta Forma Normal (4FN)](#85-cuarta-forma-normal-4fn)
   - [8.6 Quinta Forma Normal (5FN)](#86-quinta-forma-normal-5fn)
9. [📝 Resumen Rápido](#-resumen-rápido)
10. [🔗 Referencias y Recursos](#-referencias-y-recursos)

---

## 🎯 Introducción

Las bases de datos son sistemas organizados para almacenar, gestionar y recuperar información de manera eficiente. Esta guía cubre los conceptos fundamentales necesarios para el desarrollo de software, utilizando ejemplos del musical Hamilton para facilitar la comprensión.

**¿Por qué es importante?**
- Fundamento del desarrollo de software moderno
- Gestión eficiente de información
- Base para aplicaciones escalables
- Integridad y consistencia de datos

---

## 🏗️ Modelos de Base de Datos

### 2.1 Modelo Entidad-Relación (E-R)

El modelo E-R es una representación conceptual que describe la estructura de una base de datos mediante:

#### **Componentes Principales:**

**🏢 Entidades** (Rectángulos)
- Objetos o conceptos del mundo real
- Ejemplo: `ACTOR`, `PERSONAJE`, `CANCIÓN`

**🔗 Relaciones** (Rombos)
- Asociaciones entre entidades
- Ejemplo: `INTERPRETA`, `CANTA`, `APARECE_EN`

**📋 Atributos** (Óvalos)
- Propiedades de entidades o relaciones
- Ejemplo: `nombre`, `fecha_nacimiento`, `duración`

#### **Ejemplo Diagrama E-R - Musical Hamilton:**

```
[ACTOR] ----< INTERPRETA >---- [PERSONAJE]
  |                               |
nombre                         nombre
fecha_nac                      época_histórica
país                          personalidad

[PERSONAJE] ----< CANTA >---- [CANCIÓN]
                                |
                             título
                             duración
                             acto
```

### 2.2 Modelo Relacional

Implementación práctica del modelo E-R usando tablas (relaciones), filas (tuplas) y columnas (atributos).

#### **Características:**
- **Estructura tabular:** Datos organizados en filas y columnas
- **Integridad referencial:** Relaciones consistentes entre tablas
- **Normalización:** Eliminación de redundancia
- **SQL:** Lenguaje estándar para consultas

#### **Ejemplo - Modelo Relacional:**

```sql
-- Tabla ACTORES
CREATE TABLE ACTORES (
    actor_id INT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    fecha_nacimiento DATE,
    pais_origen VARCHAR(50)
);

-- Tabla PERSONAJES
CREATE TABLE PERSONAJES (
    personaje_id INT PRIMARY KEY,
    nombre_personaje VARCHAR(100) NOT NULL,
    epoca_historica VARCHAR(50),
    actor_id INT,
    FOREIGN KEY (actor_id) REFERENCES ACTORES(actor_id)
);
```

---

## 🔗 Relaciones y Grados

### 3.1 Tipos de Relaciones

#### **1️⃣ Uno a Uno (1:1)**
Una entidad se relaciona con una sola instancia de otra entidad.

**Ejemplo Hamilton:**
- Un `ACTOR` tiene un solo `PERFIL_BIOGRAFICO`
- Un `PERFIL_BIOGRAFICO` pertenece a un solo `ACTOR`

```
ACTOR (1) -------- (1) PERFIL_BIOGRAFICO
Lin-Manuel  ←→  Biografía de Lin-Manuel
```

#### **2️⃣ Uno a Muchos (1:N)**
Una entidad se relaciona con múltiples instancias de otra entidad.

**Ejemplo Hamilton:**
- Un `ACTOR` puede interpretar varios `PERSONAJES`
- Un `PERSONAJE` es interpretado por un solo `ACTOR`

```
ACTOR (1) -------- (N) PERSONAJE
Lin-Manuel  ←→  {Hamilton, John Laurens}
```

#### **3️⃣ Muchos a Muchos (M:N)**
Múltiples entidades se relacionan con múltiples instancias de otra entidad.

**Ejemplo Hamilton:**
- Un `PERSONAJE` puede cantar varias `CANCIONES`
- Una `CANCIÓN` puede ser cantada por varios `PERSONAJES`

```
PERSONAJE (M) -------- (N) CANCIÓN
{Hamilton, Burr}  ←→  {Wait for It, Satisfied}
```

### 3.2 Grados de Relaciones

#### **🔹 Relación Unaria (Grado 1)**
Una entidad se relaciona consigo misma.

**Ejemplo:** `PERSONAJE` tiene una relación "MENTOR_DE" con otro `PERSONAJE`

```
PERSONAJE
    ↓
Washington es mentor de Hamilton
```

#### **🔹 Relación Binaria (Grado 2)**
Dos entidades diferentes se relacionan.

**Ejemplo:** `ACTOR` **INTERPRETA** `PERSONAJE`

#### **🔹 Relación Ternaria (Grado 3)**
Tres entidades se relacionan simultáneamente.

**Ejemplo:** `ACTOR` **INTERPRETA** `PERSONAJE` **EN** `ESCENA`

---

## 📊 Entidades y Atributos

### 4.1 Entidades

#### **Definición:**
Objeto, persona, lugar o concepto del mundo real que puede ser identificado de manera única.

#### **Tipos de Entidades:**

**🏢 Entidad Fuerte**
- Existe independientemente
- Tiene clave primaria propia
- Ejemplo: `ACTOR`, `CANCIÓN`

**🏚️ Entidad Débil**
- Depende de otra entidad para existir
- Su clave primaria incluye la clave de la entidad fuerte
- Ejemplo: `ESCENA` (depende de `ACTO`)

#### **Ejemplos Hamilton:**

```
Entidades Fuertes:
- ACTOR (Lin-Manuel Miranda, Leslie Odom Jr.)
- CANCIÓN (Wait for It, Satisfied)
- INSTRUMENTO (Piano, Guitarra)

Entidades Débiles:
- VERSO (depende de CANCIÓN)
- ENSAYO (depende de OBRA)
```

### 4.2 Atributos

#### **Definición:**
Propiedades o características que describen una entidad.

#### **Tipos de Atributos:**

**🔑 Atributo Clave**
- Identifica únicamente una entidad
- No se repite
- Ejemplo: `actor_id`, `isbn_cancion`

**📝 Atributo Simple**
- Valor único, indivisible
- Ejemplo: `edad`, `duración`, `precio`

**📋 Atributo Compuesto**
- Se puede dividir en sub-atributos
- Ejemplo: `nombre_completo` → {nombre, apellido}

**🔢 Atributo Multivaluado**
- Puede tener múltiples valores
- Ejemplo: `idiomas_que_habla` → {inglés, español, francés}

**💭 Atributo Derivado**
- Se calcula a partir de otros atributos
- Ejemplo: `edad` (calculada desde `fecha_nacimiento`)

#### **Ejemplo Completo - Entidad ACTOR:**

```
ACTOR:
├── actor_id (Clave)
├── nombre_completo (Compuesto)
│   ├── nombre (Simple)
│   └── apellido (Simple)
├── fecha_nacimiento (Simple)
├── edad (Derivado)
├── habilidades (Multivaluado)
│   ├── Canto
│   ├── Actuación
│   └── Composición
└── pais_origen (Simple)
```

---

## 🔢 Cardinalidad

### **Definición:**
Número de instancias de una entidad que pueden asociarse con una instancia de otra entidad.

### **Notaciones:**

#### **Notación (min, max):**
- **(0,1)**: Cero o uno
- **(1,1)**: Exactamente uno
- **(0,N)**: Cero o muchos
- **(1,N)**: Uno o muchos

#### **Ejemplos Hamilton:**

**1. ACTOR - PERSONAJE:**
```
ACTOR (1,N) ----INTERPRETA---- (1,1) PERSONAJE
```
- Un actor puede interpretar varios personajes (1,N)
- Un personaje es interpretado por exactamente un actor (1,1)

**2. PERSONAJE - CANCIÓN:**
```
PERSONAJE (0,N) ----CANTA---- (1,N) CANCIÓN
```
- Un personaje puede cantar varias canciones (0,N)
- Una canción puede ser cantada por varios personajes (1,N)

**3. ACTOR - INSTRUMENTO:**
```
ACTOR (0,N) ----TOCA---- (0,N) INSTRUMENTO
```
- Un actor puede tocar varios instrumentos (0,N)
- Un instrumento puede ser tocado por varios actores (0,N)

### **Restricciones de Cardinalidad:**

```sql
-- Ejemplo: Un actor debe interpretar al menos un personaje
ALTER TABLE PERSONAJES 
ADD CONSTRAINT min_personajes 
CHECK (actor_id IS NOT NULL);

-- Ejemplo: Una canción no puede durar más de 10 minutos
ALTER TABLE CANCIONES 
ADD CONSTRAINT max_duracion 
CHECK (duracion <= '00:10:00');
```

---

## 💾 Tipos de Datos

### **Tipos Numéricos:**

| Tipo | Rango | Uso | Ejemplo Hamilton |
|------|-------|-----|------------------|
| `INT` | -2,147,483,648 a 2,147,483,647 | IDs, conteos | `actor_id`, `año_estreno` |
| `BIGINT` | Rango extendido | IDs grandes | `numero_ticket` |
| `DECIMAL(p,s)` | Precisión fija | Dinero, notas | `precio_boleto DECIMAL(10,2)` |
| `FLOAT` | Punto flotante | Mediciones | `duracion_segundos FLOAT` |

### **Tipos de Texto:**

| Tipo | Características | Uso | Ejemplo Hamilton |
|------|----------------|-----|------------------|
| `CHAR(n)` | Longitud fija | Códigos | `codigo_escena CHAR(5)` |
| `VARCHAR(n)` | Longitud variable | Nombres | `nombre_actor VARCHAR(100)` |
| `TEXT` | Texto largo | Descripciones | `biografia_personaje TEXT` |

### **Tipos de Fecha y Tiempo:**

| Tipo | Formato | Uso | Ejemplo Hamilton |
|------|---------|-----|------------------|
| `DATE` | YYYY-MM-DD | Fechas | `fecha_estreno DATE` |
| `TIME` | HH:MM:SS | Horas | `duracion_cancion TIME` |
| `DATETIME` | YYYY-MM-DD HH:MM:SS | Fecha y hora | `timestamp_ensayo DATETIME` |

### **Tipos Booleanos:**

| Tipo | Valores | Uso | Ejemplo Hamilton |
|------|---------|-----|------------------|
| `BOOLEAN` | TRUE/FALSE | Flags | `es_protagonista BOOLEAN` |

### **Ejemplo Práctico:**

```sql
CREATE TABLE ACTORES (
    actor_id INT PRIMARY KEY,                    -- Numérico entero
    nombre_completo VARCHAR(100) NOT NULL,       -- Texto variable
    fecha_nacimiento DATE,                       -- Fecha
    altura_cm DECIMAL(5,2),                     -- Decimal (999.99)
    es_protagonista BOOLEAN DEFAULT FALSE,       -- Booleano
    biografia TEXT,                             -- Texto largo
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP -- Timestamp
);

CREATE TABLE CANCIONES (
    cancion_id INT PRIMARY KEY,
    titulo VARCHAR(200) NOT NULL,
    duracion TIME,                              -- Tiempo HH:MM:SS
    numero_pista TINYINT,                       -- Entero pequeño (0-255)
    letra TEXT,
    es_solo BOOLEAN DEFAULT FALSE
);
```

---

## 🔑 Claves (Keys)

### 7.1 Primary Key vs Unique Key

#### **PRIMARY KEY (Clave Primaria)**

**Características:**
- ✅ **Único:** No se puede repetir
- ✅ **No nulo:** NUNCA puede estar vacío  
- ✅ **Solo UNA por tabla:** Una tabla solo puede tener UNA primary key
- ✅ **Inmutable:** No debería cambiar una vez creada
- ✅ **Crea índice automático:** Para búsquedas rápidas

**Ejemplo:**
```sql
CREATE TABLE ACTORES (
    actor_id INT PRIMARY KEY,           -- PK: Identificador único
    nombre_completo VARCHAR(100),
    fecha_nacimiento DATE
);
```

#### **UNIQUE KEY (Clave Única)**

**Características:**
- ✅ **Único:** No se puede repetir
- ⚠️ **Puede ser NULL:** Acepta valores vacíos (pero solo uno)
- ✅ **Múltiples por tabla:** Puedes tener varias unique keys
- ✅ **Puede cambiar:** Es modificable
- ✅ **Crea índice automático:** Para búsquedas rápidas

**Ejemplo:**
```sql
CREATE TABLE ACTORES (
    actor_id INT PRIMARY KEY,
    nombre_completo VARCHAR(100) UNIQUE,    -- UK: Nombre único
    email VARCHAR(100) UNIQUE,              -- UK: Email único
    telefono VARCHAR(20) UNIQUE             -- UK: Teléfono único
);
```

#### **Comparación:**

| Característica | PRIMARY KEY | UNIQUE KEY |
|---------------|-------------|------------|
| **Valores únicos** | ✅ Sí | ✅ Sí |
| **Permite NULL** | ❌ NO | ✅ Sí (solo uno) |
| **Cantidad por tabla** | 1️⃣ Solo UNA | 🔢 Múltiples |
| **Propósito** | Identificador principal | Restricción de unicidad |
| **Puede cambiar** | ❌ No recomendado | ✅ Sí |
| **Referencia en FK** | ✅ Sí (común) | ⚠️ Posible (raro) |

#### **Otros Tipos de Claves:**

**🔗 FOREIGN KEY (Clave Foránea)**
```sql
CREATE TABLE PERSONAJES (
    personaje_id INT PRIMARY KEY,
    nombre_personaje VARCHAR(100),
    actor_id INT,
    FOREIGN KEY (actor_id) REFERENCES ACTORES(actor_id)
);
```

**🔑 COMPOSITE KEY (Clave Compuesta)**
```sql
CREATE TABLE ACTOR_CANCION (
    actor_id INT,
    cancion_id INT,
    fecha_interpretacion DATE,
    PRIMARY KEY (actor_id, cancion_id)  -- Clave compuesta
);
```

---

## 📋 Formas Normales (1FN - 5FN)

Las Formas Normales son reglas progresivas para organizar datos y eliminar redundancia. Cada forma normal resuelve un problema específico diferente.

### 8.1 Primera Forma Normal (1FN)

**🎯 Regla:** Cada celda debe contener UN solo valor atómico.

#### **❌ Problema - No cumple 1FN:**
| Actor | Personajes | Canciones |
|-------|------------|-----------|
| Lin-Manuel | Hamilton, John Laurens | Wait for It, Satisfied |
| Leslie | Aaron Burr | Wait for It, Dear Theodosia |

#### **✅ Solución - Cumple 1FN:**
| Actor | Personaje | Cancion |
|-------|-----------|---------|
| Lin-Manuel | Hamilton | Wait for It |
| Lin-Manuel | Hamilton | Satisfied |
| Lin-Manuel | John Laurens | Wait for It |
| Leslie | Aaron Burr | Wait for It |
| Leslie | Aaron Burr | Dear Theodosia |

**💡 Memoria:** "Una cosa por celda"

### 8.2 Segunda Forma Normal (2FN)

**🎯 Regla:** Cumple 1FN + Los atributos no-clave deben depender COMPLETAMENTE de la clave primaria.

#### **❌ Problema - No cumple 2FN:**
Clave primaria: (Actor + Personaje)

| Actor | Personaje | Pais_Actor | Duracion_Actuacion |
|-------|-----------|------------|-------------------|
| Lin-Manuel | Hamilton | Estados Unidos | 2h 30min |
| Lin-Manuel | John Laurens | Estados Unidos | 45min |

**Problema:** `Pais_Actor` solo depende de `Actor`, no de (Actor + Personaje)

#### **✅ Solución - Cumple 2FN:**

**Tabla ACTORES:**
| Actor | Pais_Actor |
|-------|------------|
| Lin-Manuel | Estados Unidos |
| Leslie | Estados Unidos |

**Tabla INTERPRETACIONES:**
| Actor | Personaje | Duracion_Actuacion |
|-------|-----------|-------------------|
| Lin-Manuel | Hamilton | 2h 30min |
| Lin-Manuel | John Laurens | 45min |

**💡 Memoria:** "Todo depende de la clave completa"

### 8.3 Tercera Forma Normal (3FN)

**🎯 Regla:** Cumple 2FN + No debe haber dependencias transitivas (A→B→C).

#### **❌ Problema - No cumple 3FN:**
| Actor | Pais_Actor | Continente_Pais |
|-------|------------|-----------------|
| Lin-Manuel | Estados Unidos | América del Norte |
| Leslie | Estados Unidos | América del Norte |

**Problema:** Actor → Pais_Actor → Continente_Pais (dependencia transitiva)

#### **✅ Solución - Cumple 3FN:**

**Tabla ACTORES:**
| Actor | Pais_Actor |
|-------|------------|
| Lin-Manuel | Estados Unidos |
| Leslie | Estados Unidos |

**Tabla PAISES:**
| Pais | Continente |
|------|------------|
| Estados Unidos | América del Norte |
| Francia | Europa |

**💡 Memoria:** "Rompe las cadenas"

### 8.4 Forma Normal Boyce-Codd (FNBC)

**🎯 Regla:** Cumple 3FN + Para cada dependencia funcional, el determinante debe ser superclave.

#### **❌ Problema - No cumple FNBC:**
| Estudiante | Profesor | Materia |
|------------|----------|---------|
| María | Lin-Manuel | Composición |
| Juan | Lin-Manuel | Composición |

**Problema:** Profesor → Materia, pero "Profesor" no es superclave.

#### **✅ Solución - Cumple FNBC:**

**Tabla PROFESOR_MATERIA:**
| Profesor | Materia |
|----------|---------|
| Lin-Manuel | Composición |
| Daveed | Actuación |

**Tabla ESTUDIANTE_PROFESOR:**
| Estudiante | Profesor |
|------------|----------|
| María | Lin-Manuel |
| Juan | Lin-Manuel |

**💡 Memoria:** "Solo los jefes mandan"

### 8.5 Cuarta Forma Normal (4FN)

**🎯 Regla:** Cumple FNBC + No debe tener dependencias multivaluadas independientes.

#### **❌ Problema - No cumple 4FN:**
| Actor | Habilidad | Instrumento |
|-------|-----------|-------------|
| Lin-Manuel | Canto | Piano |
| Lin-Manuel | Canto | Guitarra |
| Lin-Manuel | Composición | Piano |
| Lin-Manuel | Composición | Guitarra |

**Problema:** Habilidades e instrumentos son independientes, pero se mezclan innecesariamente.

#### **✅ Solución - Cumple 4FN:**

**Tabla ACTOR_HABILIDAD:**
| Actor | Habilidad |
|-------|-----------|
| Lin-Manuel | Canto |
| Lin-Manuel | Composición |

**Tabla ACTOR_INSTRUMENTO:**
| Actor | Instrumento |
|-------|-------------|
| Lin-Manuel | Piano |
| Lin-Manuel | Guitarra |

**💡 Memoria:** "Separa listas independientes"

### 8.6 Quinta Forma Normal (5FN)

**🎯 Regla:** Cumple 4FN + No debe tener dependencias de unión no triviales.

#### **❌ Problema - No cumple 5FN:**
| Actor | Personaje | Escena |
|-------|-----------|--------|
| Lin-Manuel | Hamilton | Acto 1 |
| Lin-Manuel | Hamilton | Acto 2 |
| Leslie | Burr | Acto 1 |
| Leslie | Burr | Acto 2 |

**Problema:** Esta información se puede reconstruir perfectamente desde tablas separadas.

#### **✅ Solución - Cumple 5FN:**

**Tabla ACTOR_PERSONAJE:**
| Actor | Personaje |
|-------|-----------|
| Lin-Manuel | Hamilton |
| Leslie | Burr |

**Tabla PERSONAJE_ESCENA:**
| Personaje | Escena |
|-----------|--------|
| Hamilton | Acto 1 |
| Hamilton | Acto 2 |
| Burr | Acto 1 |
| Burr | Acto 2 |

**Tabla ACTOR_ESCENA:**
| Actor | Escena |
|-------|--------|
| Lin-Manuel | Acto 1 |
| Lin-Manuel | Acto 2 |
| Leslie | Acto 1 |
| Leslie | Acto 2 |

**💡 Memoria:** "No guardes lo que puedes calcular"

---

## 📝 Resumen Rápido

### **🏗️ Modelos de BD:**
- **E-R:** Diseño conceptual (entidades, relaciones, atributos)
- **Relacional:** Implementación práctica (tablas, filas, columnas)

### **🔗 Relaciones:**
- **1:1** - Uno a uno
- **1:N** - Uno a muchos  
- **M:N** - Muchos a muchos

### **📊 Componentes:**
- **Entidad:** Objeto del mundo real
- **Atributo:** Propiedad de una entidad
- **Cardinalidad:** Número de instancias relacionadas

### **🔑 Claves:**
- **Primary Key:** Identificador principal único
- **Unique Key:** Campo único (permite NULL)
- **Foreign Key:** Referencia entre tablas

### **📋 Formas Normales:**
1. **1FN:** "Una cosa por celda"
2. **2FN:** "Todo depende de la clave completa"  
3. **3FN:** "Rompe las cadenas"
4. **FNBC:** "Solo los jefes mandan"
5. **4FN:** "Separa listas independientes"
6. **5FN:** "No guardes lo que puedes calcular"

### **💾 Tipos de Datos Esenciales:**
- **INT:** Números enteros
- **VARCHAR(n):** Texto variable
- **DATE/TIME:** Fechas y horas
- **BOOLEAN:** Verdadero/Falso
- **DECIMAL(p,s):** Números con decimales

---

## 🔗 Referencias y Recursos

### **📚 Lecturas Recomendadas:**
- **Fundamentos de Bases de Datos** - Elmasri & Navathe
- **Sistemas de Bases de Datos** - Date, C.J.
- **Database System Concepts** - Silberschatz, Korth & Sudarshan

### **🛠️ Herramientas:**
- **MySQL Workbench:** Diseño visual de BD
- **PostgreSQL:** Base de datos open source
- **draw.io:** Diagramas E-R online
- **dbdiagram.io:** Diseñador de esquemas

### **🎯 Práctica:**
- **W3Schools SQL Tutorial**
- **SQLBolt:** Ejercicios interactivos
- **HackerRank SQL:** Challenges
- **LeetCode Database:** Problemas avanzados

### **🔧 SQL Online:**
- **DB Fiddle:** Pruebas rápidas
- **SQLiteOnline:** BD en el navegador
- **MySQL Online:** Entorno completo

---

**💡 Consejo Final:** La práctica hace al maestro. Como Hamilton dominó las finanzas americanas paso a paso, domina las bases de datos concepto por concepto. ¡Cada tabla bien diseñada es una victoria!

---

*"I'm not throwing away my shot... at understanding databases!"* 🎭

**⭐ Si esta guía te ayudó, dale una estrella en GitHub y compártela con otros desarrolladores.**