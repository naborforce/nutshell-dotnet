namespace Rosie.Nutshell.Types.Internal;

internal record RpcResponse<T>(T? Result, RpcError? Error = null);