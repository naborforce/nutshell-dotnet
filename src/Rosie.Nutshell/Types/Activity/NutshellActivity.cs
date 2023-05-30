using System;
using Rosie.Nutshell.Types.Common;
using Rosie.Nutshell.Types.Lead;

namespace Rosie.Nutshell.Types.Activity;

public class NutshellActivity
{
    public int Id { get; init; }
    public string? EntityType { get; init; }
    public string? Rev { get; init; }
    public string? Name { get; init; }
    public string? Description { get; init; }
    public NutshellActivityType? ActivityType { get; init; }
    public NutshellLead? Lead { get; init; }
    public NutshellLead[]? Leads { get; init; }
    public DateTime? StartTime { get; init; }
    public DateTime? EndTime { get; init; }
    public bool? IsAllDay { get; init; }
    public bool? IsFlagged { get; init; }
    public int? Status { get; init; }
    public string? LogDescription { get; init; }
    public NutshellNote? LogNote { get; init; }
    public NutshellEntityStub? LoggedBy { get; init; }
    public NutshellEntityStub[]? Participants { get; init; }
    public NutshellActivity? Followup { get; init; }
    public NutshellActivity? FollowupTo { get; init; }
    public DateTime? DeletedTime { get; init; }
    public DateTime? ModifiedTime { get; init; }
    public DateTime? CreatedTime { get; init; }
}