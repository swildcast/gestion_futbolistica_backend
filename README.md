# Gestión Futbolística - Backend

Backend API REST desarrollado con .NET Core 8 y SQL Server para la gestión de equipos de fútbol, jugadores y partidos.

## 🤖 Declaración de Uso de IA

Este proyecto fue desarrollado como parte de mi proceso de aprendizaje con asistencia de herramientas de Inteligencia Artificial.

### Lo que realicé personalmente:
- ✅ Análisis y comprensión de los requisitos del proyecto
- ✅ Configuración del entorno de desarrollo (.NET Core 8, SQL Server)
- ✅ Pruebas exhaustivas de los endpoints con Swagger
- ✅ Depuración de errores de conexión y configuración
- ✅ Migración de PostgreSQL a SQL Server
- ✅ Resolución de problemas con stored procedures
- ✅ Validación de CORS y conectividad con el frontend
- ✅ Pruebas manuales de todas las operaciones CRUD
- ✅ Comprensión de la arquitectura y patrones implementados

### Asistencia de IA:
- 🤖 Generación de código base siguiendo mejores prácticas
- 🤖 Explicación de conceptos de Entity Framework Core
- 🤖 Implementación de stored procedures en SQL Server
- 🤖 Configuración de inyección de dependencias
- 🤖 Sugerencias para resolver errores técnicos
- 🤖 Explicación de patrones Repository y Service

## 🏗️ Arquitectura

```
gestion_futbolistica_backend/
├── Controllers/          # Endpoints REST API
│   ├── TeamsController.cs
│   ├── PlayersController.cs
│   └── MatchesController.cs
├── Entities/            # Modelos de datos
│   ├── Team.cs
│   ├── Player.cs
│   └── Match.cs
├── Data/                # Contexto EF Core y SQL
│   ├── FootballContext.cs
│   ├── CreateStoredProcedures.sql
│   └── SeedData.sql
├── Services/            # Lógica de negocio
│   └── PlayersService.cs
├── Migrations/          # Migraciones EF Core
└── Program.cs           # Configuración de la app
```

## 🔧 Tecnologías Implementadas

- **.NET Core 8**: Framework principal
- **Entity Framework Core 9**: ORM para acceso a datos
- **SQL Server**: Base de datos relacional
- **Stored Procedures**: Para operaciones GET de listado
- **Swagger/OpenAPI**: Documentación interactiva de la API
- **CORS**: Configurado para frontend en `localhost:4200`

## 📊 Características Técnicas

### Operaciones CRUD Completas
- **Teams (Equipos)**: GET (con SP), POST, PUT, DELETE
- **Players (Jugadores)**: GET (con SP), POST, PUT, DELETE  
- **Matches (Partidos)**: GET (con SP), POST, PUT, DELETE

### Stored Procedures
```sql
- sp_GetAllTeams
- sp_GetAllPlayers
- sp_GetAllMatches
```

### Validaciones
- Atributos de validación en entidades (`[Required]`, `[MaxLength]`, `[Range]`)
- Manejo de errores con middleware
- Validación de concurrencia en actualizaciones

### Configuración CORS
```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        builder => builder.WithOrigins("http://localhost:4200")
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});
```

## 🚀 Cómo Ejecutar

### Prerrequisitos
- .NET Core SDK 8.0+
- SQL Server 2019+
- SQL Server Management Studio (opcional)

### Instalación

1. **Clonar el repositorio**
```bash
git clone https://github.com/swildcast/gestion_futbolistica_backend.git
cd gestion_futbolistica_backend
```

2. **Configurar la base de datos**

Actualizar `appsettings.json` con tu cadena de conexión:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=GestionFutbolisticaDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

3. **Ejecutar migraciones**
```bash
dotnet ef database update
```

4. **Crear stored procedures**
```bash
sqlcmd -S localhost -d GestionFutbolisticaDB -i Data/CreateStoredProcedures.sql
```

5. **Poblar datos iniciales (opcional)**
```bash
sqlcmd -S localhost -d GestionFutbolisticaDB -i Data/SeedData.sql
```

6. **Ejecutar la aplicación**
```bash
dotnet run
```

La API estará disponible en: `http://localhost:5130`

Swagger UI: `http://localhost:5130/swagger`

## 📝 Endpoints Principales

### Teams
- `GET /api/teams` - Listar todos (con SP)
- `GET /api/teams/{id}` - Obtener por ID
- `POST /api/teams` - Crear equipo
- `PUT /api/teams/{id}` - Actualizar equipo
- `DELETE /api/teams/{id}` - Eliminar equipo

### Players
- `GET /api/players` - Listar todos (con SP)
- `GET /api/players/{id}` - Obtener por ID
- `POST /api/players` - Crear jugador
- `PUT /api/players/{id}` - Actualizar jugador
- `DELETE /api/players/{id}` - Eliminar jugador

### Matches
- `GET /api/matches` - Listar todos (con SP)
- `GET /api/matches/{id}` - Obtener por ID
- `POST /api/matches` - Crear partido
- `PUT /api/matches/{id}` - Actualizar partido
- `DELETE /api/matches/{id}` - Eliminar partido

## 🐛 Problemas Resueltos Durante el Desarrollo

1. **Migración PostgreSQL → SQL Server**
   - Cambio de provider en `Program.cs`
   - Actualización de cadena de conexión
   - Ajuste de tipos de datos específicos de SQL Server

2. **Stored Procedures Faltantes**
   - Error 208: "Invalid object name"
   - Solución: Ejecución manual del script SQL

3. **Errores de Encoding en SQL**
   - Caracteres especiales (ñ, ó) causaban errores
   - Solución: Uso de prefijo `N` para Unicode y corchetes `[]`

4. **Nombres de Propiedades**
   - Inconsistencia entre C# (PascalCase) y DB (acentos)
   - Solución: Atributos `[Column]` para mapeo correcto

5. **Foreign Keys**
   - Uso de `IdEquipo` en lugar de `TeamId`
   - Ajuste en scripts de seed data

## 🔗 Frontend Relacionado

Este backend trabaja con el frontend Angular disponible en:
- Repositorio: https://github.com/swildcast/gestion_futbolistica_frontend.git

## 📚 Aprendizajes Clave

- Arquitectura de APIs REST con .NET Core
- Entity Framework Core como ORM
- Integración de Stored Procedures con EF Core
- Migrations y manejo de esquema de BD
- Inyección de dependencias en .NET
- Configuración de CORS para SPA
- Validaciones y manejo de errores
- Debugging de aplicaciones .NET

## 👨‍💻 Autor

Desarrollado como proyecto final con asistencia de IA para aprendizaje de:
- Arquitectura backend .NET Core
- Entity Framework Core
- SQL Server y Stored Procedures
- Principios REST API

---

**Nota**: Este proyecto fue desarrollado con fines educativos, utilizando IA como herramienta de aprendizaje y mentoría técnica.
