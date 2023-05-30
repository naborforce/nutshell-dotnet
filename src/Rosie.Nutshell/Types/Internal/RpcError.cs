namespace Rosie.Nutshell.Types.Internal;

internal record RpcError(string Message, int Code, object? Data = null);