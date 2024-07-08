using System.Reactive.Disposables;

namespace Ju.GundamWars;

public abstract class DisposableObjectBase : IDisposable
{

    #region ==== Implementation of IDisposable ====

    private bool disposed = false;

    protected CompositeDisposable Disposables { get; } = [];

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                Disposables.Dispose();
            }
            disposed = true;
        }
    }

    public void Dispose()
    {
        System.Diagnostics.Debug.WriteLine($"Dispose {this}.");
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    #endregion

}
