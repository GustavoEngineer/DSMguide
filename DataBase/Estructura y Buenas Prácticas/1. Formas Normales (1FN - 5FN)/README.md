# 📋 Formas Normales (1FN - 5FN)

Las Formas Normales son reglas progresivas para organizar datos y eliminar redundancia. Cada forma normal resuelve un problema específico diferente.

### 8.1 Primera Forma Normal (1FN)

**🎯 Regla:** Cada celda debe contener UN solo valor atómico.

#### **❌ Problema - No cumple 1FN:**
| Actor | Personajes | Canciones |
|-------|------------|-----------|
| Lin-Manuel | Hamilton, John Laurens | Wait for It, Satisfied |
| Leslie | Aaron Burr | Wait for It, Dear Theodosia |

#### **✅ Solución - Cumple 1FN:**
| Actor | Personaje | Cancion |
|-------|-----------|---------|
| Lin-Manuel | Hamilton | Wait for It |
| Lin-Manuel | Hamilton | Satisfied |
| Lin-Manuel | John Laurens | Wait for It |
| Leslie | Aaron Burr | Wait for It |
| Leslie | Aaron Burr | Dear Theodosia |

**💡 Memoria:** "Una cosa por celda"

### 8.2 Segunda Forma Normal (2FN)

**🎯 Regla:** Cumple 1FN + Los atributos no-clave deben depender COMPLETAMENTE de la clave primaria.

#### **❌ Problema - No cumple 2FN:**
Clave primaria: (Actor + Personaje)

| Actor | Personaje | Pais_Actor | Duracion_Actuacion |
|-------|-----------|------------|-------------------|
| Lin-Manuel | Hamilton | Estados Unidos | 2h 30min |
| Lin-Manuel | John Laurens | Estados Unidos | 45min |

**Problema:** `Pais_Actor` solo depende de `Actor`, no de (Actor + Personaje)

#### **✅ Solución - Cumple 2FN:**

**Tabla ACTORES:**
| Actor | Pais_Actor |
|-------|------------|
| Lin-Manuel | Estados Unidos |
| Leslie | Estados Unidos |

**Tabla INTERPRETACIONES:**
| Actor | Personaje | Duracion_Actuacion |
|-------|-----------|-------------------|
| Lin-Manuel | Hamilton | 2h 30min |
| Lin-Manuel | John Laurens | 45min |

**💡 Memoria:** "Todo depende de la clave completa"

### 8.3 Tercera Forma Normal (3FN)

**🎯 Regla:** Cumple 2FN + No debe haber dependencias transitivas (A→B→C).

#### **❌ Problema - No cumple 3FN:**
| Actor | Pais_Actor | Continente_Pais |
|-------|------------|-----------------|
| Lin-Manuel | Estados Unidos | América del Norte |
| Leslie | Estados Unidos | América del Norte |

**Problema:** Actor → Pais_Actor → Continente_Pais (dependencia transitiva)

#### **✅ Solución - Cumple 3FN:**

**Tabla ACTORES:**
| Actor | Pais_Actor |
|-------|------------|
| Lin-Manuel | Estados Unidos |
| Leslie | Estados Unidos |

**Tabla PAISES:**
| Pais | Continente |
|------|------------|
| Estados Unidos | América del Norte |
| Francia | Europa |

**💡 Memoria:** "Rompe las cadenas"

### 8.4 Forma Normal Boyce-Codd (FNBC)

**🎯 Regla:** Cumple 3FN + Para cada dependencia funcional, el determinante debe ser superclave.

#### **❌ Problema - No cumple FNBC:**
| Estudiante | Profesor | Materia |
|------------|----------|---------|
| María | Lin-Manuel | Composición |
| Juan | Lin-Manuel | Composición |

**Problema:** Profesor → Materia, pero "Profesor" no es superclave.

#### **✅ Solución - Cumple FNBC:**

**Tabla PROFESOR_MATERIA:**
| Profesor | Materia |
|----------|---------|
| Lin-Manuel | Composición |
| Daveed | Actuación |

**Tabla ESTUDIANTE_PROFESOR:**
| Estudiante | Profesor |
|------------|----------|
| María | Lin-Manuel |
| Juan | Lin-Manuel |

**💡 Memoria:** "Solo los jefes mandan"

### 8.5 Cuarta Forma Normal (4FN)

**🎯 Regla:** Cumple FNBC + No debe tener dependencias multivaluadas independientes.

#### **❌ Problema - No cumple 4FN:**
| Actor | Habilidad | Instrumento |
|-------|-----------|-------------|
| Lin-Manuel | Canto | Piano |
| Lin-Manuel | Canto | Guitarra |
| Lin-Manuel | Composición | Piano |
| Lin-Manuel | Composición | Guitarra |

**Problema:** Habilidades e instrumentos son independientes, pero se mezclan innecesariamente.

#### **✅ Solución - Cumple 4FN:**

**Tabla ACTOR_HABILIDAD:**
| Actor | Habilidad |
|-------|-----------|
| Lin-Manuel | Canto |
| Lin-Manuel | Composición |

**Tabla ACTOR_INSTRUMENTO:**
| Actor | Instrumento |
|-------|-------------|
| Lin-Manuel | Piano |
| Lin-Manuel | Guitarra |

**💡 Memoria:** "Separa listas independientes"

### 8.6 Quinta Forma Normal (5FN)

**🎯 Regla:** Cumple 4FN + No debe tener dependencias de unión no triviales.

#### **❌ Problema - No cumple 5FN:**
| Actor | Personaje | Escena |
|-------|-----------|--------|
| Lin-Manuel | Hamilton | Acto 1 |
| Lin-Manuel | Hamilton | Acto 2 |
| Leslie | Burr | Acto 1 |
| Leslie | Burr | Acto 2 |

**Problema:** Esta información se puede reconstruir perfectamente desde tablas separadas.

#### **✅ Solución - Cumple 5FN:**

**Tabla ACTOR_PERSONAJE:**
| Actor | Personaje |
|-------|-----------|
| Lin-Manuel | Hamilton |
| Leslie | Burr |

**Tabla PERSONAJE_ESCENA:**
| Personaje | Escena |
|-----------|--------|
| Hamilton | Acto 1 |
| Hamilton | Acto 2 |
| Burr | Acto 1 |
| Burr | Acto 2 |

**Tabla ACTOR_ESCENA:**
| Actor | Escena |
|-------|--------|
| Lin-Manuel | Acto 1 |
| Lin-Manuel | Acto 2 |
| Leslie | Acto 1 |
| Leslie | Acto 2 |

**💡 Memoria:** "No guardes lo que puedes calcular"

---

