namespace Rosie.Nutshell.Types.Common;

public class NutshellMethods<TResponse, TRequest> : NutshellMethods
    where TRequest : class
{
    public NutshellMethods(string name) : base(name)
    {
    }
}