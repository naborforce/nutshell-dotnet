using Microsoft.Extensions.DependencyInjection;
using Rosie.Nutshell.Secrets;

namespace Rosie.Nutshell;

/// <summary>
/// Factory for creating <see cref="INutshellGateway"/> instances.
/// </summary>
// ReSharper disable once UnusedType.Global
public static class NutshellGatewayFactory
{
    /// <summary>
    /// Creates a <see cref="INutshellGateway"/> using the specified secrets.
    /// </summary>
    public static INutshellGateway Create(NutshellCredential secret)
        => new ServiceCollection()
               .AddHttpClient()
               .AddNutshell(secret)
               .BuildServiceProvider()
               .GetService<INutshellGateway>()
           ?? throw new Exception("Could not create INutshellGateway");

    /// <summary>
    /// Creates a <see cref="INutshellGateway"/> using environment variable secrets; see
    /// <see cref="NutshellCredential"/>
    /// </summary>
    // ReSharper disable once UnusedMember.Global
    public static INutshellGateway Create() => Create(new NutshellCredential());
}