using Ju.GundamWars.Models.Entities;
using Ju.GundamWars.Models.Repositories;
using Ju.GundamWars.Models.Services;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Data;


namespace Ju.GundamWars.ViewModels
{

    public class MobileSuitFilterViewModel : FilterViewModelBase<MobileSuitDisplayViewModel>
    {

        public MobileSuitFilterViewModel(SerialRepository serialRepository, WindowService windowService)
            : base(serialRepository, windowService)
        {
        }


        protected override bool IsEmpty => base.IsEmpty;


        protected override bool Filter(MobileSuitDisplayViewModel viewModel)
        {
            return true;
        }

        public override void Clear()
        {
            IsReady = false;
            IsReady = true;
            Refilter();
        }

    }

}
