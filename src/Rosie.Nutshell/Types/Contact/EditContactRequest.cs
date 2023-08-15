using Rosie.Nutshell.Types.Internal;

namespace Rosie.Nutshell.Types.Contact;

public record EditContactRequest(int ContactId, string Rev, PatchContactRequest Lead) : IProjection
{
    public object GetProjection() => new
    {
        ContactId,
        Rev,
        Lead = Lead.GetProjection()
    };
}