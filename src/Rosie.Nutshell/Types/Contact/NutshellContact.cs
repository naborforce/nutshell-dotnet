using System;
using System.Security.Policy;
using Rosie.Nutshell.Types.Account;
using Rosie.Nutshell.Types.Channels;
using Rosie.Nutshell.Types.Common;
using Rosie.Nutshell.Types.Geo;
using Rosie.Nutshell.Types.Lead;

namespace Rosie.Nutshell.Types.Contact;

public class NutshellContact
{
    public int Id { get; init; }
    public string EntityType { get; init; }
    public string Rev { get; init; }
    public NutshellName Name { get; init; }
    public string HtmlUrl { get; init; }
    public string AvatarUrl { get; init; }
    public string Description { get; init; }
    public string LegacyId { get; init; }
    public string[] Tags { get; init; }
    public NutshellEntityStub Creator { get; init; }
    public NutshellLead[] Leads { get; init; }
    public NutshellAccount[] Accounts { get; init; }
    public int ContactedCount { get; init; }
    public KeyedAndIndexedSet<NutshellAddress> Address { get; init; }
    public KeyedAndIndexedSet<NutshellPhone> Phone { get; init; }
    public KeyedAndIndexedSet<Url> Url { get; init; }
    public KeyedAndIndexedSet<string> Email { get; init; }
    public NutshellNote[] Notes { get; init; }
    public NutshellEntityStub Territory { get; init; }
    public NutshellContact[] MergedInto { get; init; }
    public DateTime? LastContactedDate { get; init; }
    public DateTime? DeletedTime { get; init; }
    public DateTime? ModifiedTime { get; init; }
    public DateTime? CreatedTime { get; init; }
}