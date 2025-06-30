# 💾 Tipos de Datos

## ¿Qué son los Tipos de Datos?

Los **tipos de datos** son como los **diferentes tipos de cajas** donde guardas cosas. No guardarías leche en una caja de zapatos, ¿verdad? Lo mismo pasa en las bases de datos: cada tipo de información necesita su "caja" específica.

## 🏪 Ejemplo de la Vida Real: La Tienda "Todo en Uno"

María tiene una tienda y necesita guardar diferentes tipos de información:
- **Nombres** de clientes (texto)
- **Precios** de productos (números con decimales)
- **Fechas** de ventas (fechas)
- **Cantidades** en inventario (números enteros)
- **Si un producto está activo** (sí/no)

## 🎯 Tipos Numéricos

### **INT** - "Números Enteros"
- **¿Qué es?**: Números sin decimales
- **Rango**: -2,147,483,648 a 2,147,483,647
- **Ejemplo**: Edad, cantidad de productos, ID de cliente

```sql
edad_cliente INT,           -- 25
cantidad_stock INT,         -- 150
id_producto INT            -- 1001
```

### **DECIMAL(p,s)** - "Números con Decimales"
- **¿Qué es?**: Números con decimales exactos
- **p**: Total de dígitos, **s**: Dígitos después del punto
- **Ejemplo**: Precios, calificaciones, medidas

```sql
precio DECIMAL(10,2),       -- 150.50
calificacion DECIMAL(3,1),  -- 9.5
altura DECIMAL(5,2)         -- 175.30
```

### **FLOAT** - "Números Aproximados"
- **¿Qué es?**: Números con decimales aproximados
- **Ejemplo**: Temperatura, peso, distancias

```sql
temperatura FLOAT,          -- 23.456789
peso FLOAT,                -- 65.123456
distancia FLOAT            -- 10.567890
```

## 📝 Tipos de Texto

### **VARCHAR(n)** - "Texto Variable"
- **¿Qué es?**: Texto que puede cambiar de longitud
- **n**: Máximo de caracteres
- **Ejemplo**: Nombres, direcciones, descripciones cortas

```sql
nombre VARCHAR(50),         -- "Juan Pérez"
direccion VARCHAR(200),     -- "Calle Principal #123"
email VARCHAR(100)          -- "juan@email.com"
```

### **CHAR(n)** - "Texto Fijo"
- **¿Qué es?**: Texto de longitud fija
- **Ejemplo**: Códigos, abreviaciones

```sql
codigo_producto CHAR(5),    -- "CAM01"
estado CHAR(2),            -- "CA"
codigo_postal CHAR(5)      -- "12345"
```

### **TEXT** - "Texto Largo"
- **¿Qué es?**: Texto sin límite de longitud
- **Ejemplo**: Descripciones largas, comentarios

```sql
descripcion_producto TEXT,  -- "Camiseta de algodón 100%..."
comentario_cliente TEXT,    -- "Excelente producto, muy..."
biografia TEXT             -- "Juan nació en..."
```

## 📅 Tipos de Fecha y Tiempo

### **DATE** - "Solo Fecha"
- **¿Qué es?**: Fecha sin hora
- **Formato**: YYYY-MM-DD
- **Ejemplo**: Fecha de nacimiento, fecha de venta

```sql
fecha_nacimiento DATE,      -- 1990-05-15
fecha_venta DATE,          -- 2024-01-20
fecha_vencimiento DATE     -- 2024-12-31
```

### **TIME** - "Solo Hora"
- **¿Qué es?**: Hora sin fecha
- **Formato**: HH:MM:SS
- **Ejemplo**: Hora de apertura, duración

```sql
hora_apertura TIME,         -- 09:00:00
duracion_cancion TIME,      -- 03:45:30
hora_cierre TIME           -- 18:00:00
```

### **DATETIME** - "Fecha y Hora"
- **¿Qué es?**: Fecha y hora juntas
- **Formato**: YYYY-MM-DD HH:MM:SS
- **Ejemplo**: Cuándo se hizo una venta, cuándo se registró un usuario

```sql
fecha_registro DATETIME,    -- 2024-01-20 14:30:25
fecha_compra DATETIME,      -- 2024-01-20 15:45:10
ultimo_acceso DATETIME     -- 2024-01-20 16:20:30
```

## ✅ Tipos Booleanos

### **BOOLEAN** - "Sí o No"
- **¿Qué es?**: Solo puede ser verdadero o falso
- **Ejemplo**: Si algo está activo, si algo está disponible

```sql
producto_activo BOOLEAN,    -- TRUE
cliente_vip BOOLEAN,        -- FALSE
envio_gratis BOOLEAN       -- TRUE
```

## 🏗️ Ejemplo Completo: Tabla PRODUCTOS

```sql
CREATE TABLE PRODUCTOS (
    id_producto INT PRIMARY KEY,                    -- Número entero único
    nombre VARCHAR(100) NOT NULL,                   -- Nombre del producto
    descripcion TEXT,                               -- Descripción larga
    precio DECIMAL(10,2) NOT NULL,                  -- Precio con 2 decimales
    stock_disponible INT DEFAULT 0,                 -- Cantidad en inventario
    codigo_barras CHAR(13),                         -- Código fijo de 13 dígitos
    fecha_ingreso DATE,                             -- Cuándo llegó al inventario
    hora_apertura TIME,                             -- Hora de apertura de la tienda
    ultima_actualizacion DATETIME,                  -- Cuándo se actualizó por última vez
    producto_activo BOOLEAN DEFAULT TRUE,           -- Si está disponible para venta
    calificacion DECIMAL(3,2)                       -- Calificación de 0.00 a 10.00
);
```

## 💡 Analogías para Recordar

### **Numéricos**
- **INT**: Como contar **personas** - números enteros
- **DECIMAL**: Como **dinero** - necesita decimales exactos
- **FLOAT**: Como **temperatura** - aproximado está bien

### **Texto**
- **VARCHAR**: Como **nombres** - pueden ser cortos o largos
- **CHAR**: Como **códigos** - siempre del mismo tamaño
- **TEXT**: Como **historias** - pueden ser muy largas

### **Fechas**
- **DATE**: Como **cumpleaños** - solo la fecha
- **TIME**: Como **hora de clase** - solo la hora
- **DATETIME**: Como **cita médica** - fecha y hora

### **Booleanos**
- **BOOLEAN**: Como **interruptor** - encendido o apagado

## 🚀 ¿Cómo Elegir el Tipo Correcto?

### **Paso 1**: Identifica qué información guardas
- ¿Es texto, número, fecha, sí/no?

### **Paso 2**: Piensa en el tamaño
- ¿Cuánto espacio necesitas?

### **Paso 3**: Considera la precisión
- ¿Necesitas decimales exactos o aproximados?

## 🎯 Ejercicio Práctico

Imagina que creas una tabla para **estudiantes**:

```sql
CREATE TABLE ESTUDIANTES (
    id_estudiante INT PRIMARY KEY,                 -- Número único
    nombre VARCHAR(50) NOT NULL,                   -- Nombre del estudiante
    apellido VARCHAR(50) NOT NULL,                 -- Apellido del estudiante
    fecha_nacimiento DATE,                         -- Cuándo nació
    edad INT,                                      -- Edad actual
    calificacion_promedio DECIMAL(4,2),            -- Promedio con 2 decimales
    estudiante_activo BOOLEAN DEFAULT TRUE,        -- Si está estudiando
    fecha_registro DATETIME,                       -- Cuándo se registró
    comentarios TEXT                               -- Observaciones del profesor
);
```

---

**¿Entendiste?** ¡Excelente! Ahora sabes qué "caja" usar para cada tipo de información. En la siguiente lección veremos las "llaves" que identifican únicamente cada elemento. 💾