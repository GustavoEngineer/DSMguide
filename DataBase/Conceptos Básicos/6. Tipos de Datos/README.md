# 💾 Tipos de Datos

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