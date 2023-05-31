using Rosie.Nutshell.Types.Endpoint;
using Rosie.Platform.Extensions;

namespace Rosie.Nutshell;

public class Example
{
    private readonly INutshellGateway nutshellGateway;

    public Example(INutshellGateway nutshellGateway)
    {
        this.nutshellGateway = nutshellGateway;
    }
    
    public async Task Run()
    {
        var request = new GetEndpointRequest("some-username");
        var endpoint = await nutshellGateway.CallAsync(NutshellMethods.GetApiForUsername, request);
        Console.WriteLine(endpoint.ToJson());
    }
}