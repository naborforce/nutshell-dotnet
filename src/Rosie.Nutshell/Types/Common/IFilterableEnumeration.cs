namespace Rosie.Nutshell.Types.Common;

public interface IFilterableEnumeration<TEnumeration>
    where TEnumeration : Enumeration
{
    IEnumerable<TEnumeration> FilterAll(IEnumerable<TEnumeration> collection);

    bool ApplyFilter(TEnumeration input) => true;
}