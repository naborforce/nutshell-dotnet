using System.Diagnostics.CodeAnalysis;
using Rosie.Platform.Abstractions.Enumerations;

namespace Rosie.Nutshell.Types.Common;

[SuppressMessage("ReSharper", "UnusedTypeParameter")]
public abstract class PatchKey<TEntity, TValue> : Enumeration
{
    protected PatchKey(string name) : base(name)
    {
    }
}