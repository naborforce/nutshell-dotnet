namespace Rosie.Nutshell.Types.Common;

internal record RpcError(string Message, int Code, object? Data = null);