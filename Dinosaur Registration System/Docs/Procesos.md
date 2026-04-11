# 🦖 NeoGenesis Park — Documentación Técnica del Sistema

> Sistema de Registro y Gestión de Dinosaurios  
> Proyecto académico basado en C# con Entity Framework Core y LINQ

---

## Tabla de Contenidos

1. [Contexto del Proyecto](#1-contexto-del-proyecto)
2. [Registro de Dinosaurio](#2-registro-de-dinosaurio)
3. [Módulo de Consultas](#3-módulo-de-consultas)
4. [Módulo de Eliminación](#4-módulo-de-eliminación)
5. [Módulo de Actualización](#5-módulo-de-actualización)
6. [Módulo de Inserción](#6-módulo-de-inserción)
7. [Reglas de Negocio](#7-reglas-de-negocio)
8. [Consultas con LINQ](#8-consultas-con-linq)
9. [Requisitos de Implementación con EF Core](#9-requisitos-de-implementación-con-ef-core)
10. [Buenas Prácticas](#10-buenas-prácticas)
11. [Entregables](#11-entregables)

---

## 1. Contexto del Proyecto

**NeoGenesis Park** es una isla científica ficticia donde investigadores han logrado recrear dinosaurios mediante ingeniería genética. Para garantizar el control, monitoreo y estudio de cada espécimen, se requiere un sistema de gestión que registre información básica de cada dinosaurio dentro del parque.

Cada dinosaurio posee una **identidad única** dentro del sistema que permite rastrearlo, estudiarlo y controlarlo de forma individual.

---

## 2. Registro de Dinosaurio

### Campos obligatorios

Al momento de registrar un dinosaurio en el sistema, los siguientes datos son **requeridos obligatoriamente**:

| Campo | Descripción en el contexto del sistema |
|---|---|
| `First Name` | Nombre asignado al espécimen |
| `Last Name` | Clasificación científica o especie |
| `Username` | Identificador único del espécimen |
| `Email` | Código de registro único del laboratorio |

> **Nota:** El nombre que se le asigna a cada campo es opcional y puede variar según el nivel de ambientación que se desee dar al sistema. Los demás datos son opcionales y pueden completarse en un momento posterior.

---

## 3. Módulo de Consultas

Este módulo agrupa todas las operaciones de **lectura y visualización** de información del sistema. Permite obtener reportes generales, filtros por criterios específicos y conteos estadísticos.

### 3.1 Consultas individuales y generales

| Proceso | Descripción |
|---|---|
| Listar todos los dinosaurios | Genera un reporte general con todos los especímenes registrados |
| Ver detalle por Id | Muestra los datos completos de un dinosaurio buscándolo por su identificador interno |
| Ver detalle por código de registro | Muestra los datos completos de un dinosaurio buscándolo por su email (código de laboratorio) |

### 3.2 Consultas filtradas

| Proceso | Descripción |
|---|---|
| Listar por zona | Muestra todos los dinosaurios que habitan una zona específica del parque (equivalente a ciudad) |
| Listar por sector | Muestra todos los dinosaurios de un sector del parque (equivalente a país) |
| Listar por edad | Muestra todos los dinosaurios que superan una edad específica ingresada |
| Listar por tipo | Filtra dinosaurios según su clasificación alimentaria (carnívoro / herbívoro) |

### 3.3 Consultas de reporte y estadísticas

| Proceso | Descripción |
|---|---|
| Reporte científico | Muestra un listado con nombres completos y códigos de registro de todos los especímenes |
| Total registrados | Cuenta el número total de dinosaurios en el sistema |
| Conteo por zona | Muestra cuántos dinosaurios hay en cada zona del parque |
| Conteo por sector | Muestra cuántos dinosaurios hay en cada sector del parque |

### 3.4 Consultas de estado y alertas

| Proceso | Descripción |
|---|---|
| Sin dispositivo de rastreo | Lista los dinosaurios que no tienen teléfono (rastreador) registrado |
| Sin ubicación registrada | Lista los dinosaurios que no tienen dirección (ubicación) en el sistema |
| Últimos registrados | Muestra los especímenes más recientemente añadidos, ordenados por fecha de creación |
| Ordenados alfabéticamente | Lista todos los dinosaurios ordenados por especie en orden alfabético |

---

## 4. Módulo de Eliminación

Este módulo permite **dar de baja** un dinosaurio del sistema de forma permanente. Soporta dos métodos de búsqueda antes de proceder con la eliminación.

### Procesos disponibles

| Proceso | Descripción |
|---|---|
| Eliminar por Id | Busca y elimina el registro del dinosaurio usando su identificador interno |
| Eliminar por código de registro | Busca y elimina el registro usando el email (código de laboratorio) |

### Flujo del proceso de eliminación

```
1. El usuario ingresa el criterio de búsqueda (Id o Email).
2. El sistema localiza el dinosaurio.
3. El sistema muestra el mensaje de confirmación:
   "¿Está seguro de eliminar este dinosaurio? (S/N)"
4. Si el usuario confirma (S):
   → El dinosaurio es eliminado del sistema.
   → El sistema muestra un mensaje confirmando la eliminación exitosa.
5. Si el usuario cancela (N):
   → El proceso se cancela sin modificar el sistema.
```

---

## 5. Módulo de Actualización

Este módulo permite **modificar los datos** de un dinosaurio ya registrado en el sistema.

### Procesos disponibles

| Proceso | Descripción |
|---|---|
| Actualizar datos generales | Permite modificar cualquiera de los campos del dinosaurio (nombre, especie, zona, sector, edad, etc.) |
| Actualizar código de seguridad | Permite cambiar la contraseña del registro, solicitando una confirmación adicional antes de guardar |

### Flujo del proceso de actualización

```
1. El usuario selecciona el campo o los campos que desea modificar.
2. El sistema solicita el nuevo valor.
3. Para la contraseña: el sistema solicita confirmación del nuevo valor.
4. Se guardan los cambios.
5. El sistema muestra un mensaje confirmando que los datos fueron actualizados correctamente.
```

---

## 6. Módulo de Inserción

Este módulo gestiona el **registro de nuevos dinosaurios** en el sistema.

### Datos solicitados al registrar

| Campo | Tipo |
|---|---|
| Nombre | Obligatorio |
| Especie | Obligatorio |
| Identificador único (username) | Obligatorio |
| Código de registro (email) | Obligatorio |

### Flujo del proceso de inserción

```
1. El usuario ingresa los datos del nuevo dinosaurio.
2. El sistema valida que el email no exista previamente.
   → Si existe: rechaza el registro con un mensaje de error.
3. El sistema valida que el username no exista previamente.
   → Si existe: rechaza el registro con un mensaje de error.
4. Si todas las validaciones pasan:
   → El dinosaurio es creado en el sistema.
   → El sistema muestra un mensaje confirmando la creación exitosa.
```

### Validaciones en la inserción

- El **código de registro (email)** debe ser único en el sistema.
- El **identificador (username)** debe ser único en el sistema.
- Los campos obligatorios no pueden enviarse vacíos.

---

## 7. Reglas de Negocio

Estas reglas aplican a todo el sistema y deben respetarse en todos los módulos:

| Regla | Descripción |
|---|---|
| Username único | No pueden existir dos dinosaurios con el mismo identificador |
| Email único | No pueden existir dos dinosaurios con el mismo código de registro |
| Campos obligatorios | Los campos requeridos nunca pueden estar vacíos |
| Formato de email | El código de registro debe tener un formato de correo electrónico válido |
| Edad válida | La edad del espécimen debe ser un valor mayor o igual a 0 |

---

## 8. Consultas con LINQ

El sistema **debe implementar LINQ** (Language Integrated Query) para todas las operaciones de consulta. A continuación se detallan los tipos de consultas requeridos:

### 8.1 Consultas básicas

```csharp
// Listar todos los dinosaurios
var todos = context.Dinosaurios.ToList();

// Filtrar por zona
var porZona = context.Dinosaurios.Where(d => d.Zona == zona).ToList();

// Filtrar por sector
var porSector = context.Dinosaurios.Where(d => d.Sector == sector).ToList();

// Filtrar por edad
var mayoresDe = context.Dinosaurios.Where(d => d.Edad > edad).ToList();

// Filtrar por tipo (carnívoro/herbívoro)
var porTipo = context.Dinosaurios.Where(d => d.Tipo == tipo).ToList();
```

### 8.2 Proyecciones

```csharp
// Nombre completo + código de registro para reporte científico
var reporte = context.Dinosaurios
    .Select(d => new { NombreCompleto = d.FirstName + " " + d.LastName, CodigoRegistro = d.Email })
    .ToList();
```

### 8.3 Ordenamientos

```csharp
// Ordenar por fecha de registro (más recientes primero)
var recientes = context.Dinosaurios.OrderByDescending(d => d.FechaCreacion).ToList();

// Ordenar alfabéticamente por especie
var alfabetico = context.Dinosaurios.OrderBy(d => d.LastName).ToList();
```

### 8.4 Agrupaciones

```csharp
// Contar dinosaurios por sector
var porSector = context.Dinosaurios
    .GroupBy(d => d.Sector)
    .Select(g => new { Sector = g.Key, Total = g.Count() })
    .ToList();

// Contar dinosaurios por zona
var porZona = context.Dinosaurios
    .GroupBy(d => d.Zona)
    .Select(g => new { Zona = g.Key, Total = g.Count() })
    .ToList();
```

### 8.5 Filtros avanzados

```csharp
// Sin dispositivo de rastreo (teléfono nulo o vacío)
var sinRastreador = context.Dinosaurios
    .Where(d => string.IsNullOrEmpty(d.Telefono))
    .ToList();

// Sin ubicación registrada (dirección nula o vacía)
var sinUbicacion = context.Dinosaurios
    .Where(d => string.IsNullOrEmpty(d.Direccion))
    .ToList();

// Recientemente registrados (últimos N)
var ultimos = context.Dinosaurios
    .OrderByDescending(d => d.FechaCreacion)
    .Take(N)
    .ToList();
```

---

## 9. Requisitos de Implementación con EF Core

El sistema debe construirse sobre **Entity Framework Core** siguiendo la siguiente estructura mínima:

### Componentes requeridos

| Componente | Descripción |
|---|---|
| `DbContext` | Clase principal que gestiona la conexión con la base de datos |
| `DbSet<Dinosaurio>` | Representa la tabla de dinosaurios en la base de datos |
| Configuración de entidades | Definición de restricciones, tipos de datos y relaciones mediante `Fluent API` o `Data Annotations` |
| Validaciones de unicidad | Configurar índices únicos para `Username` y `Email` |

### Migraciones

Para inicializar la base de datos se deben ejecutar los siguientes comandos en la consola del Administrador de paquetes:

```bash
# Crear la migración inicial
Add-Migration InitialCreate

# Aplicar la migración a la base de datos
Update-Database
```

---

## 10. Buenas Prácticas

El proyecto debe aplicar las siguientes buenas prácticas de desarrollo de software:

| Práctica | Descripción |
|---|---|
| Código limpio | Métodos cortos, nombres descriptivos, sin código duplicado |
| Nombres consistentes | Usar convenciones de nomenclatura de C# (PascalCase para clases y métodos, camelCase para variables) |
| Separación de responsabilidades | Dividir el proyecto en capas: datos, lógica de negocio y presentación |

---

## 11. Entregables

El estudiante debe presentar los siguientes artefactos al finalizar el proyecto:

| # | Entregable | Descripción |
|---|---|---|
| 1 | Diagrama de Flujo | Representación gráfica del flujo de los procesos principales |
| 2 | Diagrama de Casos de Uso | Interacciones entre los actores y el sistema |
| 3 | Diagrama de Clases | Estructura de las entidades y sus relaciones |
| 4 | Código fuente | Proyecto funcional, organizado en carpetas según responsabilidades |
| 5 | Evidencia en Azure DevOps o Jira | Tablero con las tareas del proyecto gestionadas durante el desarrollo |
| 6 | Repositorio en GitHub | Proyecto versionado con **Conventional Commits** |
| 7 | Documentación en Docusaurus 🦖 | Sitio de documentación generado con Docusaurus |

---

> *Documentación generada a partir del Gist original de [JARV005](https://gist.github.com/JARV005/668025257bfae4e837d03f11812098e6) — NeoGenesis Park System.*