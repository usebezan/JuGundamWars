using System;
using System.ComponentModel;


namespace Ju.GundamWars.ViewModels
{

    public interface IEntryViewModel : IDisposable, INotifyPropertyChanged
    {

        public bool IsAdd { get; }
        public bool IsDirty { get; }


        public void Reload();

    }

}
