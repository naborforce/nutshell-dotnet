using System.Runtime.CompilerServices;

namespace Rosie.Nutshell.Types.Common;

public class AsyncLazy<T> : Lazy<Task<T>>, IAsyncLazy<T>
{
    public AsyncLazy(Func<Task<T>> taskFactory) :
        base(() => System.Threading.Tasks.Task.Factory.StartNew(taskFactory).Unwrap())
    {
    }

    public TaskAwaiter<T> GetAwaiter() => Value.GetAwaiter();

    public event EventHandler<IAsyncLazy<T>> Disposing = delegate { }; 

    public void Dispose()
    {
        OnDisposing(this);
        GC.SuppressFinalize(this);
    }

    protected virtual void OnDisposing(AsyncLazy<T> obj)
    {
        Disposing?.Invoke(this, obj);
    }
}