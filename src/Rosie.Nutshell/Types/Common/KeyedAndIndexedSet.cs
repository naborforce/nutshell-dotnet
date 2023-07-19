using System.Collections;

namespace Rosie.Nutshell.Types.Common;

public class KeyedAndIndexedSet<T> : IDictionary<string, T>, ICollection<T>
{
    private IDictionary<string, T> _dict = new Dictionary<string, T>();

    IEnumerator<T> IEnumerable<T>.GetEnumerator() => _dict.Values.GetEnumerator();

    IEnumerator<KeyValuePair<string, T>> IEnumerable<KeyValuePair<string, T>>.GetEnumerator() => _dict.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => _dict.GetEnumerator();

    void ICollection<KeyValuePair<string, T>>.Add(KeyValuePair<string, T> item) => _dict.Add(item);

    void ICollection<T>.Add(T item) => _dict.Add(Guid.NewGuid().ToString(), item);

    void ICollection<T>.Clear() => _dict.Clear();

    bool ICollection<T>.Contains(T item) => _dict.Values.Contains(item);

    void ICollection<T>.CopyTo(T[] array, int arrayIndex) => _dict.Values.CopyTo(array, arrayIndex);

    bool ICollection<T>.Remove(T item) => TryGetKey(item, out var key) && key is not null && _dict.Remove(key);

    private bool TryGetKey(T item, out string? key)
    {
        key = null;
        KeyValuePair<string, T>? pair = _dict.FirstOrDefault(p => p.Value?.Equals(item) == true);

        if (pair is not null)
        {
            key = pair.Value.Key;
            return true;
        }

        return false;
    }

    int ICollection<T>.Count => _dict.Count;

    bool ICollection<T>.IsReadOnly => _dict.IsReadOnly;

    void ICollection<KeyValuePair<string, T>>.Clear() => _dict.Clear();

    bool ICollection<KeyValuePair<string, T>>.Contains(KeyValuePair<string, T> item) => _dict.Contains(item);

    void ICollection<KeyValuePair<string, T>>.CopyTo(KeyValuePair<string, T>[] array, int arrayIndex)
        => _dict.CopyTo(array, arrayIndex);

    bool ICollection<KeyValuePair<string, T>>.Remove(KeyValuePair<string, T> item) => _dict.Remove(item);

    int ICollection<KeyValuePair<string, T>>.Count => _dict.Count;

    bool ICollection<KeyValuePair<string, T>>.IsReadOnly => _dict.IsReadOnly;

    void IDictionary<string, T>.Add(string key, T value) => _dict.Add(key, value);

    bool IDictionary<string, T>.ContainsKey(string key) => _dict.ContainsKey(key);

    bool IDictionary<string, T>.Remove(string key) => _dict.Remove(key);

    bool IDictionary<string, T>.TryGetValue(string key, out T value) => _dict.TryGetValue(key, out value!);

    T IDictionary<string, T>.this[string key]
    {
        get => _dict[key];
        set => _dict[key] = value;
    }

    ICollection<string> IDictionary<string, T>.Keys => _dict.Keys;

    ICollection<T> IDictionary<string, T>.Values => _dict.Values;

    public T? Primary => _dict.TryGetValue("--primary", out var value) ? value : default;
}