using System;
using System.Collections.ObjectModel;
using System.ComponentModel;


namespace Ju.GundamWars.ViewModels
{

    public interface IFilterViewModel<TDisplayViewModel> : IDisposable, INotifyPropertyChanged
        where TDisplayViewModel : IDisplayViewModel
    {

        public void Initialize(ReadOnlyObservableCollection<TDisplayViewModel> items);
        public void Clear();

    }

}
