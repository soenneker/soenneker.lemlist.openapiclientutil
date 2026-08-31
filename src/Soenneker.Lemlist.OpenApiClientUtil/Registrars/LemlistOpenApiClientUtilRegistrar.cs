using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Lemlist.HttpClients.Registrars;
using Soenneker.Lemlist.OpenApiClientUtil.Abstract;

namespace Soenneker.Lemlist.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the lazily created Lemlist generated-client provider.
/// </summary>
public static class LemlistOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="LemlistOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddLemlistOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddLemlistOpenApiHttpClientAsSingleton()
                .TryAddSingleton<ILemlistOpenApiClientUtil, LemlistOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="LemlistOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddLemlistOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddLemlistOpenApiHttpClientAsSingleton()
                .TryAddScoped<ILemlistOpenApiClientUtil, LemlistOpenApiClientUtil>();

        return services;
    }
}
