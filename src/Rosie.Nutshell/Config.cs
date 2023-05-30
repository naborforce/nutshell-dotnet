using Microsoft.Extensions.DependencyInjection;

namespace Rosie.Nutshell;

public static class Config
{
    /// <summary>
    /// Adds the Nutshell Gateway to the service collection without specifying a secret.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The modified service collection.</returns>
    public static IServiceCollection AddNutshell(this IServiceCollection services)
        => services.AddScoped<INutshellGateway, NutshellGateway>();

    /// <summary>
    /// Adds the Nutshell Gateway to the service collection while specifying a secret.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="secret">The Nutshell secret.</param>
    /// <returns>The modified service collection.</returns>
    public static IServiceCollection AddNutshell(this IServiceCollection services, Secrets.Nutshell secret)
        => services
            .AddSingleton(secret)
            .AddNutshell();
}