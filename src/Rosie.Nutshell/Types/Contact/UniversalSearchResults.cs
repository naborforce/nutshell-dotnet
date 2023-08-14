using Rosie.Nutshell.Types.Account;

namespace Rosie.Nutshell.Types.Contact;

public class UniversalSearchResults
{
    public NutshellContact[] Contacts { get; init; }
    public NutshellAccount[] Accounts { get; init; }
}