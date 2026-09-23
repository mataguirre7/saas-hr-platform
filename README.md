# SaaS HR Platform

Plataforma de gestión de Recursos Humanos multi-tenant construida con **ABP Framework** (.NET) y **Angular**. Proyecto de portfolio — permite administrar departamentos y empleados dentro de una arquitectura B2B SaaS, con autenticación OAuth real, eventos de dominio y un worker programado.

## Stack

**Backend**
- .NET 10 / ABP Framework 10.6
- PostgreSQL 16 (Entity Framework Core)
- OpenIddict (OAuth 2.0 Authorization Code + PKCE)
- Mapperly (mapeo de objetos en tiempo de compilación)
- Domain-Driven Design: Aggregate Roots, Domain Services, Repositories, eventos de dominio (Event Bus), Background Workers

**Frontend**
- Angular 22 (standalone components, lazy loading)
- PrimeNG 17 + Bootstrap 5
- ABP Angular SDK (proxies auto-generados desde el backend)

**Infraestructura**
- Docker + Docker Compose (multi-stage builds)
- Nginx (servidor estático para Angular)

## Funcionalidades

- CRUD completo de **Departments** y **Employees**, con validaciones de negocio (nombre/email únicos, fecha de contratación, etc.)
- Multi-tenancy a nivel de dominio
- Autenticación OAuth 2.0 con Authorization Code Flow + PKCE (sin `client_secret` en el frontend, como corresponde a una SPA)
- Evento de dominio (`EmployeeCreatedEto`) publicado al crear un empleado, consumido por un handler desacoplado
- Background Worker que genera un resumen periódico de empleados activos por departamento
- Localización (inglés / español)
- Seed data automático al levantar el proyecto

## Capturas

> ![Departments](docs/screenshots/departments.png)
> ![Employees](docs/screenshots/employees.png)
> ![Login](docs/screenshots/login.png)

## Cómo levantarlo

### Opción 1: Docker (recomendado)

Requisitos: Docker y Docker Compose.

```bash
docker compose up -d --build
```

Esto levanta 4 contenedores:

| Servicio | Descripción | Puerto |
|---|---|---|
| `db` | PostgreSQL 16 | 5432 |
| `migrator` | Aplica migraciones y siembra datos de ejemplo (corre una vez y termina) | — |
| `backend` | API (ABP HttpApi.Host) | 8080 |
| `frontend` | Angular servido por Nginx | 4200 |

Una vez levantado:
- App: [http://localhost:4200](http://localhost:4200)
- API / Swagger: [http://localhost:8080/swagger](http://localhost:8080/swagger)

El seed carga automáticamente 3 departamentos y 5 empleados de ejemplo — no hace falta cargar nada a mano para ver el proyecto funcionando.

Para reiniciar solo el frontend después de un cambio (sin perder los datos de la base):
```bash
docker compose up -d --build frontend
```

Para arrancar completamente de cero (borra también los datos de Postgres):
```bash
docker compose down -v
docker compose up -d --build
```

### Opción 2: Desarrollo local (sin Docker)

Requisitos: .NET 10 SDK, Node 22+, Yarn, PostgreSQL corriendo localmente.

**Backend:**
```bash
cd aspnet-core
dotnet run --project src/saas_hr_platform.DbMigrator   # aplica migraciones y siembra datos
dotnet run --project src/saas_hr_platform.HttpApi.Host
```

**Frontend:**
```bash
cd angular
yarn install
yarn start
```

## Arquitectura del backend

Organizado en capas siguiendo DDD (Domain-Driven Design):

```
aspnet-core/
├── src/
│   ├── saas_hr_platform.Domain.Shared/     # Constantes, enums, códigos de error
│   ├── saas_hr_platform.Domain/            # Entidades, Domain Services, eventos, worker
│   ├── saas_hr_platform.Application.Contracts/  # DTOs, interfaces de AppServices
│   ├── saas_hr_platform.Application/       # Implementación de AppServices, mapeo
│   ├── saas_hr_platform.EntityFrameworkCore/     # Persistencia (EF Core, repositorios)
│   ├── saas_hr_platform.HttpApi/           # Controllers
│   ├── saas_hr_platform.HttpApi.Host/      # Host / entry point de la API
│   └── saas_hr_platform.DbMigrator/        # Migraciones + seed de datos
```

**Decisiones de diseño destacadas:**
- Entidades con setters privados y validación en el constructor (Rich Domain Model) — nunca quedan en un estado inválido.
- Reglas de unicidad (email, nombre) resueltas en Domain Services (`DepartmentManager`, `EmployeeManager`), no en la entidad ni en el AppService — es el único lugar donde tiene sentido consultar el repositorio antes de crear.
- Backend detrás de su propio origen (no oculto tras un reverse proxy) para respetar el flujo de login server-rendered que trae ABP con OpenIddict.

## Arquitectura del frontend

```
angular/src/app/
├── departments/       # Listado, alta, edición y baja de Departments
├── employees/         # Listado, alta, edición y baja de Employees
└── proxy/             # Servicios y DTOs auto-generados desde el backend (abp generate-proxy)
```

- Componentes standalone, sin `NgModule`.
- Rutas lazy-loaded.
- Un solo componente de formulario reutilizado para crear y editar (evita duplicar el formulario).

## Licencia

Proyecto de portfolio — de uso libre como referencia.
