# 🦖 Dinosaur Registration System — NeoGenesis Park

<div align="center">

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)
![EF Core](https://img.shields.io/badge/Entity_Framework_Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![LINQ](https://img.shields.io/badge/LINQ-blue?style=for-the-badge)
![GitHub](https://img.shields.io/badge/GitHub-181717?style=for-the-badge&logo=github&logoColor=white)

**Sistema de gestión y registro de especímenes recreados mediante ingeniería genética en NeoGenesis Park.**


</div>

---

## 📋 Tabla de Contenidos

- [Sobre el Proyecto](#-sobre-el-proyecto)
- [Tecnologías](#-tecnologías)
- [Estructura del Proyecto](#-estructura-del-proyecto)
- [Requisitos Previos](#-requisitos-previos)
- [Instalación y Configuración](#-instalación-y-configuración)
- [Uso](#-uso)
- [Módulos del Sistema](#-módulos-del-sistema)
- [Documentación](#-documentación)
- [Conventional Commits](#-conventional-commits)
- [Autor](#-autor)

---

## 🌋 Sobre el Proyecto

**NeoGenesis Park** es una isla científica donde investigadores han logrado recrear dinosaurios mediante ingeniería genética. Este sistema permite registrar, gestionar, monitorear y controlar cada espécimen dentro del parque de forma eficiente y segura.

### ¿Qué hace el sistema?

- ✅ Registra dinosaurios con identidad única en el sistema
- ✅ Permite consultar, filtrar y ordenar especímenes por múltiples criterios
- ✅ Gestiona actualizaciones y bajas de registros con validaciones
- ✅ Genera reportes científicos del estado del parque
- ✅ Detecta dinosaurios sin rastreador o sin ubicación registrada

---

## 🛠️ Tecnologías

| Tecnología | Versión | Uso |
|---|---|---|
| C# | 12 | Lenguaje principal |
| .NET | 8.0 | Framework de la aplicación |
| Entity Framework Core | 8.x | ORM y acceso a base de datos |
| LINQ | — | Consultas y filtros de datos |
| MySQL | — | Motor de base de datos |

---

## 📁 Estructura del Proyecto

```
Dinosaur Registration System/
│
├── 📁 Data/               # DbContext y configuración de EF Core
├── 📁 Migrations/         # Migraciones de base de datos
├── 📁 Models/             # Entidades del dominio (Dinosaurio)
├── 📁 Services/           # Lógica de negocio y consultas LINQ
├── 📁 Utils/              # Validadores y helpers reutilizables
├── 📁 Docs/               # Diagramas y documentación
│
├── 📄 Program.cs          # Punto de entrada de la aplicación
├── 📄 DinosaurRegistrationSystem.csproj
└── 📄 README.md
```

---

## ✅ Requisitos Previos

Antes de ejecutar el proyecto, asegúrate de tener instalado:

- Pomelo.EntityFrameworkCore.Mysql
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.Tools

---

## ⚙️ Instalación y Configuración

### 1. Clonar el repositorio

```bash
git clone https://github.com/Riwi-Nebula-csharp/CSharp-NEBULA-Dinosaur-Registration-System.git
cd DinosaurRegistrationSystem
```

### 2. Restaurar dependencias

```bash
dotnet restore
```

### 3. Configurar la cadena de conexión

En el archivo `AppDbContext.cs`, configura tu cadena de conexión:

```
  "Server=localhost;Database=NeoGenesisDB;Trusted_Connection=True;"
```

### 4. Aplicar las migraciones

```bash
# En la Consola del Administrador de Paquetes (Visual Studio)
Add-Migration InitialCreate
Update-Database

# O con la CLI de .NET
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 5. Ejecutar el proyecto

```bash
dotnet run
```


## 🧩 Módulos del Sistema

### 🔍 Consultas
Permite listar todos los especímenes, filtrar por zona, sector, edad y tipo, generar reportes científicos y detectar dinosaurios sin rastreador o sin ubicación.

### ➕ Inserción
Registra nuevos dinosaurios validando unicidad de `username` y `email` antes de guardar.

### ✏️ Actualización
Modifica cualquier dato del dinosaurio, incluyendo cambio de contraseña con confirmación.

### 🗑️ Eliminación
Elimina un espécimen por `Id` o por `email`, con confirmación previa del usuario.

---

## 📚 Documentación

La documentación completa del sistema se encuentra en la carpeta `/Docs` y en el sitio de Docusaurus del proyecto:

| Documento | Descripción |
|---|---|
| [`Docs/DiagramaFlujo`](./Docs/) | Diagrama de flujo de los procesos principales |
| [`Docs/CasosDeUso`](./Docs/) | Diagrama de casos de uso del sistema |
| [`Docs/DiagramaClases`](./Docs/) | Estructura de entidades y relaciones |
| [Sitio Docusaurus 🦖](https://nebula.andrescortes.dev/) | Documentación completa navegable |

---

## 📝 Conventional Commits

Este proyecto sigue la especificación de [Conventional Commits](https://www.conventionalcommits.org/):

| Prefijo | Uso |
|---|---|
| `feat:` | Nueva funcionalidad |
| `fix:` | Corrección de errores |
| `docs:` | Cambios en documentación |
| `refactor:` | Refactorización sin cambiar funcionalidad |
| `chore:` | Tareas de mantenimiento |

**Ejemplos:**
```bash
git commit -m "feat: agregar módulo de consulta por zona"
git commit -m "fix: validar unicidad de email en inserción"
git commit -m "docs: actualizar README con instrucciones de migración"
```

<div align="center">

Hecho con 🦕 para **NeoGenesis Park**

</div>