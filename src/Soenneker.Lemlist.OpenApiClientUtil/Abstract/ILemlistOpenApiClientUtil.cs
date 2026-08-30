using Soenneker.Lemlist.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Soenneker.Lemlist.OpenApiClientUtil.Abstract;

/// <summary>
/// Provides a lazily created Lemlist OpenAPI client.
/// </summary>
public interface ILemlistOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Returns the configured Lemlist OpenAPI client, creating it on first use.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>The cached Lemlist OpenAPI client.</returns>
    ValueTask<LemlistOpenApiClient> Get(CancellationToken cancellationToken = default);
}
