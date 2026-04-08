# 🧩 Distribución de tareas por integrante

---

## 👨‍💻 Integrante 1 — Backend & Base de Datos (EF Core)

**Responsabilidad principal:** Persistencia de datos

### 🛠️ Tareas:

* Crear el proyecto base en C#
* Configurar:

    * `DbContext`
    * `DbSet<Dinosaur>`
* Crear entidad `Dinosaur` con:

    * Id
    * FirstName
    * LastName
    * Username
    * Email
    * Edad
    * Tipo
    * Zona
    * Sector
    * Dirección
    * Teléfono
    * FechaCreación

### 📏 Reglas y validaciones:

* Configurar unicidad:

    * Username (**UNIQUE**)
    * Email (**UNIQUE**)
* Validaciones con Fluent API o Data Annotations

### 🗄️ Migraciones:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 📦 Entregable:

* Carpeta `Data/`
* Carpeta `Models/`
* Base de datos funcionando

---

## 👥 Integrantes 2 y 3 — Lógica de Negocio + Interfaz + Validaciones + CRUD

**Responsabilidad principal:** Implementar toda la lógica del sistema y la interacción con el usuario

---

### 🧠 Lógica de negocio (LINQ)

Crear:

* `Services/DinosaurService.cs`

Implementar:

#### 🔹 Consultas:

* Listar todos
* Buscar por Id
* Buscar por Email
* Filtrar por:

    * Zona
    * Sector
    * Edad
    * Tipo

#### 🔹 Proyecciones:

* Nombre completo + email

#### 🔹 Ordenamientos:

* Por fecha (últimos registrados)
* Alfabético por especie

#### 🔹 Agrupaciones:

* Conteo por zona
* Conteo por sector

#### 🔹 Filtros avanzados:

* Dinosaurios sin teléfono
* Dinosaurios sin dirección

#### 🔹 Conteos:

* Total de dinosaurios

---

### 🖥️ Interfaz + CRUD (consola)

Crear:

* `Program.cs`

Implementar:

#### 🔹 Inserción

* Registrar dinosaurio
* Validar:

    * Campos obligatorios
    * Email único
    * Username único

#### 🔹 Eliminación

* Eliminar por Id
* Eliminar por Email

Confirmación:

```
¿Está seguro de eliminar este dinosaurio? (S/N)
```

#### 🔹 Actualización

* Editar datos
* Cambiar contraseña (simulada)
* Mostrar confirmación

#### 🔹 Consultas

* Consumir métodos del `DinosaurService`

---

### ✅ Validaciones

Crear:

* `Utils/Validator.cs`

Validar:

* Campos vacíos
* Formato de email
* Edad ≥ 0
* Duplicados (username/email)

---

### 📦 Entregables:

* Carpeta `Services/`
* `Program.cs` funcional
* Flujo completo en consola
* Métodos LINQ funcionando correctamente

---

## 📊 Integrante 4 — Documentación + DevOps

**Responsabilidad principal:** Organización y entrega

---

### 📐 Diagramas:

* Diagrama de flujo
* Diagrama de casos de uso
* Diagrama de clases

Ubicación:

```
Docs/Diagrams/
```

---

### 📚 Documentación:

* Configurar documentación en Docusaurus
* Explicar:

    * Cómo ejecutar el proyecto
    * Estructura de carpetas
    * Funcionalidades

---

### 🔧 Control de versiones:

Repositorio en GitHub con:

* Conventional Commits:

    * `feat:`
    * `fix:`
    * `docs:`

---

### 📋 Gestión:

* Tablero en:

    * Azure DevOps o Jira

---

### 📦 Entregable:

* Documentación completa
* Evidencias del trabajo en equipo
* Proyecto listo para entrega

---

# ✅ Resumen

| Integrante | Responsabilidad         |
| ---------- | ----------------------- |
| 1          | Base de datos (EF Core) |
| 2          | Lógica + Interfaz       |
| 3          | Lógica + Interfaz       |
| 4          | Documentación + DevOps  |

---
