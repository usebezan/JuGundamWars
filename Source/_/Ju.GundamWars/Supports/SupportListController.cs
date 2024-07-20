using Ju.GundamWars.Const;
using Ju.GundamWars.Domain.Systems;
using Ju.GundamWars.Supports.Domain;
using Ju.GundamWars.Supports.Domain.Entities;
using Ju.GundamWars.Supports.Domain.Factories;

namespace Ju.GundamWars.Supports;

public class SupportListController(SupportEntryViewModel viewModel, SupportFactory entityFactory, SupportSubjectFactory subjectFactory, WindowStatus windowStatus)
    : ListControllerBase<Support, SupportSubject, SupportEntryViewModel, SupportFactory, SupportSubjectFactory>(viewModel, entityFactory, subjectFactory)
{

    protected override void MoveToEntry() => windowStatus.SlideIndexType = SlideIndexType.SupportEntry;

    public void OpenEntryAsNewForMa() => OpenEntry(EntryMode.New, SubjectFactory.CreateForMa());

}
