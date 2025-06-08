
# 📝 Guía Actualizada para Crear y Gestionar Repositorios Git desde la Consola con GitHub CLI

## 📌 Objetivo

Esta guía te enseña a **crear un repositorio en GitHub** desde la consola utilizando **GitHub CLI (gh)**, **inicializar tu repositorio local con Git**, y **subir tu proyecto** al repositorio remoto en GitHub, todo sin interfaces gráficas.

---

## Índice

1. [Instalación de Git y GitHub CLI](#1-instalación-de-git-y-github-cli)
   - [Instalar Git](#11-instalar-git)
   - [Instalar GitHub CLI (gh)](#12-instalar-github-cli-gh)
2. [Crear tu Carpeta de Proyecto y Inicializar el Repositorio Local](#2-crear-tu-carpeta-de-proyecto-y-inicializar-el-repositorio-local)
   - [Crear las Carpetas del Proyecto](#21-crear-las-carpetas-del-proyecto)
   - [Inicializar el Repositorio Git Local](#22-inicializar-el-repositorio-git-local)
   - [Crear Archivos y Realizar el Primer Commit](#23-crear-archivos-y-realizar-el-primer-commit)
3. [Crear el Repositorio en GitHub con GitHub CLI](#3-crear-el-repositorio-en-github-con-github-cli)
   - [Autenticarse en GitHub](#31-autenticarse-en-github)
   - [Crear el Repositorio en GitHub](#32-crear-el-repositorio-en-github)
4. [Vincular y Subir el Repositorio Local a GitHub](#4-vincular-y-subir-el-repositorio-local-a-github)
   - [Vincular el Repositorio Local al Remoto](#41-vincular-el-repositorio-local-al-remoto)
   - [Subir los Archivos al Repositorio Remoto](#42-subir-los-archivos-al-repositorio-remoto)
5. [Comandos Básicos de Git](#5-comandos-básicos-de-git)
   - [Ver el Estado del Repositorio](#51-ver-el-estado-del-repositorio)
   - [Ver el Historial de Commits](#52-ver-el-historial-de-commits)
   - [Trabajar con Ramas](#53-trabajar-con-ramas)
   - [Fusionar Ramas](#54-fusionar-ramas)
6. [Uso de .gitignore](#6-uso-de-gitignore)
7. [Eliminar un Repositorio Local](#7-eliminar-un-repositorio-local)
8. [📍 Conclusión](#conclusión)

---

## 1. Instalación de Git y GitHub CLI

### 1.1 **Instalar Git**

Si no tienes **Git** instalado, sigue los siguientes pasos:

- **Windows**: [Descargar Git para Windows](https://git-scm.com/download/win)
- **Linux**: Usa el siguiente comando:
  ```bash
  sudo apt install git  # Ubuntu/Debian
  sudo yum install git  # Fedora
  ```
- **macOS**:
  ```bash
  brew install git
  ```

Verifica que Git se haya instalado correctamente con:
```bash
git --version
```

### 1.2 **Instalar GitHub CLI (gh)**

GitHub CLI te permite interactuar con GitHub desde la consola.

- **Windows**: `winget install --id GitHub.cli`
- **Linux**: `sudo apt install gh`
- **macOS**: `brew install gh`

Verifica que GitHub CLI esté instalado:
```bash
gh --version
```

---

## 2. Crear tu Carpeta de Proyecto y Inicializar el Repositorio Local

### 2.1 **Crear las Carpetas del Proyecto**

Primero, crea una carpeta para tu proyecto. Luego, entra en esa carpeta:
```bash
mkdir mi-proyecto
cd mi-proyecto
```

### 2.2 **Inicializar el Repositorio Git Local**

Dentro de la carpeta de tu proyecto, inicializa el repositorio local con:
```bash
git init
```
Esto crea un repositorio Git vacío en tu carpeta.

### 2.3 **Crear Archivos y Realizar el Primer Commit**

1. Crea un archivo de ejemplo (`README.md`):
   ```bash
   echo "# Mi Proyecto" > README.md
   ```

2. Agrega el archivo al área de preparación:
   ```bash
   git add .
   ```

3. Realiza el primer commit:
   ```bash
   git commit -m "Primer commit"
   ```

---

## 3. Crear el Repositorio en GitHub con GitHub CLI

### 3.1 **Autenticarse en GitHub**

Para autenticarte con GitHub CLI, ejecuta:
```bash
gh auth login
```
Sigue las instrucciones para iniciar sesión en GitHub desde la consola.

### 3.2 **Crear el Repositorio en GitHub**

Una vez autenticado, crea un repositorio en GitHub con el siguiente comando:
```bash
gh repo create mi-repo --public --source=. --remote=origin --push
```
- `mi-repo`: Nombre del repositorio en GitHub.
- `--public`: Crea un repositorio público (puedes usar `--private` si prefieres que sea privado).
- `--source=.`: Usa el directorio actual como fuente para el repositorio.
- `--remote=origin`: Establece el repositorio remoto como origin.
- `--push`: Sube automáticamente los archivos iniciales al repositorio en GitHub.

---

## 4. Vincular y Subir el Repositorio Local a GitHub

### 4.1 **Vincular el Repositorio Local al Remoto**

Si no usaste `gh repo create`, vincula manualmente tu repositorio local con el remoto de GitHub:
```bash
git remote add origin https://github.com/tu-usuario/mi-repo.git
```

### 4.2 **Subir los Archivos al Repositorio Remoto**

Una vez que el repositorio local está vinculado al remoto, sube los archivos al repositorio en GitHub con:
```bash
git push -u origin main
```

---

## 5. Comandos Básicos de Git

### 5.1 **Ver el Estado del Repositorio**

Verifica qué archivos están modificados o listos para ser confirmados:
```bash
git status
```

### 5.2 **Ver el Historial de Commits**

Para ver todos los commits realizados:
```bash
git log
```
Para un historial más compacto:
```bash
git log --oneline --graph
```

### 5.3 **Trabajar con Ramas**

- **Crear una nueva rama**:
  ```bash
  git checkout -b nueva-rama
  ```

- **Cambiar a una rama existente**:
  ```bash
  git checkout nombre-de-rama
  ```

### 5.4 **Fusionar Ramas**

Para fusionar los cambios de una rama secundaria a la rama principal (`main`):

1. Cambia a la rama principal:
   ```bash
   git checkout main
   ```

2. Fusiona la rama secundaria:
   ```bash
   git merge nueva-rama
   ```

3. Sube los cambios:
   ```bash
   git push origin main
   ```

---

## 6. Uso de `.gitignore`

El archivo `.gitignore` le dice a Git qué archivos **no deben ser seguidos**. Crea este archivo en la raíz de tu proyecto y añade las siguientes líneas para un proyecto .NET:
```gitignore
# Build outputs
bin/
obj/

# Visual Studio files
.vs/
.vscode/

# User-specific files
*.user
*.suo
*.userosscache
*.sln.docstates

# NuGet packages
*.nupkg
packages/

# Resharper
_ReSharper*/

# Rider
.idea/

# Publish output
publish/

# Others
*.log
*.tmp
*.cache
```

---

## 7. Eliminar un Repositorio Local

Si necesitas eliminar el repositorio local:
```bash
cd ..
rm -rf mi-proyecto
```

---

## 📍 Conclusión

Con esta guía, ahora sabes cómo **crear un repositorio en GitHub** desde la consola usando **GitHub CLI**, **inicializar el repositorio local con Git**, y **subir tu proyecto a GitHub**. Todo esto sin interfaces gráficas, usando únicamente comandos de consola para tener un control completo de tu código.

---

### **Enlace para Descargar el Archivo Markdown**

He preparado el archivo `.md` con esta guía. Puedes **descargarlo** desde aquí:

[Descargar Guía Git y GitHub](sandbox:/mnt/data/Guia_Git_y_GitHub_Con_Indice.md)

---

Si tienes alguna pregunta adicional o necesitas más detalles, no dudes en preguntar. ¡Estoy aquí para ayudarte! 😊
