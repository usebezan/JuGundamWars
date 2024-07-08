using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace Ju.GundamWars;

public abstract partial class GwObservableValidator : ObservableValidator, IDisposable, IGwNotifyPropertyChanged
{

    public new void ValidateAllProperties() => base.ValidateAllProperties();

    #region ==== Implementation of INotifyPropertyChanged ====

    public new IObservable<string?> PropertyChanged =>
        Observable
            .FromEventPattern<PropertyChangedEventHandler, PropertyChangedEventArgs>(
                handler => base.PropertyChanged += handler,
                handler => base.PropertyChanged -= handler)
            .Select(x => x.EventArgs.PropertyName);

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
