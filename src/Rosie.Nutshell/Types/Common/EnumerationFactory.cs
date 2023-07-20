using System.Collections.Concurrent;
using System.Reflection;

namespace Rosie.Nutshell.Types.Common;

internal static class EnumerationFactory
{
    private static readonly ConcurrentDictionary<Type, object> _dict = new();

    public static ICollection<TEnumeration> GetAll<TEnumeration>()
        where TEnumeration : Enumeration
        => GetAll<TEnumeration>(GetAllBehavior.Filter);
        
    public static ICollection<TEnumeration> GetAll<TEnumeration>(GetAllBehavior behavior)
        where TEnumeration : Enumeration
    {
        var rootType = typeof(TEnumeration);
        if (_dict.TryGetValue(rootType, out var value1))
        {
            return (TEnumeration[])value1;
        }

        var types = new List<Type> { rootType };

        AddNestedTypesOf(rootType, ref types);

        var array = types.Select(GetAllFieldsOf<TEnumeration>)
            .SelectMany(values => values.ToList())
            .OrderBy(value => value.SortOrder)
            .ToArray();

        var first = array.FirstOrDefault();
        if (first is IFilterableEnumeration<TEnumeration> filter && behavior == GetAllBehavior.Filter)
        {
            array = filter.FilterAll(array).ToArray();
        }

        _dict[rootType] = array;
        return array;
    }

    private static void AddNestedTypesOf(Type rootType, ref List<Type> types)
    {
        var nestedTypes = rootType.GetNestedTypes();
        types.AddRange(nestedTypes);
        foreach (var nestedType in nestedTypes)
        {
            AddNestedTypesOf(nestedType, ref types);
        }
    }

    private static ICollection<TEnumeration> GetAllFieldsOf<TEnumeration>(Type type)
        where TEnumeration : Enumeration
        => type
            .GetFields(BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.Public)
            .Select(f => f.GetValue(null))
            .OfType<TEnumeration>()
            .OrderBy(f => f.SortOrder)
            .ToArray();
}