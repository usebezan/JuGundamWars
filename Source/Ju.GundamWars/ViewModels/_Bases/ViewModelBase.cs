using Ju.GundamWars.Models.Services;
using System;


namespace Ju.GundamWars.ViewModels
{

    public abstract class ViewModelBase : DisposableBindableBase
    {

        public ViewModelBase(WindowService windowService)
        {
            WindowService = windowService ?? throw new ArgumentNullException(nameof(windowService));
        }


        protected WindowService WindowService { get; }

    }

}
