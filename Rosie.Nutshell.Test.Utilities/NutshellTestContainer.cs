using AutoFixture;
using Microsoft.Extensions.DependencyInjection;
using Rosie.Quality;

namespace Rosie.Nutshell.Test.Utilities;

public abstract class NutshellTestContainer : TestContainer.ForSubject<INutshellGateway>
{
    public Secrets.Nutshell Secret { get; set; } = new();

    private static readonly IServiceProvider _serviceProvider;

    static NutshellTestContainer()
    {
        var services = new ServiceCollection();
        services.AddHttpClient();
        _serviceProvider = services.BuildServiceProvider();
    }

    public sealed override INutshellGateway GetSubjectUnderTest(params Action<INutshellGateway>[] actions)
    {
        Fixture.Inject(Secret);
        Fixture.Inject(_serviceProvider.GetRequiredService<IHttpClientFactory>());
        INutshellGateway sut = Create<NutshellGateway>();

        foreach (var action in actions)
        {
            action.Invoke(sut);
        }

        OnSubjectCreated(sut);
        return sut;
    }
}