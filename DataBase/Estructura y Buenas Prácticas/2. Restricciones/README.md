# 🛡️ Restricciones

## ¿Qué son las Restricciones?

Las **restricciones** son como las **reglas de tránsito** de tu base de datos. Así como las señales de tránsito te dicen qué puedes y qué no puedes hacer en la calle, las restricciones te dicen qué datos son válidos y cuáles no.

## 🏪 Ejemplo de la Vida Real: La Escuela "San José"

Imagina que la escuela tiene reglas:
- **Edad mínima**: 5 años para entrar a primaria
- **Calificaciones**: Solo del 0 al 10
- **Email**: Debe tener formato válido
- **Teléfono**: Solo números, sin letras
- **DNI**: Exactamente 8 dígitos

Estas son **restricciones** que protegen la calidad de los datos.

## 🎯 Tipos de Restricciones

### 🔒 **NOT NULL** - "Campo Obligatorio"

**Concepto**: Como el **nombre** de una persona - no puede estar vacío.

#### 🏫 Ejemplo Escolar:
```sql
CREATE TABLE ESTUDIANTES (
    id_estudiante INT PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,        -- Debe tener nombre
    apellido VARCHAR(50) NOT NULL,      -- Debe tener apellido
    email VARCHAR(100)                  -- Puede estar vacío
);
```

#### 🏪 Ejemplo de Negocio:
```sql
CREATE TABLE PRODUCTOS (
    id_producto INT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,       -- Todo producto debe tener nombre
    precio DECIMAL(10,2) NOT NULL,      -- Todo producto debe tener precio
    descripcion TEXT                    -- La descripción es opcional
);
```

### 🔢 **CHECK** - "Reglas Específicas"

**Concepto**: Como las **reglas de edad** para conducir - debe cumplir ciertas condiciones.

#### 🏫 Ejemplo Escolar:
```sql
CREATE TABLE ESTUDIANTES (
    id_estudiante INT PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,
    edad INT CHECK (edad >= 5 AND edad <= 25),           -- Entre 5 y 25 años
    calificacion DECIMAL(4,2) CHECK (calificacion >= 0 AND calificacion <= 10),  -- Del 0 al 10
    email VARCHAR(100) CHECK (email LIKE '%@%.%')       -- Debe tener @ y punto
);
```

#### 🏪 Ejemplo de Negocio:
```sql
CREATE TABLE PRODUCTOS (
    id_producto INT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    precio DECIMAL(10,2) CHECK (precio > 0),            -- Precio debe ser positivo
    stock INT CHECK (stock >= 0),                       -- Stock no puede ser negativo
    categoria VARCHAR(50) CHECK (categoria IN ('Ropa', 'Calzado', 'Accesorios'))  -- Solo categorías válidas
);
```

### 🔑 **UNIQUE** - "Valor Único"

**Concepto**: Como el **DNI** - no puede repetirse.

#### 🏫 Ejemplo Escolar:
```sql
CREATE TABLE ESTUDIANTES (
    id_estudiante INT PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,
    dni VARCHAR(8) UNIQUE,              -- DNI único
    email VARCHAR(100) UNIQUE,          -- Email único
    numero_estudiante VARCHAR(10) UNIQUE -- Código único de la escuela
);
```

#### 🏪 Ejemplo de Negocio:
```sql
CREATE TABLE CLIENTES (
    id_cliente INT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    email VARCHAR(100) UNIQUE,          -- Email único
    telefono VARCHAR(20) UNIQUE,        -- Teléfono único
    codigo_cliente VARCHAR(20) UNIQUE   -- Código único del cliente
);
```

### 🔗 **FOREIGN KEY** - "Referencia Válida"

**Concepto**: Como el **código postal** - debe existir en la tabla de ciudades.

#### 🏫 Ejemplo Escolar:
```sql
CREATE TABLE MATERIAS (
    id_materia INT PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,
    profesor_id INT,
    FOREIGN KEY (profesor_id) REFERENCES PROFESORES(id_profesor)  -- Debe existir el profesor
);
```

#### 🏪 Ejemplo de Negocio:
```sql
CREATE TABLE VENTAS (
    id_venta INT PRIMARY KEY,
    fecha_venta DATE,
    cliente_id INT,
    producto_id INT,
    FOREIGN KEY (cliente_id) REFERENCES CLIENTES(id_cliente),     -- Cliente debe existir
    FOREIGN KEY (producto_id) REFERENCES PRODUCTOS(id_producto)   -- Producto debe existir
);
```

### 📅 **DEFAULT** - "Valor por Defecto"

**Concepto**: Como la **hora de entrada** al trabajo - si no especificas, es 9:00 AM.

#### 🏫 Ejemplo Escolar:
```sql
CREATE TABLE ESTUDIANTES (
    id_estudiante INT PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,
    fecha_registro DATE DEFAULT CURRENT_DATE,    -- Fecha actual si no especificas
    estudiante_activo BOOLEAN DEFAULT TRUE,      -- Activo por defecto
    calificacion_promedio DECIMAL(4,2) DEFAULT 0.00  -- Promedio 0 si no hay calificaciones
);
```

#### 🏪 Ejemplo de Negocio:
```sql
CREATE TABLE PRODUCTOS (
    id_producto INT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    fecha_ingreso DATE DEFAULT CURRENT_DATE,     -- Fecha actual
    producto_activo BOOLEAN DEFAULT TRUE,        -- Activo por defecto
    stock_disponible INT DEFAULT 0               -- Sin stock por defecto
);
```

## 🚀 Restricciones Avanzadas

### **Restricciones de Tabla** - "Reglas Complejas"

**Concepto**: Como las **reglas de negocio** - condiciones que involucran varios campos.

#### 🏫 Ejemplo Escolar:
```sql
CREATE TABLE ESTUDIANTES_MATERIAS (
    estudiante_id INT,
    materia_id INT,
    calificacion DECIMAL(4,2),
    fecha_evaluacion DATE,
    PRIMARY KEY (estudiante_id, materia_id),
    FOREIGN KEY (estudiante_id) REFERENCES ESTUDIANTES(id_estudiante),
    FOREIGN KEY (materia_id) REFERENCES MATERIAS(id_materia),
    CHECK (calificacion >= 0 AND calificacion <= 10),                    -- Calificación válida
    CHECK (fecha_evaluacion <= CURRENT_DATE)                            -- No evaluaciones futuras
);
```

#### 🏪 Ejemplo de Negocio:
```sql
CREATE TABLE VENTAS (
    id_venta INT PRIMARY KEY,
    cliente_id INT,
    producto_id INT,
    cantidad INT,
    precio_unitario DECIMAL(10,2),
    fecha_venta DATE,
    FOREIGN KEY (cliente_id) REFERENCES CLIENTES(id_cliente),
    FOREIGN KEY (producto_id) REFERENCES PRODUCTOS(id_producto),
    CHECK (cantidad > 0),                                               -- Cantidad positiva
    CHECK (precio_unitario > 0),                                        -- Precio positivo
    CHECK (fecha_venta <= CURRENT_DATE)                                 -- No ventas futuras
);
```

## 💡 Analogías para Recordar

### **NOT NULL**
- Como el **nombre** - no puede estar vacío
- Como la **dirección** - necesitas saber dónde vive alguien

### **CHECK**
- Como las **reglas de edad** - debe ser mayor de 18 para conducir
- Como las **reglas de peso** - no puede pesar menos de 0 kg

### **UNIQUE**
- Como el **DNI** - no puede repetirse
- Como el **email** - cada persona tiene uno único

### **FOREIGN KEY**
- Como el **código postal** - debe existir en la lista de ciudades
- Como el **número de departamento** - debe existir en la empresa

### **DEFAULT**
- Como la **hora de entrada** - 9:00 AM si no especificas
- Como el **estado civil** - soltero por defecto

## 🚀 ¿Cuándo Usar Cada Restricción?

### **NOT NULL**: Para campos obligatorios
- Nombres, precios, fechas importantes
- Cualquier campo que siempre debe tener valor

### **CHECK**: Para validar datos
- Edades, precios, cantidades
- Formatos específicos (email, teléfono)

### **UNIQUE**: Para evitar duplicados
- Emails, teléfonos, códigos únicos
- Cualquier campo que no debe repetirse

### **FOREIGN KEY**: Para mantener relaciones
- Cuando una tabla referencia otra
- Para evitar datos huérfanos

### **DEFAULT**: Para valores comunes
- Fechas actuales, estados por defecto
- Valores que se usan frecuentemente

## 🎯 Ejercicio Práctico

Imagina que creas una tabla para **empleados**:

```sql
CREATE TABLE EMPLEADOS (
    id_empleado INT PRIMARY KEY,                    -- Identificador único
    nombre VARCHAR(50) NOT NULL,                    -- Nombre obligatorio
    apellido VARCHAR(50) NOT NULL,                  -- Apellido obligatorio
    email VARCHAR(100) UNIQUE,                      -- Email único
    telefono VARCHAR(20) UNIQUE,                    -- Teléfono único
    fecha_nacimiento DATE CHECK (fecha_nacimiento < CURRENT_DATE),  -- No fechas futuras
    salario DECIMAL(10,2) CHECK (salario > 0),      -- Salario positivo
    departamento_id INT,
    fecha_contratacion DATE DEFAULT CURRENT_DATE,   -- Fecha actual por defecto
    empleado_activo BOOLEAN DEFAULT TRUE,           -- Activo por defecto
    FOREIGN KEY (departamento_id) REFERENCES DEPARTAMENTOS(id_departamento)  -- Departamento válido
);
```

## 💡 Consejo del Experto

> *"Las restricciones son como el seguro de tu base de datos. Te protegen de errores y mantienen la calidad de tus datos. No escatimes en ellas."*

---

**¿Entendiste?** ¡Perfecto! Ahora sabes cómo proteger la calidad de tus datos con reglas claras. Con esto completamos toda la guía de bases de datos. ¡Ya eres un experto! 🛡️ 