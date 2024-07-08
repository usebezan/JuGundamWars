using System.ComponentModel;

namespace Ju.GundamWars.ComponentModel;

public interface IObservableNotifyPropertyChanged : INotifyPropertyChanged
{
    new IObservable<PropertyChangedEventArgs> PropertyChanged { get; }
}
