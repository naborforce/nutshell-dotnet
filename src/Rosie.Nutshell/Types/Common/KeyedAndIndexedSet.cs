using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Rosie.Nutshell.Types.Common;

public class KeyedAndIndexedSet<T> : IDictionary<string, T>, ICollection<T>
{
    private IDictionary<string, T> dict = new Dictionary<string, T>();

    IEnumerator<T> IEnumerable<T>.GetEnumerator() => dict.Values.GetEnumerator();

    IEnumerator<KeyValuePair<string, T>> IEnumerable<KeyValuePair<string, T>>.GetEnumerator() => dict.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => dict.GetEnumerator();

    void ICollection<KeyValuePair<string, T>>.Add(KeyValuePair<string, T> item) => dict.Add(item);

    void ICollection<T>.Add(T item) => dict.Add(Guid.NewGuid().ToString(), item);

    void ICollection<T>.Clear() => dict.Clear();

    bool ICollection<T>.Contains(T item) => dict.Values.Contains(item);

    void ICollection<T>.CopyTo(T[] array, int arrayIndex) => dict.Values.CopyTo(array, arrayIndex);

    bool ICollection<T>.Remove(T item) => TryGetKey(item, out var key) && key is not null && dict.Remove(key);

    private bool TryGetKey(T item, out string? key)
    {
        key = null;
        KeyValuePair<string, T>? pair = dict.FirstOrDefault(p => p.Value?.Equals(item) == true);

        if (pair is not null)
        {
            key = pair.Value.Key;
            return true;
        }

        return false;
    }

    int ICollection<T>.Count => dict.Count;

    bool ICollection<T>.IsReadOnly => dict.IsReadOnly;

    void ICollection<KeyValuePair<string, T>>.Clear() => dict.Clear();

    bool ICollection<KeyValuePair<string, T>>.Contains(KeyValuePair<string, T> item) => dict.Contains(item);

    void ICollection<KeyValuePair<string, T>>.CopyTo(KeyValuePair<string, T>[] array, int arrayIndex)
        => dict.CopyTo(array, arrayIndex);

    bool ICollection<KeyValuePair<string, T>>.Remove(KeyValuePair<string, T> item) => dict.Remove(item);

    int ICollection<KeyValuePair<string, T>>.Count => dict.Count;

    bool ICollection<KeyValuePair<string, T>>.IsReadOnly => dict.IsReadOnly;

    void IDictionary<string, T>.Add(string key, T value) => dict.Add(key, value);

    bool IDictionary<string, T>.ContainsKey(string key) => dict.ContainsKey(key);

    bool IDictionary<string, T>.Remove(string key) => dict.Remove(key);

    bool IDictionary<string, T>.TryGetValue(string key, out T value) => dict.TryGetValue(key, out value!);

    T IDictionary<string, T>.this[string key]
    {
        get => dict[key];
        set => dict[key] = value;
    }

    ICollection<string> IDictionary<string, T>.Keys => dict.Keys;

    ICollection<T> IDictionary<string, T>.Values => dict.Values;

    public T? Primary => dict.TryGetValue("--primary", out var value) ? value : default;
}