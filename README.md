# Sistema de Mantenimiento de Incidencias

Aplicación web ASP.NET Core MVC para la gestión de incidencias de mantenimiento: reporte, asignación, reparación, descarte y seguimiento con comentarios, desarrollada como proyecto grupal para la materia *Programación de Nuevas Tecnologías 1*.

## Descripción

El sistema permite a distintos roles de usuario gestionar el ciclo de vida completo de una incidencia (falla, avería o solicitud de mantenimiento):

1. Un **usuario** reporta una incidencia con título, descripción, categoría e imagen.
2. Un **encargado** la revisa y la asigna a un **técnico**, definiendo prioridad, complejidad y SLA (o la descarta con justificación).
3. El **técnico** realiza la reparación y registra fechas, costo y evidencia final.
4. Los usuarios involucrados pueden dejar **comentarios** durante todo el proceso.
5. Un **dashboard** permite visualizar y filtrar el estado general de las incidencias.

## Tecnologías

- **.NET 8** / ASP.NET Core MVC
- **Entity Framework Core 9** (SQL Server) con Code First y Migrations
- **Autenticación por cookies** (`Microsoft.AspNetCore.Authentication.Cookies`)
- **Sesión en memoria** para datos de contexto del usuario autenticado
- **Bootstrap** para la interfaz (Razor Views / `.cshtml`)

## Estructura del proyecto

```
Controllers/     Auth, User, Categoria, Incidencia, Comentario, Home
Models/          Entidades: User, Incidencia, Categoria, Comentario y enums (RolUsuario, EstadoIncidencia, Prioridad, Complejidad)
ViewModels/      Modelos para vistas específicas (asignación, reparación, evaluación, descarte, dashboard, login, etc.)
Views/           Vistas Razor organizadas por controlador
Context/         SistemaMantenimientoDBContext (DbContext de EF Core)
Migrations/      Historial de migraciones de la base de datos
wwwroot/         Archivos estáticos (css, js, imágenes subidas de incidencias, librerías)
```

### Roles de usuario (`RolUsuario`)
`administrador`, `encargado`, `tecnico`, `usuario`

### Estados de una incidencia (`EstadoIncidencia`)
`reportado` → `asignado` → `enReparacion` → `finalizado` (o `descartado`)

## Requisitos previos

- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- SQL Server (LocalDB, Express o instancia completa)
- (Opcional) [dotnet-ef](https://learn.microsoft.com/ef/core/cli/dotnet) para manejar migraciones: `dotnet tool install --global dotnet-ef`

## Configuración

1. Cloná el repositorio y ubicate en la carpeta del proyecto.
2. Configurá la cadena de conexión en `appsettings.json` (o mediante `appsettings.Development.json` / *user-secrets*):

   ```json
   "ConnectionStrings": {
     "SistemaMantenimientoDBConnection": "Server=localhost;Database=SistemaMantenimiento;Trusted_Connection=True;Trust Server Certificate=True"
   }
   ```

3. Aplicá las migraciones para crear la base de datos:

   ```bash
   dotnet ef database update
   ```

## Ejecución

```bash
dotnet restore
dotnet run
```

La aplicación redirige la ruta raíz (`/`) a `/Auth/Login`. Iniciá sesión con un usuario existente en la base de datos para acceder al resto del sistema (todas las rutas requieren autenticación).

## Funcionalidades principales

- **Autenticación**: login con cookies y sesión.
- **Gestión de usuarios**: alta, edición y roles.
- **Gestión de categorías**: catálogo de tipos de incidencia.
- **Incidencias**: reporte con imagen, asignación a técnico, reparación (fechas, costo, evidencia), descarte con justificación, filtro y detalle.
- **Comentarios**: seguimiento colaborativo sobre cada incidencia.
- **Dashboard**: resumen visual del estado de las incidencias.
