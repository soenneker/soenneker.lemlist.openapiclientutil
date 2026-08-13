using Soenneker.Lemlist.OpenApiClientUtil.Abstract;
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
}
