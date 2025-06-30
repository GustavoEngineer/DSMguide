# 📊 Entidades y Atributos

## ¿Qué son las Entidades?

Las **entidades** son como los **personajes principales** de una historia. En tu base de datos, son los "objetos" o "cosas" más importantes que quieres manejar.

## 🏪 Ejemplo de la Vida Real: La Tienda de Ropa "Fashion Store"

María tiene una tienda de ropa y necesita organizar su información. Sus entidades principales son:
- **PRODUCTOS** (camisetas, pantalones, zapatos)
- **CLIENTES** (personas que compran)
- **PROVEEDORES** (empresas que venden ropa a María)
- **VENTAS** (cuando un cliente compra algo)

## 🎯 Tipos de Entidades

### 🏢 **Entidad Fuerte** - "El Independiente"

**Concepto**: Como una **persona adulta** que puede vivir por su cuenta.

#### 🏪 Ejemplo de la Tienda:
- **PRODUCTO**: Una camiseta existe independientemente
- **CLIENTE**: Juan Pérez existe aunque no compre nada
- **PROVEEDOR**: Nike existe aunque no venda a María

### 🏚️ **Entidad Débil** - "El Dependiente"

**Concepto**: Como un **bebé** que necesita de sus padres para existir.

#### 🏪 Ejemplo de la Tienda:
- **VENTA**: Solo existe si hay un CLIENTE y un PRODUCTO
- **DETALLE_VENTA**: Solo existe si hay una VENTA
- **INVENTARIO**: Solo existe si hay un PRODUCTO

## 📋 ¿Qué son los Atributos?

Los **atributos** son como las **características** de una persona. Si una entidad es como una persona, los atributos son su nombre, edad, altura, color de pelo, etc.

## 🎯 Tipos de Atributos

### 🔑 **Atributo Clave** - "El DNI"

**Concepto**: Como el **DNI** de una persona - es único y no se repite.

#### 🏪 Ejemplo de la Tienda:
- **ID_PRODUCTO**: "CAM001" (único para cada producto)
- **ID_CLIENTE**: "CLI123" (único para cada cliente)
- **ID_VENTA**: "VEN456" (único para cada venta)

### 📝 **Atributo Simple** - "Una Característica"

**Concepto**: Como la **edad** de una persona - un solo valor.

#### 🏪 Ejemplo de la Tienda:
- **precio**: $150
- **talla**: "M"
- **color**: "Azul"
- **fecha_venta**: "2024-01-15"

### 📋 **Atributo Compuesto** - "Nombre Completo"

**Concepto**: Como el **nombre completo** que se puede dividir en nombre y apellido.

#### 🏪 Ejemplo de la Tienda:
```
nombre_completo: "Juan Carlos Pérez López"
├── nombre: "Juan Carlos"
├── apellido_paterno: "Pérez"
└── apellido_materno: "López"
```

### 🔢 **Atributo Multivaluado** - "Habilidades"

**Concepto**: Como las **habilidades** de una persona - puede tener muchas.

#### 🏪 Ejemplo de la Tienda:
```
colores_disponibles: ["Rojo", "Azul", "Verde", "Negro"]
tallas_disponibles: ["XS", "S", "M", "L", "XL"]
categorias: ["Casual", "Deportivo", "Elegante"]
```

### 💭 **Atributo Derivado** - "Edad Calculada"

**Concepto**: Como la **edad** que se calcula desde la fecha de nacimiento.

#### 🏪 Ejemplo de la Tienda:
- **edad_cliente**: Se calcula desde fecha_nacimiento
- **antiguedad_producto**: Se calcula desde fecha_ingreso
- **total_venta**: Se calcula sumando precio * cantidad

## 🏗️ Ejemplo Completo: Entidad PRODUCTO

```
PRODUCTO:
├── id_producto (Clave) → "CAM001"
├── nombre (Simple) → "Camiseta Básica"
├── descripcion (Simple) → "Camiseta de algodón 100%"
├── precio (Simple) → $150.00
├── informacion_proveedor (Compuesto)
│   ├── nombre_proveedor → "Nike"
│   ├── telefono_proveedor → "555-1234"
│   └── email_proveedor → "nike@email.com"
├── colores_disponibles (Multivaluado) → ["Rojo", "Azul", "Negro"]
├── tallas_disponibles (Multivaluado) → ["S", "M", "L", "XL"]
├── fecha_ingreso (Simple) → "2024-01-01"
├── antiguedad_dias (Derivado) → 15 (calculado)
└── stock_disponible (Simple) → 50
```

## 💡 Analogías para Recordar

### **Entidad Fuerte vs Débil**
- **Fuerte**: Como un **árbol** que puede vivir solo
- **Débil**: Como una **hoja** que necesita del árbol

### **Atributos**
- **Clave**: Como el **DNI** - único e identificador
- **Simple**: Como la **altura** - un solo valor
- **Compuesto**: Como la **dirección** - se puede dividir
- **Multivaluado**: Como los **idiomas** - puede saber varios
- **Derivado**: Como la **edad** - se calcula de la fecha

## 🚀 ¿Cómo Identificar Entidades y Atributos?

### **Paso 1**: Piensa en los "objetos" principales
- ¿Qué "cosas" maneja tu aplicación?

### **Paso 2**: Identifica las características
- ¿Qué información necesitas de cada "cosa"?

### **Paso 3**: Clasifica los atributos
- ¿Es único? → Clave
- ¿Es un solo valor? → Simple
- ¿Se puede dividir? → Compuesto
- ¿Puede tener varios valores? → Multivaluado
- ¿Se calcula? → Derivado

## 🎯 Ejercicio Práctico

Imagina que quieres crear una aplicación para una **biblioteca**:

### **Entidades**:
- **LIBRO** (entidad fuerte)
- **LECTOR** (entidad fuerte)
- **PRESTAMO** (entidad débil - necesita libro y lector)

### **Atributos del LIBRO**:
- **id_libro** (Clave)
- **titulo** (Simple)
- **autor** (Compuesto: nombre, apellido)
- **generos** (Multivaluado: ["Ficción", "Aventura"])
- **fecha_publicacion** (Simple)
- **antiguedad_anos** (Derivado)

---

**¿Entendiste?** ¡Excelente! Ahora sabes que las entidades son como los "personajes" de tu base de datos y los atributos son sus "características". En la siguiente lección veremos cuántos de estos "personajes" se relacionan entre sí. 📊
