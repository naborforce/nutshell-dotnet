namespace Rosie.Nutshell.Types.Lead;

/*
 *
 * {
    "id": "1000",
    "entityType": "Lead_Outcomes",
    "rev": "1",
    "description": "Won the lead",
    "type": 10   // STATUS_WON = 10; STATUS_LOST = 11; STATUS_CANCELLED = 12;
}
 */
public record NutshellLeadOutcome (int Id, string Rev, string Description, OutcomeType Type);