using Rosie.Nutshell.Types.Common;

namespace Rosie.Nutshell;

/// <summary>
/// The Nutshell API is an industry-standard JSON-RPC API that allows you to retrieve and modify your data at any time.
/// Nutshell also provides a minimal HTTP POST API for simple web-to-lead forms.  The data you store in Nutshell belongs
/// to you, and we've designed our open APIs to make it possible for you to work with it however you wish. Please
/// contact us with any questions on using the API.
/// </summary>
public interface INutshellGateway
{
    /// <summary>
    /// Calls a Nutshell API method with an input and expects an output.
    /// </summary>
    /// <param name="method">Discover methods as static fields here: <see cref="NutshellMethods"/></param>
    /// <param name="input">The input to the method.</param>
    /// <typeparam name="TOut">The expected output type.</typeparam>
    /// <typeparam name="TIn">The input type.</typeparam>
    /// <returns></returns>
    Task<TOut> CallAsync<TOut, TIn>(NutshellMethods<TOut, TIn> method, TIn input) where TIn : class;

    /// <summary>
    /// Calls a Nutshell API method without any input and expects an output.
    /// </summary>
    /// <param name="method">Discover methods as static fields here: <see cref="NutshellMethods"/></param>
    /// <typeparam name="TOut">The expected output type.</typeparam>
    /// <returns></returns>
    Task<TOut> CallAsync<TOut>(NutshellFunc<TOut> method);
    
    /// <summary>
    /// Calls a Nutshell API method with an input and expects no output.
    /// </summary>
    /// <param name="method">Discover methods as static fields here: <see cref="NutshellMethods"/></param>
    /// <param name="input">The input to the method.</param>
    /// <typeparam name="TIn">The input type.</typeparam>
    /// <returns></returns>
    Task CallAsync<TIn>(NutshellAction<TIn> method, TIn input) where TIn : class;
}