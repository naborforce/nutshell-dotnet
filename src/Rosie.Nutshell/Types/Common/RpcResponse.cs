namespace Rosie.Nutshell.Types.Common;

internal record RpcResponse<T>(T? Result, RpcError? Error = null);