using Ju.GundamWars.Models;
using Ju.GundamWars.Models.Repositories;
using Ju.GundamWars.Models.Services;
using System;
using static Ju.GundamWars.App;


namespace Ju.GundamWars.ViewModels
{

    public class SupportListViewModel : ListViewModelBase<SupportModel, SupportModelRepository, SupportFilterViewModel, SupportEntryViewModel, SupportDisplayViewModel>
    {

        public SupportListViewModel(SupportModelRepository repository, SupportFilterViewModel filterViewModel, WindowService windowService)
            : base(repository, filterViewModel, windowService)
        {
        }


        protected override SupportEntryViewModel CreateEntryViewModel() =>
            new(
                EntryType.Add,
                SupportModel.Create(),
                GetRequiredService<SupportSlotRepository>(),
                GetRequiredService<SupportBadgeRepository>(),
                GetRequiredService<SerialRepository>(),
                GetRequiredService<MiscRepository>(),
                WindowService);

        protected override SupportDisplayViewModel CreateDisplayViewModel(SupportModel model) =>
            new(model, GetRequiredService<MiscRepository>(), WindowService);

    }

}
