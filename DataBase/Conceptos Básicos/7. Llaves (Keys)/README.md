# 🔑 Llaves (Keys)

## ¿Qué son las Llaves?

Las **llaves** son como los **DNI** de tu base de datos. Así como cada persona tiene un DNI único que la identifica, cada elemento en tu base de datos necesita una "llave" que lo identifique de manera única.

## 🏪 Ejemplo de la Vida Real: La Escuela "San José"

Imagina que en la escuela necesitas identificar a cada estudiante:
- **DNI** (número único que identifica a cada persona)
- **Número de estudiante** (código único de la escuela)
- **Email** (dirección única de correo)
- **Teléfono** (número único de contacto)

## 🎯 Tipos de Llaves

### 🔑 **PRIMARY KEY (Clave Primaria)** - "El DNI Principal"

**Concepto**: Como el **DNI** de una persona - es único, obligatorio y no cambia.

#### 🏫 Ejemplo Escolar:
```sql
CREATE TABLE ESTUDIANTES (
    id_estudiante INT PRIMARY KEY,        -- Como el DNI
    nombre VARCHAR(50) NOT NULL,
    apellido VARCHAR(50) NOT NULL,
    fecha_nacimiento DATE
);
```

#### 🏪 Ejemplo de Negocio:
```sql
CREATE TABLE PRODUCTOS (
    id_producto INT PRIMARY KEY,          -- Identificador único
    nombre VARCHAR(100) NOT NULL,
    precio DECIMAL(10,2) NOT NULL
);
```

**Características**:
- ✅ **Único**: No se puede repetir
- ✅ **Obligatorio**: NUNCA puede estar vacío
- ✅ **Solo UNA por tabla**: Como solo puedes tener un DNI
- ✅ **No cambia**: Una vez asignado, no debería cambiar
- ✅ **Búsquedas rápidas**: La base de datos lo indexa automáticamente

### 🔐 **UNIQUE KEY (Clave Única)** - "El Email"

**Concepto**: Como el **email** de una persona - es único, pero puede estar vacío.

#### 🏫 Ejemplo Escolar:
```sql
CREATE TABLE ESTUDIANTES (
    id_estudiante INT PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,
    email VARCHAR(100) UNIQUE,            -- Email único
    telefono VARCHAR(20) UNIQUE,          -- Teléfono único
    numero_estudiante VARCHAR(10) UNIQUE  -- Código único de la escuela
);
```

#### 🏪 Ejemplo de Negocio:
```sql
CREATE TABLE CLIENTES (
    id_cliente INT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    email VARCHAR(100) UNIQUE,            -- Email único
    codigo_cliente VARCHAR(20) UNIQUE     -- Código único del cliente
);
```

**Características**:
- ✅ **Único**: No se puede repetir
- ⚠️ **Puede estar vacío**: Pero solo un registro puede estar vacío
- ✅ **Múltiples por tabla**: Puedes tener varios campos únicos
- ✅ **Puede cambiar**: Es modificable
- ✅ **Búsquedas rápidas**: También se indexa automáticamente

## 🔗 **FOREIGN KEY (Clave Foránea)** - "La Referencia"

**Concepto**: Como el **número de departamento** en una empresa - te dice a qué departamento pertenece un empleado.

#### 🏫 Ejemplo Escolar:
```sql
CREATE TABLE MATERIAS (
    id_materia INT PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,
    profesor_id INT,
    FOREIGN KEY (profesor_id) REFERENCES PROFESORES(id_profesor)
);
```

#### 🏪 Ejemplo de Negocio:
```sql
CREATE TABLE VENTAS (
    id_venta INT PRIMARY KEY,
    fecha_venta DATE,
    cliente_id INT,
    producto_id INT,
    FOREIGN KEY (cliente_id) REFERENCES CLIENTES(id_cliente),
    FOREIGN KEY (producto_id) REFERENCES PRODUCTOS(id_producto)
);
```

**¿Cómo funciona?**
- La **clave foránea** "apunta" a la **clave primaria** de otra tabla
- Te dice qué elemento de la otra tabla está relacionado
- Evita datos inconsistentes

## 🔑 **COMPOSITE KEY (Clave Compuesta)** - "Combinación Única"

**Concepto**: Como el **asiento en un avión** - necesita número de fila Y letra de asiento para ser único.

#### 🏫 Ejemplo Escolar:
```sql
CREATE TABLE ESTUDIANTES_MATERIAS (
    estudiante_id INT,
    materia_id INT,
    calificacion DECIMAL(4,2),
    PRIMARY KEY (estudiante_id, materia_id)  -- Combinación única
);
```

#### 🏪 Ejemplo de Negocio:
```sql
CREATE TABLE PEDIDOS_PRODUCTOS (
    pedido_id INT,
    producto_id INT,
    cantidad INT,
    precio_unitario DECIMAL(10,2),
    PRIMARY KEY (pedido_id, producto_id)  -- Un pedido puede tener varios productos
);
```

**¿Cómo funciona?**
- **Varios campos** juntos forman la clave única
- Cada **combinación** debe ser única
- Útil cuando un solo campo no es suficiente

## 💡 Analogías para Recordar

### **PRIMARY KEY**
- Como el **DNI** - único, obligatorio, no cambia
- Como el **número de serie** de un producto

### **UNIQUE KEY**
- Como el **email** - único pero puede estar vacío
- Como el **número de teléfono** - único por persona

### **FOREIGN KEY**
- Como el **código postal** - te dice a qué ciudad pertenece
- Como el **número de departamento** - te dice dónde trabaja alguien

### **COMPOSITE KEY**
- Como **fila + asiento** en un cine
- Como **fecha + hora** para una cita médica

## 🚀 ¿Cuándo Usar Cada Tipo?

### **PRIMARY KEY**: Siempre
- Cada tabla debe tener una
- Usa un campo que sea único y no cambie

### **UNIQUE KEY**: Cuando necesites unicidad
- Emails, teléfonos, códigos únicos
- Campos que pueden estar vacíos pero no repetirse

### **FOREIGN KEY**: Para conectar tablas
- Cuando una tabla necesita referenciar otra
- Para mantener la integridad de los datos

### **COMPOSITE KEY**: Para combinaciones únicas
- Cuando un solo campo no es suficiente
- Para tablas de relación muchos a muchos

## 🎯 Ejercicio Práctico

Imagina una **biblioteca**:

```sql
-- Tabla LIBROS
CREATE TABLE LIBROS (
    id_libro INT PRIMARY KEY,                    -- Identificador único
    isbn VARCHAR(13) UNIQUE,                     -- Código único del libro
    titulo VARCHAR(200) NOT NULL,
    autor VARCHAR(100) NOT NULL
);

-- Tabla LECTORES
CREATE TABLE LECTORES (
    id_lector INT PRIMARY KEY,                   -- Identificador único
    nombre VARCHAR(100) NOT NULL,
    email VARCHAR(100) UNIQUE,                   -- Email único
    telefono VARCHAR(20) UNIQUE                  -- Teléfono único
);

-- Tabla PRESTAMOS (conecta libros y lectores)
CREATE TABLE PRESTAMOS (
    id_prestamo INT PRIMARY KEY,                 -- Identificador único
    libro_id INT,
    lector_id INT,
    fecha_prestamo DATE,
    fecha_devolucion DATE,
    FOREIGN KEY (libro_id) REFERENCES LIBROS(id_libro),
    FOREIGN KEY (lector_id) REFERENCES LECTORES(id_lector)
);

-- Tabla RESERVAS (clave compuesta)
CREATE TABLE RESERVAS (
    libro_id INT,
    lector_id INT,
    fecha_reserva DATE,
    PRIMARY KEY (libro_id, lector_id)            -- Un lector no puede reservar el mismo libro dos veces
);
```

---

**¿Entendiste?** ¡Perfecto! Ahora sabes cómo identificar únicamente cada elemento en tu base de datos. Con esto completamos los conceptos básicos. En la siguiente sección veremos cómo organizar mejor esta información. 🔑