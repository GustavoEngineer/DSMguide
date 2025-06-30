# 🔢 Cardinalidad

### **Definición:**
Número de instancias de una entidad que pueden asociarse con una instancia de otra entidad.

### **Notaciones:**

#### **Notación (min, max):**
- **(0,1)**: Cero o uno
- **(1,1)**: Exactamente uno
- **(0,N)**: Cero o muchos
- **(1,N)**: Uno o muchos

#### **Ejemplos Hamilton:**

**1. ACTOR - PERSONAJE:**
```
ACTOR (1,N) ----INTERPRETA---- (1,1) PERSONAJE
```
- Un actor puede interpretar varios personajes (1,N)
- Un personaje es interpretado por exactamente un actor (1,1)

**2. PERSONAJE - CANCIÓN:**
```
PERSONAJE (0,N) ----CANTA---- (1,N) CANCIÓN
```
- Un personaje puede cantar varias canciones (0,N)
- Una canción puede ser cantada por varios personajes (1,N)

**3. ACTOR - INSTRUMENTO:**
```
ACTOR (0,N) ----TOCA---- (0,N) INSTRUMENTO
```
- Un actor puede tocar varios instrumentos (0,N)
- Un instrumento puede ser tocado por varios actores (0,N)

### **Restricciones de Cardinalidad:**

```sql
-- Ejemplo: Un actor debe interpretar al menos un personaje
ALTER TABLE PERSONAJES 
ADD CONSTRAINT min_personajes 
CHECK (actor_id IS NOT NULL);

-- Ejemplo: Una canción no puede durar más de 10 minutos
ALTER TABLE CANCIONES 
ADD CONSTRAINT max_duracion 
CHECK (duracion <= '00:10:00');
```

---