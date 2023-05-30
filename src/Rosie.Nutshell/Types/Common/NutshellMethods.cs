namespace Rosie.Nutshell.Types.Common;

public class NutshellMethods<TResponse, TRequest> : NutshellMethods
    where TRequest : class
{
    internal NutshellMethods(string name) : base(name)
    {
    }
}