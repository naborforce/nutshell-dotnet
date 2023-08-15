using Rosie.Nutshell.Types.Internal;

namespace Rosie.Nutshell.Types.Lead;

public record EditLeadRequest(int LeadId, string Rev, PatchLeadRequest Lead) : IProjection
{
    public object GetProjection() => new
    {
        LeadId,
        Rev,
        Lead = Lead.GetProjection()
    };
}