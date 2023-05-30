using Rosie.Nutshell.Types.Common;

namespace Rosie.Nutshell.Types.Contact;

public class PatchContactRequest : PatchedEntity<PatchContactRequest, PatchContactRequest.IPatchKey>
{
    public interface IPatchKey
    {
        string Name { get; }
    }

    public static class Keys
    {
        public static readonly TypedPatchKey<string> Name = new("name");
        public static readonly TypedPatchKey<NutshellPhones?> Phones = new("phone");
        public static readonly TypedPatchKey<NutshellEntity> Owner = new("owner");
        public static readonly TypedPatchKey<string?> Note = new("note");
        public static readonly TypedPatchKey<string?> Description = new("description");
        public static readonly TypedPatchKey<string[]> Tags = new("tags");
    }

    public class TypedPatchKey<TValue> : PatchKey<PatchContactRequest, TValue>, IPatchKey
    {
        public TypedPatchKey(string name) : base(name) { }
    }
}