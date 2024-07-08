using Ju.GundamWars.Const;
using Ju.GundamWars.Domain.Supports;
using Ju.GundamWars.Domain.Supports.Entities;
using Ju.GundamWars.Domain.Supports.Factories;
using Ju.GundamWars.Domain.Systems;

namespace Ju.GundamWars.Supports;

public class SupportListController(SupportEntryViewModel viewModel, SupportFactory entityFactory, SupportSubjectFactory subjectFactory, WindowStatus windowStatus)
    : ListControllerBase<Support, SupportSubject, SupportEntryViewModel, SupportFactory, SupportSubjectFactory>(viewModel, entityFactory, subjectFactory)
{

    protected override void MoveToEntry() => windowStatus.SlideIndexType = SlideIndexType.SupportEntry;

    public void OpenEntryAsNewForMa() => OpenEntry(EntryMode.New, SubjectFactory.CreateForMa());

}
