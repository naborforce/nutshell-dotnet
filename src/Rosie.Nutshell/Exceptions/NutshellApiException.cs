using System;

namespace Rosie.Nutshell.Exceptions;

public sealed class NutshellApiException : Exception
{
    public int Code { get; }
    public object? Data { get; }

    public NutshellApiException(string message, int code = 0, object? data = null) : base(message)
    {
        Code = code;
        Data = data;
    }

}