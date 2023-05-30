using Rosie.Nutshell.Types.Common;
using Rosie.Nutshell.Types.Internal;
using Rosie.Nutshell.Types.Lead;

namespace Rosie.Nutshell.Types.Product;

public class PatchProductRequest : PatchedEntity<PatchProductRequest, PatchProductRequest.IPatchKey>
{
    public PatchProductRequest(int productId, string rev)
    {
        Values[nameof(productId)] = productId;
        Values[nameof(rev)] = rev;
    }

    public interface IPatchKey
    {
        string Name { get; }
    }

    public static class Keys
    {
        public static readonly TypedPatchKey<int> Id = new("id");
        public static readonly TypedPatchKey<string> EntityType = new("entityType");
        public static readonly TypedPatchKey<string> Rev = new("rev");
        public static readonly TypedPatchKey<string> Name = new("name");
        public static readonly TypedPatchKey<int> Type = new("type");
        public static readonly TypedPatchKey<string> Sku = new("sku");
        public static readonly TypedPatchKey<string> Unit = new("unit");
        public static readonly TypedPatchKey<NutshellProductPrice[]> Prices = new("prices");
    }

    public class TypedPatchKey<TValue> : PatchKey<PatchLeadRequest, TValue>, IPatchKey
    {
        public TypedPatchKey(string name) : base(name)
        {
        }
    }
}