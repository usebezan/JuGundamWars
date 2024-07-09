using Ju.GundamWars.Const;
using Ju.GundamWars.CoUnits;
using Ju.GundamWars.Domain.CoUnits;
using Ju.GundamWars.Domain.CoUnits.Entities;
using Ju.GundamWars.Domain.CoUnits.Factories;
using Ju.GundamWars.Domain.Systems;

namespace Ju.GundamWars.CoMobiles;

public class CoUnitListController(CoUnitEntryViewModel viewModel, CoUnitFactory entityFactory, CoUnitSubjectFactory subjectFactory, WindowStatus windowStatus)
    : ListControllerBase<CoUnit, CoUnitSubject, CoUnitEntryViewModel, CoUnitFactory, CoUnitSubjectFactory>(viewModel, entityFactory, subjectFactory)
{

    protected override void MoveToEntry() => windowStatus.SlideIndexType = SlideIndexType.CoUnitEntry;

    public void OpenEntryAsNewForMa() => OpenEntry(EntryMode.New, SubjectFactory.CreateForMa());

}
