using Rosie.Nutshell.Types.Common;
using Rosie.Nutshell.Types.Lead;
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
        var lead = new PatchLeadRequest()
            .Update(PatchLeadRequest.Keys.Market, new NutshellEntityId(19))
            .Update(PatchLeadRequest.Keys.Accounts, new[] { new NutshellEntityRevision(1384, "1") })
            .UpdateNullable(PatchLeadRequest.Keys.Note, "This is a test note.")
            .UpdateNullable(PatchLeadRequest.Keys.Confidence, (int?)80)
            .Update(PatchLeadRequest.Keys.Tags, new[] { "tag1", "tag2" });

        var createdLead = await nutshellGateway.CallAsync(NutshellRpc.NewLead, lead);
        Console.WriteLine(createdLead.ToJson());
    }
}