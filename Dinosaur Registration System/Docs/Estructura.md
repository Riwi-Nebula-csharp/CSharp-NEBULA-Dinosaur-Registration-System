# 🦖 NeoGenesis Park — Estructura del Proyecto

> Dinosaur Registration System  
> Proyecto C# (.NET) organizado bajo el patrón de separación de responsabilidades

---

## Árbol de Carpetas y Archivos

```
Dinosaur Registration System/
│
├── bin/
├── obj/
│
├── Data/
├── Migrations/
├── Models/
│
├── Services/
├── Utils/
│
├── Docs/
│
├── DinosaurRegistrationSystem.csproj
├── Program.cs
└── README.md
```

---

## Descripción de cada carpeta y archivo

### 📁 `Data/`
Capa de **acceso a datos** del proyecto.  
Aquí se define el `DbContext` de Entity Framework Core, que representa la conexión con la base de datos y expone los `DbSet` de las entidades (por ejemplo, `DbSet<Dinosaurio>`).

**Contenido típico:**
- `AppDbContext.cs` — clase principal que hereda de `DbContext`
- Configuraciones de entidades con Fluent API (restricciones, índices únicos, etc.)

---

### 📁 `Migrations/`
Carpeta administrada automáticamente por **Entity Framework Core**.  
Contiene los archivos de migración generados al ejecutar:

```bash
Add-Migration InitialCreate
Update-Database
```

Cada migración es un snapshot de los cambios en el esquema de la base de datos, permitiendo versionarlo junto al código fuente.

**Contenido típico:**
- `YYYYMMDDHHMMSS_InitialCreate.cs` — migración inicial con la creación de tablas
- `AppDbContextModelSnapshot.cs` — estado actual del modelo

---

### 📁 `Models/`
Capa de **modelos de dominio**.  
Contiene las clases que representan las entidades del sistema, es decir, los dinosaurios y cualquier otro objeto de negocio.

**Contenido típico:**
- `Dinosaurio.cs` — clase con las propiedades del espécimen (FirstName, LastName, Username, Email, Zona, Sector, Edad, Tipo, etc.)

---

### 📁 `Services/`
Capa de **lógica de negocio**.  
Contiene las clases de servicio que implementan las operaciones del sistema: inserción, consulta, actualización y eliminación de dinosaurios.

Esta capa actúa como intermediaria entre `Program.cs` (presentación) y `Data/` (acceso a datos), aplicando las validaciones y reglas de negocio definidas en el proyecto.

**Contenido típico:**
- `DinosaurioService.cs` — métodos CRUD y consultas LINQ

---

### 📁 `Utils/`
Carpeta de **utilidades y helpers** reutilizables en todo el proyecto.  
Agrupa funciones auxiliares que no pertenecen a ninguna capa específica pero son usadas transversalmente.

**Contenido típico:**
- Validadores de formato (email, campos vacíos)
- Helpers de consola (mensajes de confirmación, formateo de salida)
- Constantes del sistema

---

### 📁 `Docs/`
Carpeta de **documentación** del proyecto.  
Puede contener archivos de referencia, diagramas exportados, o ser el directorio raíz del sitio generado con **Docusaurus**.

**Contenido típico:**
- Diagramas de flujo, casos de uso y clases (en formato imagen o `.drawio`)
- Archivos fuente de la documentación Docusaurus

### 📄 `Program.cs`
**Punto de entrada** de la aplicación.  
Contiene el método `Main` desde donde se inicializa el sistema, se configura el `DbContext` y se invoca el menú principal o los flujos de interacción con el usuario.

---

### 📄 `README.md`
Archivo de **presentación del repositorio**.  
Describe el proyecto, cómo configurarlo, cómo ejecutarlo y cualquier información relevante para quien clone el repositorio.

---

## Resumen de capas

| Carpeta | Responsabilidad | Patrón |
|---|---|---|
| `Models/` | Entidades del dominio | Domain Model |
| `Data/` | Contexto y acceso a BD | Repository / DbContext |
| `Migrations/` | Versionado del esquema | EF Core Migrations |
| `Services/` | Lógica de negocio y LINQ | Service Layer |
| `Utils/` | Helpers y validaciones | Utility / Helper |
| `Docs/` | Documentación del proyecto | — |
| `Program.cs` | Punto de entrada | Entry Point |

---

> *Estructura basada en el proyecto **Dinosaur Registration System** — NeoGenesis Park.*