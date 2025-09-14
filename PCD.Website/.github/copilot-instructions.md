This repository contains two main parts: an ASP.NET Core Web API and an Angular frontend (PCD.Website).

Keep guidance short and specific so an AI agent can begin making safe, correct edits.

1) Big picture
- Backend: top-level projects under the repository root (e.g. `PCD.API`, `PCD.ApplicationServices`, `PCD.Data`). The API implements controllers (e.g. `PCD.API/Controllers/*`) that call into application services (`PCD.ApplicationServices/*`) which in turn use repositories and DTOs. AutoMapper profiles map between DTOs and Entities.
- Frontend: the Angular app lives in `PCD.Website` (this folder). Source files are under `PCD.Website/src`. Components live under `src/app`, and environment/config files are under `src/environments` (create if absent).

2) Primary developer flows (commands)
- To run the frontend dev server: from `PCD.Website` run `npm start` (runs `ng serve`, dev server at http://localhost:4200).
- To build the frontend: `npm run build` inside `PCD.Website` (produces `dist/pcd.website`).
- To run backend locally: use `dotnet run` in the API project directory (see root `README.md` for details). Typical dev loop: run backend at default ASP.NET port, run frontend using `ng serve` and ensure `environment.apiBaseUrl` points to backend.
- To typecheck/build the frontend quickly: `ng build --no-progress` or `npm run build`.

3) Where to make common changes
- Add or update API endpoints: edit `PCD.API/Controllers/*Controller.cs` and corresponding application services in `PCD.ApplicationServices/Implementations/*Service.cs`.
- DTOs and request/response shapes: `PCD.Infrastructure.DTOs/*` and `PCD.ApplicationServices.Messaging/*`.
- Database Entities: `PCD.Data/Entities/*` and repository interfaces under `PCD.Repository.Interfaces`.
- Frontend UI: `PCD.Website/src/app/*` components and `src/styles.scss` for global styles.

4) Authentication & tokens pattern
- Backend uses JWT authentication (see project README). Frontend code stores token in `localStorage` (search for `authToken` usage) and uses an `AuthService` that exposes `currentUser$` BehaviorSubject — prefer calling `authService.login(...).subscribe(...)` and reading `authService.currentUser$`.

5) Project-specific conventions
- The backend uses a layered, clean-architecture style: Controllers -> ApplicationServices -> Repositories -> Data.Entities. Follow existing DTO and Messaging classes (requests/responses) when adding endpoints.
- AutoMapper profiles are the canonical mapping place (`PCD.API/AutoMapperProfile.cs`); update mappings when DTO or entity fields change.
- Frontend components prefer Angular DI and `inject()` in services; styling default is SCSS (see `angular.json` schematics config).
- Use `src/assets` for static assets; add runtime configuration under `src/assets` if you need deploy-time config.

6) Build & test gotchas
- The Angular app is configured to use Angular CLI v17; use the repo-local `node`/`npm` versions when possible. Tests run with Karma: `npm test`.
- When changing backend DTOs, update corresponding frontend interfaces (look under `PCD.Website/src/app/*-response.ts` or generated interfaces) to avoid type mismatches.

7) Integration points & external services
- Backend may call external APIs via named HttpClient factories (search for `CreateClient("TollApi")` in controllers). Keep external endpoints configurable by environment or appsettings.

8) Useful files to reference (examples)
- Backend controllers: `PCD.API/Controllers/CarsController.cs`, `PCD.API/Controllers/TripsController.cs`.
- Service implementations: `PCD.ApplicationServices/Implementations/CarsManagementService.cs` and `TripsManagementService.cs`.
- AutoMapper setup: `PCD.API/AutoMapperProfile.cs`.
- Frontend entry: `PCD.Website/src/main.ts`, router in `PCD.Website/src/app/app.routes.ts` and app config `src/app/app.config.ts`.
- Frontend auth example: `PCD.Website/src/app/auth.service.ts` (BehaviorSubject + localStorage usage).

9) When editing code, prefer minimal, focused changes
- Keep public API shapes stable: add new endpoints or optional fields rather than renaming existing fields.
- For frontend changes, return Observables from services and avoid subscribing inside services (let components subscribe).

10) Example tasks for an AI agent (templates)
- Add a new `GET /api/Cars/summary` endpoint: create controller method in `CarsController`, wire into `CarsManagementService`, add DTO and AutoMapper mapping, add a unit test stub.
- Introduce an `AuthInterceptor` in `PCD.Website` to attach `authToken` from `localStorage` to outgoing requests: add `HttpInterceptor`, register in `AppModule` providers.

Feedback
- If any section is unclear or you want more examples (e.g., exact files to change for adding routes, or how to run backend with Docker), tell me which area to expand and I will iterate.

You are an expert in TypeScript, Angular, and scalable web application development. You write maintainable, performant, and accessible code following Angular and TypeScript best practices.

## TypeScript Best Practices

- Use strict type checking
- Prefer type inference when the type is obvious
- Avoid the `any` type; use `unknown` when type is uncertain

## Angular Best Practices

- Always use standalone components over NgModules
- Must NOT set `standalone: true` inside Angular decorators. It's the default.
- Use signals for state management
- Implement lazy loading for feature routes
- Do NOT use the `@HostBinding` and `@HostListener` decorators. Put host bindings inside the `host` object of the `@Component` or `@Directive` decorator instead
- Use `NgOptimizedImage` for all static images.
  - `NgOptimizedImage` does not work for inline base64 images.

## Components

- Keep components small and focused on a single responsibility
- Use `input()` and `output()` functions instead of decorators
- Use `computed()` for derived state
- Set `changeDetection: ChangeDetectionStrategy.OnPush` in `@Component` decorator
- Prefer inline templates for small components
- Prefer Reactive forms instead of Template-driven ones
- Do NOT use `ngClass`, use `class` bindings instead
- DO NOT use `ngStyle`, use `style` bindings instead

## State Management

- Use signals for local component state
- Use `computed()` for derived state
- Keep state transformations pure and predictable
- Do NOT use `mutate` on signals, use `update` or `set` instead

## Templates

- Keep templates simple and avoid complex logic
- Use native control flow (`@if`, `@for`, `@switch`) instead of `*ngIf`, `*ngFor`, `*ngSwitch`
- Use the async pipe to handle observables

## Services

- Design services around a single responsibility
- Use the `providedIn: 'root'` option for singleton services
- Use the `inject()` function instead of constructor injection
