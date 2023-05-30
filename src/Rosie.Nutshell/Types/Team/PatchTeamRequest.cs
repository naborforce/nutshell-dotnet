namespace Rosie.Nutshell.Types.Team;

// todo: discover the schema for the parameter Task
public record PatchTeamRequest(int TeamId, string Rev, dynamic Team);