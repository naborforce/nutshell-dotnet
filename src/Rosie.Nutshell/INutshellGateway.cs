using Rosie.Nutshell.Types.Common;

namespace Rosie.Nutshell;

public interface INutshellGateway
{
    Task<TOut> CallAsync<TOut, TIn>(NutshellMethods<TOut, TIn> method, TIn input) where TIn : class;
}