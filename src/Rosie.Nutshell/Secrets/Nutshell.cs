using Rosie.Platform;

namespace Rosie.Nutshell.Secrets;

/// <summary>
/// This is a simple class that contains credentials necessary to access the Nutshell API.  There are two constructors:
/// one that requires a username and an API key, and one that uses environment variables to populate the username and
/// API key.  The environment variables are NUTSHELL_USERNAME and NUTSHELL_API_KEY, respectively.  You can also specify
/// those two environment variables in a .env file in the root of your project.
/// </summary>
public record Nutshell
{
    static Nutshell() => DotEnv.Load(".env");
    
    /// <summary>
    /// This constructor requires a username and an API key.
    /// </summary>
    public Nutshell(string? username, string? apiKey)
    {
        ArgumentNullException.ThrowIfNull(username, nameof(username));
        ArgumentNullException.ThrowIfNull(apiKey, nameof(apiKey));

        ThrowIfParameterIsEmpty(username, nameof(username));
        ThrowIfParameterIsEmpty(apiKey, nameof(apiKey));

        Username = username;
        ApiKey = apiKey;
    }

    /// <summary>
    /// This constructor uses environment variables to populate the username and API key.  The environment variables are
    /// NUTSHELL_USERNAME and NUTSHELL_API_KEY, respectively.  You can also specify those two environment variables in
    /// a .env file in the root of your project.
    /// </summary>
    public Nutshell() : this(
        Environment.GetEnvironmentVariable("NUTSHELL_USERNAME"),
        Environment.GetEnvironmentVariable("NUTSHELL_API_KEY"))
    {
    }

    private static void ThrowIfParameterIsEmpty(string username, string name)
    {
        if (string.IsNullOrEmpty(username))
        {
            throw new ArgumentException("Value cannot be null or empty.", name);
        }
    }

    public string Username { get; }
    public string ApiKey { get; }
}