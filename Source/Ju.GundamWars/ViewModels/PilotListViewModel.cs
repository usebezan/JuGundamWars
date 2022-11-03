using Ju.GundamWars.Models;
using Ju.GundamWars.Models.Repositories;
using Ju.GundamWars.Models.Services;
using System;
using static Ju.GundamWars.App;


namespace Ju.GundamWars.ViewModels
{

    public class PilotListViewModel : ListViewModelBase<PilotModel, PilotModelRepository, PilotFilterViewModel, PilotEntryViewModel, PilotDisplayViewModel>
    {

        public PilotListViewModel(PilotModelRepository repository, PilotFilterViewModel filterViewModel, WindowService windowService)
            : base(repository, filterViewModel, windowService)
        {
        }


        protected override PilotEntryViewModel CreateEntryViewModel() =>
            new(
                EntryType.Add,
                PilotModel.Create(),
                GetRequiredService<PilotSkillRepository>(),
                GetRequiredService<PilotAbilityRepository>(),
                GetRequiredService<SerialRepository>(),
                GetRequiredService<MiscRepository>(),
                WindowService);

        protected override PilotDisplayViewModel CreateDisplayViewModel(PilotModel model) =>
            new(model, GetRequiredService<MiscRepository>(), WindowService);

    }

}
