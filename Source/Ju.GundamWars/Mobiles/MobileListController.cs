using Ju.GundamWars.CoUnits;
using Ju.GundamWars.Const;
using Ju.GundamWars.Domain.CoUnits;
using Ju.GundamWars.Domain.Mobiles;
using Ju.GundamWars.Domain.Mobiles.Entities;
using Ju.GundamWars.Domain.Mobiles.Factories;
using Ju.GundamWars.Domain.Pilots;
using Ju.GundamWars.Domain.Supports;
using Ju.GundamWars.Domain.Systems;
using Ju.GundamWars.Pilots;
using Ju.GundamWars.Supports;

namespace Ju.GundamWars.Mobiles;

public class MobileListController(
    MobileEntryViewModel viewModel,
    MobileFactory entityFactory,
    MobileSubjectFactory subjectFactory,
    PilotEntryViewModel pilotEntryViewModel,
    SupportEntryViewModel supportEntryViewModel,
    CoUnitEntryViewModel CoUnitEntryViewModel,
    WindowStatus windowStatus)
    : ListControllerBase<Mobile, MobileSubject, MobileEntryViewModel, MobileFactory, MobileSubjectFactory>(viewModel, entityFactory, subjectFactory)
{

    protected override void MoveToEntry() => windowStatus.SlideIndexType = SlideIndexType.MobileEntry;

    public override void OpenEntryAsCopy(MobileSubject subject)
    {
        var newSubject = SubjectFactory.Create(EntityFactory.Create(subject));
        // exclude members
        newSubject.Id = 0;
        newSubject.Pair = null;
        newSubject.Support1 = null;
        newSubject.Support2 = null;
        newSubject.Support3 = null;
        newSubject.Support4 = null;
        newSubject.CoUnit1 = null;
        newSubject.CoUnit2 = null;
        newSubject.CoUnit3 = null;
        OpenEntry(EntryMode.Copy, newSubject);
    }

    public void OpenEntryAsNewForMa() => OpenEntry(EntryMode.New, SubjectFactory.CreateForMa());

    public void OpenPilotAsEdit(PilotSubject pilot)
    {
        pilotEntryViewModel.SetEntry(EntryMode.Edit, pilot);
        windowStatus.SlideIndexType = SlideIndexType.PilotEntry;
    }

    public void OpenSupportAsEdit(SupportSubject support)
    {
        supportEntryViewModel.SetEntry(EntryMode.Edit, support);
        windowStatus.SlideIndexType = SlideIndexType.SupportEntry;
    }

    public void OpenCoUnitAsEdit(CoUnitSubject CoUnit)
    {
        CoUnitEntryViewModel.SetEntry(EntryMode.Edit, CoUnit);
        windowStatus.SlideIndexType = SlideIndexType.CoUnitEntry;
    }

}
