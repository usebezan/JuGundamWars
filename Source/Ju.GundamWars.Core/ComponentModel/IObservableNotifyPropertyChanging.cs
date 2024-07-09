using System.ComponentModel;

namespace Ju.GundamWars.ComponentModel;

public interface IObservableNotifyPropertyChanging : INotifyPropertyChanging
{
    new IObservable<PropertyChangingEventArgs> PropertyChanging { get; }
}
