# 📊 Entidades y Atributos

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
