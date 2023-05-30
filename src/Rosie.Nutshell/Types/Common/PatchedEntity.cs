using System;
using System.Collections.Generic;
using System.Linq;

namespace Rosie.Nutshell.Types.Common;

public abstract class PatchedEntity<TEntity, TKey> : IProjection
{
    protected readonly Dictionary<string, object?> Values = new();

    public TEntity UpdateNullable<TPatchKey, TValue>(TPatchKey key, TValue? value)
        where TPatchKey : PatchKey<TEntity, TValue?>, TKey
    {
        Values[key.Name] = value;
        return this is TEntity entity ? entity : throw new InvalidOperationException();
    }

    public TEntity Update<TPatchKey, TValue>(TPatchKey key, TValue value)
        where TPatchKey : PatchKey<TEntity, TValue>, TKey
        where TValue : notnull
    {
        Values[key.Name] = value;
        return this is TEntity entity ? entity : throw new InvalidOperationException();
    }

    public object GetProjection() => Values.ToDictionary(v => v.Key, v => v.Value);
}