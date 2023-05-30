using System.Collections.Generic;
using Rosie.Nutshell.Types.Common;
using Rosie.Nutshell.Types.Competitor;
using Rosie.Nutshell.Types.Product;

namespace Rosie.Nutshell.Types.Lead;

public class PatchLeadRequest : PatchedEntity<PatchLeadRequest, PatchLeadRequest.IPatchKey>
{
    public interface IPatchKey
    {
        string Name { get; }
    }
    
    public static class Keys
    {
        public static readonly TypedPatchKey<NutshellEntityId> PrimaryAccount = new("primaryAccount");
        public static readonly TypedPatchKey<NutshellEntityId> Market = new("market");
        public static readonly TypedPatchKey<string[]> Tags = new("tags");
        public static readonly TypedPatchKey<int?> Confidence = new("confidence");
        public static readonly TypedPatchKey<NutshellEntity> Assignee = new("assignee");
        public static readonly TypedPatchKey<NutshellEntityRevision[]> Contacts = new("contacts");
        public static readonly TypedPatchKey<NutshellEntityRevision[]> Accounts = new("accounts");
        public static readonly TypedPatchKey<NutshellProduct[]> Products = new("products");
        public static readonly TypedPatchKey<NutshellCompetitor[]> Competitors = new("competitors");
        public static readonly TypedPatchKey<NutshellEntityRevision[]> Sources = new("sources");
        public static readonly TypedPatchKey<string?> Note = new("note");
        public static readonly TypedPatchKey<Dictionary<string, string>> CustomFields = new("customFields");
        public static readonly TypedPatchKey<string?> Priority = new("priority");
        public static readonly TypedPatchKey<bool> IsPending = new("isPending");
        public static readonly TypedPatchKey<int?> MilestoneId = new("milestoneId");
        public static readonly TypedPatchKey<int?> StageSetId = new("stagesetId");
    }
    
    public class TypedPatchKey<TValue> : PatchKey<PatchLeadRequest, TValue>, IPatchKey
    {
        public TypedPatchKey(string name) : base(name) { }
    }
}