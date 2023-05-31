namespace Rosie.Nutshell.Types.Common;

public class NutshellMethods<TResponse, TRequest> : NutshellMethods
    where TRequest : class
{
    internal NutshellMethods(string name) : base(name)
    {
    }
}

public class NutshellFunc<TResponse> : NutshellMethods<TResponse, object>
{
    internal NutshellFunc(string name) : base(name)
    {
    }
}

public class NutshellAction<TRequest> : NutshellMethods<object, TRequest> where TRequest : class
{
    internal NutshellAction(string name) : base(name)
    {
    }
}