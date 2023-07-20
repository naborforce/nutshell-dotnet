using System.Runtime.CompilerServices;

namespace Rosie.Nutshell.Types.Common;

public interface IAsyncLazy<T> : IDisposable
{
    event EventHandler<IAsyncLazy<T>> Disposing;
    bool IsValueCreated { get; }
    Task<T> Value { get; }
    TaskAwaiter<T> GetAwaiter();
}