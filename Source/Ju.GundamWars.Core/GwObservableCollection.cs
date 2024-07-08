using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace Ju.GundamWars;

public class GwObservableCollection<T> : ObservableCollection<T>, IDisposable
{

    public new void Add(T item)
    {
        lock (LockObj)
        {
            base.Add(item);
        }
        if (item is IDisposable disposable)
        {
            Disposables.Add(disposable);
        }
    }

    public virtual void AddRange(IEnumerable<T> collection) =>
        AddRange(collection.ToList());

    public virtual void AddRange(List<T> collection) =>
        collection.ForEach(Add);

    public virtual void ReAddRange(IEnumerable<T> collection) =>
        ReAddRange(collection.ToList());

    public virtual void ReAddRange(List<T> collection)
    {
        Clear();
        AddRange(collection);
    }

    public new void Clear()
    {
        lock (LockObj)
        {
            base.Clear();
        }
        Disposables.Clear();
    }

    public new IObservable<NotifyCollectionChangedEventArgs> CollectionChanged =>
        Observable
            .FromEventPattern<NotifyCollectionChangedEventHandler, NotifyCollectionChangedEventArgs>(
                handler => base.CollectionChanged += handler,
                handler => base.CollectionChanged -= handler)
            .Select(x => x.EventArgs);

    #region ==== for multiple threads ====

    // 複数スレッドからコレクション操作できるようにするためのロック オブジェクト
    public object LockObj { get; } = new();

    #endregion

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
        //System.Diagnostics.Debug.WriteLine($"Dispose {this}.");
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    #endregion

}
