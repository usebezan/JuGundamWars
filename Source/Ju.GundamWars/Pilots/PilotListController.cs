using Ju.GundamWars.Const;
using Ju.GundamWars.Domain.Pilots;
using Ju.GundamWars.Domain.Pilots.Entities;
using Ju.GundamWars.Domain.Pilots.Factories;
using Ju.GundamWars.Domain.Systems;

namespace Ju.GundamWars.Pilots;

public class PilotListController(PilotEntryViewModel viewModel, PilotFactory entityFactory, PilotSubjectFactory subjectFactory, WindowStatus windowStatus)
    : ListControllerBase<Pilot, PilotSubject, PilotEntryViewModel, PilotFactory, PilotSubjectFactory>(viewModel, entityFactory, subjectFactory)
{

    protected override void MoveToEntry() => windowStatus.SlideIndexType = SlideIndexType.PilotEntry;

    public void OpenEntryAsNewForMa() => OpenEntry(EntryMode.New, SubjectFactory.CreateForMa());

}
