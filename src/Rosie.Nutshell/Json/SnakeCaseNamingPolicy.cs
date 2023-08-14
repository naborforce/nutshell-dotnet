using System.Text.Json;
using Rosie.Nutshell.Extensions;

namespace Rosie.Nutshell.Json;

public class SnakeCaseNamingPolicy : JsonNamingPolicy
{
    public static SnakeCaseNamingPolicy Instance { get; } = new();

    public override string ConvertName(string name) => name.ToSnakeCase();
}