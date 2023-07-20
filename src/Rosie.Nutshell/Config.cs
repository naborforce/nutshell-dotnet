using Microsoft.Extensions.DependencyInjection;
using Rosie.Nutshell.Secrets;
using Rosie.Platform;

namespace Rosie.Nutshell;

/// <summary>
/// Provides extension methods for configuring the Nutshell Gateway.
/// </summary>
public static class Config
{
    static Config() => DotEnv.Load(".env");
    
    /// <summary>
    /// Adds the Nutshell Gateway to the service collection without specifying a secret; i.e. you're leaving resolution
    /// of a secret of type <see cref="NutshellCredential"/> to the dependency injection container.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The modified service collection.</returns>
    // ReSharper disable once MemberCanBePrivate.Global
    public static IServiceCollection AddNutshell(this IServiceCollection services)
        => services.AddScoped<INutshellGateway, NutshellGateway>();

    /// <summary>
    /// Adds the Nutshell Gateway to the service collection while specifying a secret.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="secret">The Nutshell secret.</param>
    /// <returns>The modified service collection.</returns>
    public static IServiceCollection AddNutshell(this IServiceCollection services, NutshellCredential secret)
        => services
            .AddSingleton(secret)
            .AddNutshell();
}