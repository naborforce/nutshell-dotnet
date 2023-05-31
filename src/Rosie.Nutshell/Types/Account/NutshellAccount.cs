using Rosie.Nutshell.Types.Channels;
using Rosie.Nutshell.Types.Common;
using Rosie.Nutshell.Types.Contact;
using Rosie.Nutshell.Types.Lead;

namespace Rosie.Nutshell.Types.Account;

public class NutshellAccount
{
    public int Id { get; set; }
    public string EntityType { get; set; } = "Accounts";
    public string Rev { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string LegacyId { get; set; } = null!;

    /// <summary>
    /// A url to open with a web browser for this entity
    /// </summary>
    public string HtmlUrl { get; set; } = null!;

    public string AvatarUrl { get; set; } = null!;
    public string[] Tags { get; set; } = null!;
    public NutshellEntityStub? Industry { get; set; } = null!;
    public NutshellIdNamePair? AccountType { get; set; } = null!;
    public NutshellEntityStub? Creator { get; set; } = null!;
    public NutshellLead[] Leads { get; set; } = null!;
    public NutshellContact[] Contacts { get; set; } = null!;
    public NutshellPhoneAndExtensions Phone { get; set; } = null!;

    public KeyedAndIndexedSet<Uri> Url { get; set; } = null!;
    public KeyedAndIndexedSet<string> Email { get; set; } = null!;

    public NutshellIdNamePair? Territory { get; set; } = null!;
    public NutshellAccount[] MergedInto { get; set; } = null!;
    public DateTime? LastContactedDate { get; set; } = null!;
    public DateTime? DeletedTime { get; set; } = null!;
    public DateTime? ModifiedTime { get; set; } = null!;
    public DateTime? CreatedTime { get; set; } = null!;
}