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
    /// <summary>
    /// Returns the configured lemlist OpenAPI Client used by the Lemlist OpenAPI Client.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the requested lemlist OpenAPI Client.</returns>
    ValueTask<LemlistOpenApiClient> Get(CancellationToken cancellationToken = default);
}
