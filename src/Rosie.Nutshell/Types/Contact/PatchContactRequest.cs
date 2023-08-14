using Rosie.Nutshell.Types.Common;
using Rosie.Nutshell.Types.Internal;

namespace Rosie.Nutshell.Types.Contact;

public class PatchContactRequest : PatchedEntity<PatchContactRequest, PatchContactRequest.IPatchKey>
{
    public interface IPatchKey
    {
        string Name { get; }
    }

    public override object GetProjection() => new { contact = base.GetProjection() };

    public static class Keys
    {
        public static readonly TypedPatchKey<string> Name = new("name");
        public static readonly TypedPatchKey<string[]> Phones = new("phone");
        public static readonly TypedPatchKey<string[]> Emails = new("email");
        public static readonly TypedPatchKey<ContactLead[]> Leads = new("leads");
        public static readonly TypedPatchKey<NutshellEntity> Owner = new("owner");
        public static readonly TypedPatchKey<string?> Note = new("note");
        public static readonly TypedPatchKey<string?> Description = new("description");
        public static readonly TypedPatchKey<string[]> Tags = new("tags");
        public static readonly TypedPatchKey<Identifier[]> Audiences = new("audiences");
        public static readonly TypedPatchKey<Dictionary<string, string>> CustomFields = new("customFields");
    }

    public class TypedPatchKey<TValue> : PatchKey<PatchContactRequest, TValue>, IPatchKey
    {
        public TypedPatchKey(string name) : base(name) { }
    }
}