# Guía de Proyectos Portfolio — Matías Aguirre

Objetivo: 6 proyectos propios para mostrar en Upwork, Toptal, LinkedIn, etc.
Basados en el stack real de experiencia (WB Sistemas, SourceNow, GoStrategy, Relivy).

Orden de ejecución sugerido: 1 → 6 (empezamos por el 1).

---

## 1. SaaS B2B multi-tenant (HR/gestión) — EN CURSO
- **Repo:** `E:\Development\github\projects\saas_hr_platform`
- **Stack:** .NET Core + ABP Framework + Angular + PostgreSQL + Docker + Nginx, deploy AWS/VPS
- **Idea:** Mini plataforma de gestión de empleados/tareas con roles configurables, multi-tenant básico.
- **Comando de creación:**
  ```
  abp new SaasHrPlatform -u angular -dbms PostgreSQL -m none --theme leptonx-lite --connection-string "Host=localhost;Port=5432;Database=SaasHrPlatform;User ID=postgres;Password=123qwe;"
  ```
- **Referencia:** WB Sistemas (ABP Framework, .NET Core, Angular, arquitectura modular, reglas de negocio configurables)
- **Estado:** creando proyecto base

## 2. API financiera con reportes
- **Stack:** .NET Core Web API o Node, PostgreSQL (stored procedures/triggers), React dashboard
- **Idea:** Sistema de facturación/comisiones — cálculo de márgenes, reportes por período.
- **Referencia:** SourceNow (SQL complejo, lógica financiera, cierre mensual)
- **Estado:** pendiente

## 3. App móvil con backend completo
- **Stack:** React Native + Expo, backend Node/.NET, colas (BullMQ o similar), RevenueCat (o mock de suscripciones)
- **Idea:** App de hábitos/tracking con notificaciones programadas y auth.
- **Referencia:** Relivy (React Native, Expo, workers/colas, RevenueCat)
- **Estado:** pendiente

## 4. Integración de APIs externas (SOAP/REST)
- **Stack:** .NET Core, XML/JSON
- **Idea:** Servicio que integra 2-3 APIs de terceros normalizando formatos distintos (SOAP + REST).
- **Referencia:** GoStrategy (integraciones con aseguradoras, SOAP/REST, XML/JSON)
- **Estado:** pendiente

## 5. Infra/DevOps showcase
- **Stack:** Docker Compose, Nginx reverse proxy, CI/CD (GitHub Actions o Jenkins), AWS/Linux
- **Idea:** Dockerizar y documentar el deploy completo del proyecto #1, con pipeline CI/CD, HTTPS, logs.
- **Referencia:** WB Sistemas / GoStrategy (AWS, Linux, Docker, Nginx, Jenkins, IIS)
- **Estado:** pendiente

## 6. Next.js + Dashboard con auth y roles
- **Stack:** Next.js, PostgreSQL, Prisma, Docker
- **Idea:** Panel admin con auth (roles), tablas con filtros/paginación server-side.
- **Referencia:** cubre el ángulo frontend moderno (Next.js) que no aparece en la experiencia laboral
- **Estado:** pendiente

---

## Notas generales
- Cada proyecto se construye a la par (Matías pega y analiza cada bloque de código, no generación automática).
- Sin datos ni lógica de clientes reales — todo diseño original.
- Modelo: Sonnet 5 medium por defecto; subir a high solo para tramos de lógica compleja puntual.

## Metodología de desarrollo (aplica a TODOS los proyectos)
- Código con mejores prácticas de nivel senior: principios SOLID, DRY, patrones de diseño donde correspondan (no forzados).
- Cada sección se explica en términos que un trainee developer pueda entender a la perfección antes de avanzar — no se pega código sin que Matías entienda el porqué.
- Se avanza sección por sección: explicación → código propuesto → Matías lo pega y analiza → siguiente sección.
