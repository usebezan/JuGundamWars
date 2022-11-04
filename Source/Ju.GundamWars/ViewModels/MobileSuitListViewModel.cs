using Ju.GundamWars.Models;
using Ju.GundamWars.Models.Repositories;
using Ju.GundamWars.Models.Services;
using System;
using static Ju.GundamWars.App;


namespace Ju.GundamWars.ViewModels
{

    public class MobileSuitListViewModel : ListViewModelBase<MobileSuitModel, MobileSuitModelRepository, MobileSuitFilteringViewModel, MobileSuitEntryViewModel, MobileSuitDisplayViewModel>
    {

        public MobileSuitListViewModel(MobileSuitModelRepository repository, MobileSuitFilteringViewModel filteringViewModel, SerialRepository serialRepository, MiscRepository miscRepository, WindowService windowService)
            : base(repository, filteringViewModel, windowService)
        {
        }


        protected override MobileSuitEntryViewModel CreateEntryViewModel() =>
            null!;
            //new(
            //    EntryType.Add,
            //    new MobileSuitModel(GetRequiredService<MobileSuitRepository>()),
            //    GetRequiredService<MobileSuitSlotRepository>(),
            //    GetRequiredService<MobileSuitBadgeRepository>(),
            //    GetRequiredService<SerialRepository>(),
            //    GetRequiredService<MiscRepository>(),
            //    WindowService);

        protected override MobileSuitDisplayViewModel CreateDisplayViewModel(MobileSuitModel model) =>
            new(model, GetRequiredService<MiscRepository>(), WindowService);

    }

}
