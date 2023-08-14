using Rosie.Nutshell.Types.Account;
using Rosie.Nutshell.Types.Common;
using Rosie.Nutshell.Types.Contact;

namespace Rosie.Nutshell.Types.Lead;

public class NutshellLead : NutshellLeadStub
{
    public string EntityType { get; init; }
    public string HtmlUrl { get; init; }
    public string AvatarUrl { get; init; }
    public string[] Tags { get; init; }
    public string Description { get; init; }
    public DateTime CreatedTime { get; init; }
    public NutshellEntityStub Creator { get; init; }
    public NutshellAccount PrimaryAccount { get; init; }
    public NutshellMilestone Milestone { get; init; }
    public NutshellStageSet Stageset { get; init; }
    public Dictionary<int, int> ActivitiesCount { get; init; }
    public int Status { get; init; }
    public int Confidence { get; init; }
    public int Completion { get; init; }
    public string Urgency { get; init; }
    public bool IsOverdue { get; init; }
    public NutshellEntityStub Market { get; init; }
    public NutshellEntityStub Assignee { get; init; }
    public NutshellEntityStub Competitors { get; init; }
    public NutshellContact[] Contacts { get; init; }
    public NutshellAccount[] Accounts { get; init; }
    public DateTime? DueTime { get; init; }
    public DateTime? NextStepDueTime { get; init; }
    public NutshellNote[] Notes { get; init; }
    public DateTime? LastContactedDate { get; init; }
    public DateTime? DeletedTime { get; init; }
    public int Priority { get; init; }
}