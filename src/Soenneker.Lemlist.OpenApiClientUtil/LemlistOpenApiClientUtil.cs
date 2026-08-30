using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.ValueTask;
using Soenneker.Lemlist.HttpClients.Abstract;
using Soenneker.Lemlist.OpenApiClientUtil.Abstract;
using Soenneker.Lemlist.OpenApiClient;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Lemlist.OpenApiClientUtil;

public sealed class LemlistOpenApiClientUtil : ILemlistOpenApiClientUtil
{
    private readonly AsyncSingleton<LemlistOpenApiClient> _client;

    public LemlistOpenApiClientUtil(ILemlistOpenApiHttpClient httpClientUtil)
    {
        _client = new AsyncSingleton<LemlistOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var requestAdapter = new HttpClientRequestAdapter(new AnonymousAuthenticationProvider(), httpClient: httpClient);

            return new LemlistOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<LemlistOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
