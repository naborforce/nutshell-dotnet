namespace Rosie.Nutshell.Types.Geo;

public class NutshellAddress
{
    public string Name { get; init; }
    public NutshellLocation Location { get; init; }
    public string LocationAccuracy { get; init; }
    public string Address1 { get; init; }
    public string Address2 { get; init; }
    public string Address3 { get; init; }
    public string City { get; init; }
    public string State { get; init; }
    public string PostalCode { get; init; }
    public string Country { get; init; }
    public string Timezone { get; init; }
}