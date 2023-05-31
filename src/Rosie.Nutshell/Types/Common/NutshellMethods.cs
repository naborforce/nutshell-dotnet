namespace Rosie.Nutshell.Types.Common;

public class AbstractNutshellMethods<TResponse, TRequest> : NutshellMethods
    where TRequest : class
{
    internal AbstractNutshellMethods(string name) : base(name)
    {
    }
}

public class NutshellMethods<TResponse, TRequest> : AbstractNutshellMethods<TResponse, TRequest>
    where TRequest : class
{
    internal NutshellMethods(string name) : base(name)
    {
    }
}

public class NutshellFunc<TResponse> : AbstractNutshellMethods<TResponse, object>
{
    internal NutshellFunc(string name) : base(name)
    {
    }
}

public class NutshellAction<TRequest> : AbstractNutshellMethods<object, TRequest> where TRequest : class
{
    internal NutshellAction(string name) : base(name)
    {
    }
}