using Microsoft.Extensions.Logging;

namespace Rosie.Nutshell.Types.Common;

public abstract class Enumeration : IComparable
{
    protected static ILogger? Logger { get; set; }

    private int? _sortOrder;

    public string Name { get; }

    public int Id { get; }

    // ReSharper disable once VirtualMemberNeverOverridden.Global
    // ReSharper disable once UnusedMember.Global
    // ReSharper disable once MemberCanBeProtected.Global
    public int SortOrder
    {
        get => _sortOrder ?? 0;
        // ReSharper disable once PropertyCanBeMadeInitOnly.Global
        set => _sortOrder = value;
    }

    public bool HasSortOrder => _sortOrder.HasValue;

    protected Enumeration(string name) : this(name.GetHashCode(), name)
    {
    }

    protected Enumeration(string name, int sortOrder) : this(name.GetHashCode(), name, sortOrder)
    {
    }

    protected Enumeration(int id, string name, int? sortOrder = null)
        => (Id, Name, this._sortOrder) = (id, name, sortOrder);

    /// <summary>
    /// Gets this object as a readable string representation
    /// </summary>
    public override string ToString() => Name;

    public static ICollection<TEnumeration> GetAll<TEnumeration>(GetAllBehavior behavior = GetAllBehavior.Filter)
        where TEnumeration : Enumeration
        => EnumerationFactory.GetAll<TEnumeration>(behavior);

    public override bool Equals(object? obj)
    {
        if (obj is not Enumeration otherValue)
        {
            return false;
        }

        var typeMatches = GetType() == obj.GetType();
        var valueMatches = Id.Equals(otherValue.Id);

        return typeMatches && valueMatches;
    }

    protected bool Equals(Enumeration other)
    {
        return Name == other.Name && Id == other.Id;
    }

    public override int GetHashCode() => Name.GetHashCode() ^ Id.GetHashCode();

    public int CompareTo(object? other) =>
        other switch
        {
            Enumeration e => Id.CompareTo(e.Id),
            _ => Id.CompareTo(null)
        };
    
    public static TEnumeration Parse<TEnumeration>(string name) where TEnumeration : Enumeration
        => GetAll<TEnumeration>()
            .Single(e => e.Name.Trim().Equals(name.Trim(), StringComparison.CurrentCultureIgnoreCase));

    public static bool TryParse<TEnumeration>(string name, out TEnumeration? value) where TEnumeration : Enumeration
    {
        value = null;
        try
        {
            value = Parse<TEnumeration>(name);
            // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
            return value != null;
        }
        catch
        {
            return false;
        }
    }

    public static void SetLoggerIfEmpty(ILogger<Enumeration>? logger) => Logger ??= logger;
}