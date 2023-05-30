using System.Text.Json.Serialization;

namespace Rosie.Nutshell.Types.Channels;

public record NutshellPhoneAndExtensions
{
    public NutshellPhone? Cell { get; init; } 
    public NutshellPhone? Home { get; init; } 
    public NutshellPhone? Work { get; init; } 
    
    [JsonPropertyName("--primary")]
    public NutshellPhone? Primary { get; init; } 
}