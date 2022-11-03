using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;


namespace Ju.GundamWars
{

    public abstract class BindableBase : INotifyPropertyChanged
    {

        protected bool TrySetValue<T>(ref T storage, T value, [CallerMemberName] string propertyName = null!) =>
            TrySetValue(ref storage, value, EqualityComparer<T>.Default.Equals, propertyName);

        protected bool TrySetValue<T>(ref T storage, T value, Func<T, T, bool> comparer, [CallerMemberName] string propertyName = null!)
        {
            if (comparer(storage, value)) return false;
            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected bool TrySetValue<T>(T oldValue, T value, Action<T> setter, [CallerMemberName] string propertyName = null!) =>
            TrySetValue(oldValue, value, setter, EqualityComparer<T>.Default.Equals, propertyName);

        protected bool TrySetValue<T>(T oldValue, T value, Action<T> setter, Func<T, T, bool> comparer, [CallerMemberName] string propertyName = null!)
        {
            if (comparer(oldValue, value)) return false;
            setter(value);
            OnPropertyChanged(propertyName);
            return true;
        }

        #region ==== Implementation of INotifyPropertyChanged ====

        private event PropertyChangedEventHandler? PrivatePropertyChanged;

        event PropertyChangedEventHandler? INotifyPropertyChanged.PropertyChanged
        {
            add { PrivatePropertyChanged += value; }
            remove { PrivatePropertyChanged -= value; }
        }

        public IObservable<string?> PropertyChanged =>
            Observable
                .FromEventPattern<PropertyChangedEventHandler, PropertyChangedEventArgs>(
                    handler => PrivatePropertyChanged += handler,
                    handler => PrivatePropertyChanged -= handler)
                .Select(x => x.EventArgs.PropertyName);

        private readonly ConcurrentDictionary<string, PropertyChangedEventArgs> argsCache = new();

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null!) =>
            PrivatePropertyChanged?.Invoke(this, argsCache.GetOrAdd(propertyName, p => new PropertyChangedEventArgs(p)));

        #endregion

    }

}
