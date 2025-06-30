# 🔑 Claves (Keys)

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