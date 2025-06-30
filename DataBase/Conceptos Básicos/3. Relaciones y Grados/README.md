# 🔗 Relaciones y Grados

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
