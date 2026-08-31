[![](https://img.shields.io/nuget/v/soenneker.lemlist.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.lemlist.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.lemlist.openapiclientutil/build-and-test.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.lemlist.openapiclientutil/actions/workflows/build-and-test.yml)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.lemlist.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.lemlist.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.lemlist.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.lemlist.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.lemlist.openapiclientutil/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.lemlist.openapiclientutil/actions/workflows/codeql.yml)

# Soenneker.Lemlist.OpenApiClientUtil

Create and reuse an authenticated `LemlistOpenApiClient` over the shared Lemlist HTTP transport.

## Install

```bash
dotnet add package Soenneker.Lemlist.OpenApiClientUtil
```

## Configuration

```json
{
  "Lemlist": {
    "ApiKey": "your-api-key"
  }
}
```

Set `Lemlist:ClientBaseUrl` only when the API should use a different base URL.

## Usage

```csharp
using Soenneker.Lemlist.OpenApiClientUtil.Abstract;
using Soenneker.Lemlist.OpenApiClientUtil.Registrars;

services.AddLemlistOpenApiClientUtilAsScoped();

ILemlistOpenApiClientUtil lemlist =
    serviceProvider.GetRequiredService<ILemlistOpenApiClientUtil>();

var client = await lemlist.Get(cancellationToken);
var campaigns = await client.Campaigns.GetAsync(cancellationToken: cancellationToken);
```

`Get()` creates the typed client on first use and returns the same instance for the utility's lifetime. The scoped registration intentionally keeps the underlying authenticated HTTP client singleton: a scope can release its typed utility without tearing down the transport shared by other scopes.

Use `AddLemlistOpenApiClientUtilAsSingleton()` when the typed client should also live for the application lifetime.
