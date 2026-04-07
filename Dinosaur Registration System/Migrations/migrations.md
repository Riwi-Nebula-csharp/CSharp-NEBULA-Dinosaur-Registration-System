# 📦 Migrations - Entity Framework Core (PostgreSQL)

Esta carpeta contiene las migraciones generadas por Entity Framework Core.
Las migraciones permiten crear y actualizar la base de datos a partir de los modelos del proyecto.

---

## ⚙️ Requisitos

Antes de ejecutar migraciones, asegúrate de tener:

### 🔹 1. .NET EF CLI instalado

```bash
dotnet tool install --global dotnet-ef
```

---

### 🔹 2. Paquetes necesarios (PostgreSQL)

```bash
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 9.0.0
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 9.0.0
```

---

## ⚙️ Configuración básica

En tu `AppDbContext.cs`, debes configurar PostgreSQL:

```csharp
options.UseNpgsql("Host=localhost;Database=dinosaurdb;Username=postgres;Password=1234");
```

---

## ⚙️ Comandos básicos (usando .NET CLI)

### 🔹 Crear una nueva migración

```bash
dotnet ef migrations add NombreDeLaMigracion
```

Ejemplo:

```bash
dotnet ef migrations add InitialCreate
```

---

### 🔹 Aplicar migraciones a la base de datos

```bash
dotnet ef database update
```

---

### 🔹 Eliminar la última migración (si aún no se ha aplicado)

```bash
dotnet ef migrations remove
```

---

### 🔹 Ver lista de migraciones

```bash
dotnet ef migrations list
```

---

## 🧠 Flujo recomendado

1. Realizar cambios en los modelos (`Models/`)
2. Crear una nueva migración:

```bash
dotnet ef migrations add NombreDelCambio
```

3. Aplicar los cambios:

```bash
dotnet ef database update
```

---

## ⚠️ Notas importantes

* No modificar manualmente los archivos dentro de esta carpeta.
* Las migraciones representan el historial de la base de datos.
* Si ocurre un error, verificar:

    * Cadena de conexión
    * Configuración del DbContext
    * Instalación de PostgreSQL
    * Proyecto correcto seleccionado

---

## ✅ Buenas prácticas

* Usar nombres claros en las migraciones:

    * `InitialCreate`
    * `AddDinosaurTable`
    * `UpdateFields`
* Crear una migración por cada cambio importante.
* Mantener sincronizada la base de datos con el modelo.

---
