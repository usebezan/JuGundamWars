using Ju.GundamWars.Const;
using Ju.GundamWars.CoMobiles;
using Ju.GundamWars.Domain.CoMobiles;
using Ju.GundamWars.Domain.CoMobiles.Entities;
using Ju.GundamWars.Domain.CoMobiles.Factories;
using Ju.GundamWars.Domain.Systems;

namespace Ju.GundamWars.CoMobiles;

public class CoMobileListController(CoMobileEntryViewModel viewModel, CoMobileFactory entityFactory, CoMobileSubjectFactory subjectFactory, WindowStatus windowStatus)
    : ListControllerBase<CoMobile, CoMobileSubject, CoMobileEntryViewModel, CoMobileFactory, CoMobileSubjectFactory>(viewModel, entityFactory, subjectFactory)
{

    protected override void MoveToEntry() => windowStatus.SlideIndexType = SlideIndexType.CoMobileEntry;

    public void OpenEntryAsNewForMa() => OpenEntry(EntryMode.New, SubjectFactory.CreateForMa());

}
