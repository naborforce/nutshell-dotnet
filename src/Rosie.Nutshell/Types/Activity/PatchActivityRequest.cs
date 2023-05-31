using Rosie.Nutshell.Types.Common;
using Rosie.Nutshell.Types.Internal;

namespace Rosie.Nutshell.Types.Activity;

public class PatchActivityRequest : PatchedEntity<PatchActivityRequest, PatchActivityRequest.IPatchKey>
{
    public interface IPatchKey
    {
        string Name { get; }
    }
    
    public static class Keys
    {
        public static readonly TypedPatchKey<string> Name = new("name");
        public static readonly TypedPatchKey<DateTime?> EndTime = new("industryId");
        public static readonly TypedPatchKey<int?> ActivityTypeId = new("accountTypeId");
        public static readonly TypedPatchKey<NutshellEntity[]> Participants = new("participants");
        public static readonly TypedPatchKey<NutshellEntity[]> Phone = new("leads");
        public static readonly TypedPatchKey<int?> Status = new("status");
        public static readonly TypedPatchKey<NutshellNote?> LogNote = new("logNote");
    }
    
    public class TypedPatchKey<TValue> : PatchKey<PatchActivityRequest, TValue>, IPatchKey
    {
        public TypedPatchKey(string name) : base(name) { }
    }
}