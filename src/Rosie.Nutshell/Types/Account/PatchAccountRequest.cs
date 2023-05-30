using Rosie.Nutshell.Types.Channels;
using Rosie.Nutshell.Types.Common;
using Rosie.Nutshell.Types.Internal;

namespace Rosie.Nutshell.Types.Account;

public class PatchAccountRequest : PatchedEntity<PatchAccountRequest, PatchAccountRequest.IPatchKey>
{
    public interface IPatchKey
    {
        string Name { get; }
    }
    
    public static class Keys
    {
        public static readonly TypedPatchKey<string> Name = new("name");
        public static readonly TypedPatchKey<int?> IndustryId = new("industryId");
        public static readonly TypedPatchKey<int?> AccountTypeId = new("accountTypeId");
        public static readonly TypedPatchKey<NutshellPhones?> Phone = new("phone");
        public static readonly TypedPatchKey<NutshellEntity?> Owner = new("owner");
        public static readonly TypedPatchKey<string?> Note = new("note");
        public static readonly TypedPatchKey<string[]> Tags = new("tags");
    }
    
    public class TypedPatchKey<TValue> : PatchKey<PatchAccountRequest, TValue>, IPatchKey
    {
        public TypedPatchKey(string name) : base(name) { }
    }
}