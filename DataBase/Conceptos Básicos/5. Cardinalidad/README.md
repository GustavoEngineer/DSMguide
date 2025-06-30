# 🔢 Cardinalidad

## ¿Qué es la Cardinalidad?

La **cardinalidad** es como contar **cuántos amigos** puede tener una persona. Te dice exactamente cuántos elementos de un tipo se pueden relacionar con cuántos elementos de otro tipo.

## 🏪 Ejemplo de la Vida Real: La Escuela "San José"

Imagina que quieres saber:
- ¿Cuántos estudiantes puede tener un profesor?
- ¿Cuántos profesores puede tener un estudiante?
- ¿Cuántas materias puede tomar un estudiante?

## 🎯 Notación (min, max)

La cardinalidad se escribe como **(mínimo, máximo)**:

### **(0,1)** - "Opcional, máximo uno"
- **Significado**: Puede no tener ninguno, o tener exactamente uno
- **Ejemplo**: Un estudiante puede tener **0 o 1** credencial escolar

### **(1,1)** - "Obligatorio, exactamente uno"
- **Significado**: Debe tener exactamente uno
- **Ejemplo**: Un estudiante debe tener **exactamente 1** nombre

### **(0,N)** - "Opcional, muchos"
- **Significado**: Puede no tener ninguno, o tener muchos
- **Ejemplo**: Un estudiante puede tener **0 o muchos** amigos

### **(1,N)** - "Obligatorio, muchos"
- **Significado**: Debe tener al menos uno, puede tener muchos
- **Ejemplo**: Un estudiante debe tomar **al menos 1** materia

## 🏫 Ejemplos Escolares

### **1. PROFESOR - ESTUDIANTE: (1,N) ---- (1,1)**
```
PROFESOR (1,N) ----ENSEÑA---- (1,1) ESTUDIANTE
```
- Un **profesor** puede enseñar a **muchos estudiantes** (1,N)
- Un **estudiante** tiene **exactamente un profesor** por materia (1,1)

**Ejemplo real**: La Sra. García enseña Matemáticas a Juan, Ana, Carlos y María. Cada uno tiene solo a la Sra. García como profesora de Matemáticas.

### **2. ESTUDIANTE - MATERIA: (1,N) ---- (0,N)**
```
ESTUDIANTE (1,N) ----TOMA---- (0,N) MATERIA
```
- Un **estudiante** puede tomar **muchas materias** (1,N)
- Una **materia** puede ser tomada por **muchos estudiantes** (0,N)

**Ejemplo real**: Juan toma Matemáticas, Historia y Ciencias. Matemáticas es tomada por Juan, Ana, Carlos y María.

### **3. ESTUDIANTE - CREDENCIAL: (1,1) ---- (1,1)**
```
ESTUDIANTE (1,1) ----TIENE---- (1,1) CREDENCIAL
```
- Un **estudiante** tiene **exactamente una credencial** (1,1)
- Una **credencial** pertenece a **exactamente un estudiante** (1,1)

**Ejemplo real**: Juan tiene la credencial #12345, y solo Juan tiene esa credencial.

## 🏪 Ejemplos de Negocio

### **1. DEPARTAMENTO - EMPLEADO: (1,1) ---- (1,N)**
```
DEPARTAMENTO (1,1) ----TIENE---- (1,N) EMPLEADO
```
- Un **departamento** tiene **muchos empleados** (1,N)
- Un **empleado** pertenece a **exactamente un departamento** (1,1)

### **2. EMPLEADO - PROYECTO: (0,N) ---- (0,N)**
```
EMPLEADO (0,N) ----TRABAJA_EN---- (0,N) PROYECTO
```
- Un **empleado** puede trabajar en **muchos proyectos** (0,N)
- Un **proyecto** puede tener **muchos empleados** (0,N)

### **3. EMPLEADO - TARJETA_ACCESO: (1,1) ---- (1,1)**
```
EMPLEADO (1,1) ----TIENE---- (1,1) TARJETA_ACCESO
```
- Un **empleado** tiene **exactamente una tarjeta** (1,1)
- Una **tarjeta** pertenece a **exactamente un empleado** (1,1)

## 💡 Analogías para Recordar

### **(0,1)** - "Opcional, máximo uno"
- Como tener **una mascota** - puedes no tener ninguna, o tener una

### **(1,1)** - "Obligatorio, exactamente uno"
- Como tener **un nombre** - debes tener exactamente uno

### **(0,N)** - "Opcional, muchos"
- Como tener **amigos** - puedes no tener ninguno, o tener muchos

### **(1,N)** - "Obligatorio, muchos"
- Como tener **familia** - debes tener al menos un familiar

## 🚀 ¿Cómo Aplicar Cardinalidad?

### **Paso 1**: Identifica las entidades
- ¿Qué "objetos" se relacionan?

### **Paso 2**: Piensa en la relación
- ¿Cuántos del primer tipo pueden relacionarse con cuántos del segundo?

### **Paso 3**: Determina los límites
- ¿Es obligatorio o opcional?
- ¿Es uno o muchos?

## 🎯 Ejercicio Práctico

Imagina una **biblioteca**:

### **LIBRO - LECTOR: (0,N) ---- (0,N)**
- Un **libro** puede ser leído por **muchos lectores**
- Un **lector** puede leer **muchos libros**

### **LECTOR - CREDENCIAL: (1,1) ---- (1,1)**
- Un **lector** tiene **exactamente una credencial**
- Una **credencial** pertenece a **exactamente un lector**

### **LIBRERO - LIBRO: (1,N) ---- (1,1)**
- Un **librero** puede manejar **muchos libros**
- Un **libro** es manejado por **exactamente un librero**

## 🔧 Restricciones en Código

```sql
-- Un estudiante debe tener al menos una materia
ALTER TABLE ESTUDIANTES_MATERIAS 
ADD CONSTRAINT min_materias 
CHECK (estudiante_id IS NOT NULL);

-- Un estudiante no puede tomar más de 8 materias
ALTER TABLE ESTUDIANTES_MATERIAS 
ADD CONSTRAINT max_materias 
CHECK (COUNT(*) <= 8);
```

---

**¿Entendiste?** ¡Perfecto! Ahora sabes exactamente cuántos elementos se pueden relacionar entre sí. En la siguiente lección veremos qué tipo de información puede almacenar cada campo. 🔢