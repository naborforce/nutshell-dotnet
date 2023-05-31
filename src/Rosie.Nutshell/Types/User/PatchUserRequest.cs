using Rosie.Nutshell.Types.Internal;
using Rosie.Nutshell.Types.Lead;
using Rosie.Nutshell.Types.Team;

namespace Rosie.Nutshell.Types.User;

public class PatchUserRequest : PatchedEntity<PatchUserRequest, PatchUserRequest.IPatchKey>
{
    public interface IPatchKey
    {
        string Name { get; }
    }
    
    public static class Keys
    {
        public static readonly TypedPatchKey<string[]> Emails = new("emails");
        public static readonly TypedPatchKey<NutshellTeamPermissions[]> Teams = new("teams");
        public static readonly TypedPatchKey<bool?> SendInvite = new("sendInvite");
    }
    
    public class TypedPatchKey<TValue> : PatchKey<PatchLeadRequest, TValue>, IPatchKey
    {
        public TypedPatchKey(string name) : base(name) { }
    }
}