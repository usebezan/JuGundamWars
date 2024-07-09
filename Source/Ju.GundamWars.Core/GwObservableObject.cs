using CommunityToolkit.Mvvm.ComponentModel;
using Ju.GundamWars.ComponentModel;
using System.ComponentModel;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace Ju.GundamWars;

public abstract partial class GwObservableObject : ObservableObject, IDisposable, IObservableNotifyPropertyChanged
{

    #region ==== Implementation of INotifyPropertyChanged ====

    public new IObservable<PropertyChangedEventArgs> PropertyChanged =>
        Observable
            .FromEventPattern<PropertyChangedEventHandler, PropertyChangedEventArgs>(
                handler => base.PropertyChanged += handler,
                handler => base.PropertyChanged -= handler)
            .Select(x => x.EventArgs);

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
        System.Diagnostics.Debug.WriteLine($"Dispose {this}.");
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    #endregion

}
