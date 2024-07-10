using CommunityToolkit.Mvvm.ComponentModel;
using Ju.GundamWars.ComponentModel;
using System.ComponentModel;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace Ju.GundamWars.Commons.Domain.Model;

public partial class ModelBase : ObservableValidator, IDisposable, IObservableNotifyPropertyChanging, IObservableNotifyPropertyChanged
{

    public ModelBase()
    {
        System.Diagnostics.Debug.WriteLine($"Create {this}.");
    }


    #region ==== Implementation of IObservableNotifyPropertyChanging ====

    event PropertyChangingEventHandler? INotifyPropertyChanging.PropertyChanging
    {
        add { base.PropertyChanging += value; }
        remove { base.PropertyChanging -= value; }
    }

    public new IObservable<PropertyChangingEventArgs> PropertyChanging =>
        Observable
            .FromEventPattern<PropertyChangingEventHandler, PropertyChangingEventArgs>(
                handler => base.PropertyChanging += handler,
                handler => base.PropertyChanging -= handler)
            .Select(x => x.EventArgs);

    #endregion

    #region ==== Implementation of IObservableNotifyPropertyChanged ====

    event PropertyChangedEventHandler? INotifyPropertyChanged.PropertyChanged
    {
        add { base.PropertyChanged += value; }
        remove { base.PropertyChanged -= value; }
    }

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
