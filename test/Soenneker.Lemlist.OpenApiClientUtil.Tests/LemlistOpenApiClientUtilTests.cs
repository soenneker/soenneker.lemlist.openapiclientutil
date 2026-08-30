using System.Linq;
using System.Threading.Tasks;
using Soenneker.Lemlist.OpenApiClientUtil.Abstract;
using Soenneker.Lemlist.OpenApiClientUtil.Registrars;
using Soenneker.Lemlist.HttpClients.Abstract;
using Microsoft.Extensions.DependencyInjection;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Lemlist.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class LemlistOpenApiClientUtilTests : HostedUnitTest
{
    private readonly ILemlistOpenApiClientUtil _openapiclientutil;

    public LemlistOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<ILemlistOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }

    [Test]
    public async Task Scoped_utility_keeps_http_client_singleton()
    {
        var services = new ServiceCollection();

        services.AddLemlistOpenApiClientUtilAsScoped();

        ServiceDescriptor httpClient = services.Single(descriptor => descriptor.ServiceType == typeof(ILemlistOpenApiHttpClient));
        ServiceDescriptor clientUtil = services.Single(descriptor => descriptor.ServiceType == typeof(ILemlistOpenApiClientUtil));

        await Assert.That(httpClient.Lifetime).IsEqualTo(ServiceLifetime.Singleton);
        await Assert.That(clientUtil.Lifetime).IsEqualTo(ServiceLifetime.Scoped);
    }
}
