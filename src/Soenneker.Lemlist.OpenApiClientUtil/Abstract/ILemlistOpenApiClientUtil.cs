using Soenneker.Lemlist.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Lemlist.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface ILemlistOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    ValueTask<LemlistOpenApiClient> Get(CancellationToken cancellationToken = default);
}
