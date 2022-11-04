using Ju.GundamWars.Models.Entities;
using Ju.GundamWars.Models.Repositories;
using Ju.GundamWars.Models.Services;
using System;
using System.Collections.ObjectModel;


namespace Ju.GundamWars.ViewModels
{

    public abstract class OptionalViewModelBase : ViewModelBase
    {

        public OptionalViewModelBase(SerialRepository serialRepository, WindowService windowService)
            : base(windowService)
        {
            OptionalSerials = serialRepository.Entities;
        }


        public ObservableCollection<Serial> OptionalSerials { get; }

    }

}
