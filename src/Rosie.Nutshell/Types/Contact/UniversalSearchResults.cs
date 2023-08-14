using Rosie.Nutshell.Types.Account;

namespace Rosie.Nutshell.Types.Contact;

public class UniversalSearchResults
{
    public NutshellContactStub[] Contacts { get; init; }
    public NutshellAccountStub[] Accounts { get; init; }
}