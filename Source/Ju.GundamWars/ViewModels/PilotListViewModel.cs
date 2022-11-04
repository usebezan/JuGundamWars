using Ju.GundamWars.Models;
using Ju.GundamWars.Models.Repositories;
using Ju.GundamWars.Models.Services;
using System;
using static Ju.GundamWars.App;


namespace Ju.GundamWars.ViewModels
{

    public class PilotListViewModel : ListViewModelBase<PilotModel, PilotModelRepository, PilotFilteringViewModel, PilotEntryViewModel, PilotDisplayViewModel>
    {

        public PilotListViewModel(PilotModelRepository repository, PilotFilteringViewModel filteringViewModel, WindowService windowService)
            : base(repository, filteringViewModel, windowService)
        {
        }


        protected override PilotEntryViewModel CreateEntryViewModel() =>
            new(EntryType.Add, new(new(), GetRequiredService<PilotRepository>()), GetRequiredService<PilotOptionalViewModel>(), WindowService);

        protected override PilotDisplayViewModel CreateDisplayViewModel(PilotModel model) =>
            new(model, GetRequiredService<MiscRepository>(), WindowService);

    }

}
