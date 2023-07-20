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