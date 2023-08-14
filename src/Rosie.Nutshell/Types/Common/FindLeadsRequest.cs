namespace Rosie.Nutshell.Types.Common;

public record FindLeadsRequest(
    int? Status,
    int? Filter,
    int? AccountId,
    int? ContactId,
    int? MilestoneId,
    int? OutcomeId,
    int? StagesetId,
    int[]? MilestoneIds,
    int[]? StagesetIds,
    string OrderBy = "name",
    string OrderDirection = "ASC",
    int Limit = 50,
    int Page = 1
);