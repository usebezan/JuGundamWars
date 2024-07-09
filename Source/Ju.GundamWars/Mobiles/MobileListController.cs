using Ju.GundamWars.CoMobiles;
using Ju.GundamWars.Const;
using Ju.GundamWars.Domain.CoMobiles;
using Ju.GundamWars.Domain.Systems;
using Ju.GundamWars.Mobiles.Domain;
using Ju.GundamWars.Mobiles.Domain.Entities;
using Ju.GundamWars.Mobiles.Domain.Factories;
using Ju.GundamWars.Pilots;
using Ju.GundamWars.Pilots.Domain;
using Ju.GundamWars.Supports;
using Ju.GundamWars.Supports.Domain;

namespace Ju.GundamWars.Mobiles;

public class MobileListController(
    MobileEntryViewModel viewModel,
    MobileFactory entityFactory,
    MobileSubjectFactory subjectFactory,
    PilotEntryViewModel pilotEntryViewModel,
    SupportEntryViewModel supportEntryViewModel,
    CoMobileEntryViewModel CoMobileEntryViewModel,
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
        newSubject.CoMobile1 = null;
        newSubject.CoMobile2 = null;
        newSubject.CoMobile3 = null;
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

    public void OpenCoMobileAsEdit(CoMobileSubject CoMobile)
    {
        CoMobileEntryViewModel.SetEntry(EntryMode.Edit, CoMobile);
        windowStatus.SlideIndexType = SlideIndexType.CoMobileEntry;
    }

}
