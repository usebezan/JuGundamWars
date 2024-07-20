using Ju.GundamWars.Const;
using Ju.GundamWars.Domain.Systems;
using Ju.GundamWars.Pilots.Domain;
using Ju.GundamWars.Pilots.Domain.Entities;
using Ju.GundamWars.Pilots.Domain.Factories;

namespace Ju.GundamWars.Pilots;

public class PilotListController(PilotEntryViewModel viewModel, PilotFactory entityFactory, PilotSubjectFactory subjectFactory, WindowStatus windowStatus)
    : ListControllerBase<Pilot, PilotSubject, PilotEntryViewModel, PilotFactory, PilotSubjectFactory>(viewModel, entityFactory, subjectFactory)
{

    protected override void MoveToEntry() => windowStatus.SlideIndexType = SlideIndexType.PilotEntry;

    public void OpenEntryAsNewForMa() => OpenEntry(EntryMode.New, SubjectFactory.CreateForMa());

}
