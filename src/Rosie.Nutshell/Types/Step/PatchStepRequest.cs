using Rosie.Nutshell.Types.Common;
using Rosie.Nutshell.Types.Lead;

namespace Rosie.Nutshell.Types.Step;

public class PatchStepRequest : PatchedEntity<PatchStepRequest, PatchStepRequest.IPatchKey>
{
    public interface IPatchKey
    {
        string Name { get; }
    }
    
    public static class Keys
    {
        public static readonly TypedPatchKey<NutshellEntity> Assignee = new("assignee");
        public static readonly TypedPatchKey<int> Status = new("status");
        public static readonly TypedPatchKey<NutshellEntityField> Choice = new("choice");
        public static readonly TypedPatchKey<NutshellDelay> Delay = new("delay");
    }
    
    public class TypedPatchKey<TValue> : PatchKey<PatchLeadRequest, TValue>, IPatchKey
    {
        public TypedPatchKey(string name) : base(name) { }
    }
}