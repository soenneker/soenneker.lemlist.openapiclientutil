[![](https://img.shields.io/nuget/v/soenneker.lemlist.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.lemlist.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.lemlist.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.lemlist.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.lemlist.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.lemlist.openapiclientutil/)

# Soenneker.Lemlist.OpenApiClientUtil

Exposes a cached OpenAPI client instance.

## Install

```bash
dotnet add package Soenneker.Lemlist.OpenApiClientUtil
```

## Quick start

```csharp
using Soenneker.Lemlist.OpenApiClientUtil.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddLemlistOpenApiClientUtilAsSingleton();
```

Adds `LemlistOpenApiClientUtil` as a singleton service.

## What you get

- `ILemlistOpenApiClientUtil` — Exposes a cached OpenAPI client instance.
- `LemlistOpenApiClientUtilRegistrar` — Registers the OpenAPI client utility for dependency injection.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `LemlistOpenApiClientUtilRegistrar.AddLemlistOpenApiClientUtilAsSingleton(services)` | Adds `LemlistOpenApiClientUtil` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `LemlistOpenApiClientUtilRegistrar.AddLemlistOpenApiClientUtilAsScoped(services)` | Adds `LemlistOpenApiClientUtil` as a scoped service. | The same service collection, so additional registrations can be chained. |

## Practical notes

- Reuse the registered client instead of constructing one per operation.
- Dispose instances you own when their scope ends so held resources can be released.
