namespace Rosie.Nutshell.Types.Common;

public record SearchRequest(string Query, int Limit = 50);