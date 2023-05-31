namespace Rosie.Nutshell.Types.Common;

public class AbstractNutshellRpc<TResponse, TRequest> : NutshellRpc
    where TRequest : class
{
    internal AbstractNutshellRpc(string name) : base(name)
    {
    }
}

public class NutshellRpc<TResponse, TRequest> : AbstractNutshellRpc<TResponse, TRequest>
    where TRequest : class
{
    internal NutshellRpc(string name) : base(name)
    {
    }
}

public class NutshellFunc<TResponse> : AbstractNutshellRpc<TResponse, object>
{
    internal NutshellFunc(string name) : base(name)
    {
    }
}

public class NutshellAction<TRequest> : AbstractNutshellRpc<object, TRequest> where TRequest : class
{
    internal NutshellAction(string name) : base(name)
    {
    }
}