using System.Diagnostics.CodeAnalysis;
using Rosie.Platform.Abstractions.Enumerations;

namespace Rosie.Nutshell.Types.Internal;

[SuppressMessage("ReSharper", "UnusedTypeParameter")]
public abstract class PatchKey<TEntity, TValue> : Enumeration
{
    protected internal PatchKey(string name) : base(name)
    {
    }
}