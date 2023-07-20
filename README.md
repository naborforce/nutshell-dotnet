# Nutshell Dotnet (from Naborforce)

This is a package that contains the Rosie Nutshell Dotnet library.  Produced by @naborforce, we created this package
to assist with managing our data stored in the Nutshell CRM. This package is not affiliated with Nutshell, and is not
supported by Nutshell.  It is provided as-is, and is not guaranteed to work.  Use at your own risk.


## Installation
Install Rosie.Nutshell using NuGet:

```ps
Install-Package Rosie.Nutshell
```

Or use the .NET core CLI to install Rosie.Nutshell:
```bash
dotnet add package Rosie.Nutshell
```

## Usage
To use Nutshell Dotnet, you will need to have a Nutshell account.  You will also need to have your API key and username.
You can find these in your Nutshell account under Settings -> API Keys.

### Authentication
To authenticate with Nutshell, you will need to inject an object of type `Rosie.Nutshell.Secrets.Nutshell` into the DI
container.  You can do so easily by consuming the extension method: 
```csharp 
services.AddNutshell(new Rosie.Nutshell.Secrets.Nutshell("Username", "ApiKey"));
```

### Using the Injected Service
After adding Nutshell to your DI container, you can make use of the scoped service: `Rosie.Nutshell.INutshellGateway`.
This service contains one overloaded method that you'll need: `CallAsync`.   There are three versions of this method:
1. `Task<TOut> CallAsync<TOut, TIn>(NutshellRpc<TOut, TIn> method, TIn input)` -> this method will call a Nutshell
    remote procedure, sending along an input and returns a value.
2. `Task<TOut> CallAsync<TOut>(NutshellFunc<TOut> method)` -> this method will call a Nutshell remote procedure that
    returns a value, but does not take any input.
3. `Task CallAsync<TIn>(NutshellAction<TIn> method, TIn input)` -> this method will call a Nutshell remote procedure
    that takes an input, but does not return a value.

### Example
```csharp
using Rosie.Nutshell.Types.Common;
using Rosie.Nutshell.Types.Lead;
using Rosie.Platform.Extensions;

namespace Rosie.Nutshell;

public class Example
{
    private readonly INutshellGateway _nutshellGateway;

    // this is a typical constructor for a class that uses dependency injection
    public Example(INutshellGateway nutshellGateway)
    {
        _nutshellGateway = nutshellGateway;
    }
    
    // you can alternatively use the static method to create a NutshellGateway
    public static Example CreateExample()
    {
        var nutshellGateway = NutshellGatewayFactory.Create();
        return new Example(nutshellGateway);
    }

    public async Task Run()
    {
        var lead = new PatchLeadRequest()
            .Update(PatchLeadRequest.Keys.Market, new NutshellEntityId(19))
            .Update(PatchLeadRequest.Keys.Accounts, new[] { new NutshellEntityRevision(1384, "1") })
            .UpdateNullable(PatchLeadRequest.Keys.Note, "This is a test note.")
            .UpdateNullable(PatchLeadRequest.Keys.Confidence, (int?)80)
            .Update(PatchLeadRequest.Keys.Tags, new[] { "tag1", "tag2" });

        var createdLead = await _nutshellGateway.CallAsync(NutshellRpc.Leads.NewLead, lead);
        Console.WriteLine(createdLead.ToJson());
    }
}
```

### Additional Remote Procedures
See the static members of `Rosie.Nutshell.NutshellRpc` for all available remote procedures.
