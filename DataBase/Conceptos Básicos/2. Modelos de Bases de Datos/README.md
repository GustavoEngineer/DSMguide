# 🏗️ Modelos de Base de Datos

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