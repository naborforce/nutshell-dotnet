using System.Text.Json;

namespace Rosie.Nutshell.Extensions;

public static class ObjectExtensions
{
    private static readonly JsonSerializerOptions? _jsonSerializerOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public static string ToJson(this object input, JsonSerializerOptions options) 
        => JsonSerializer.Serialize(input, options);

    public static string ToJson(this object? input) => JsonSerializer.Serialize(input, _jsonSerializerOptions);
}