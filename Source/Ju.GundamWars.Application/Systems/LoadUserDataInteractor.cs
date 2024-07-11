using Ju.GundamWars.Application.CoMobiles.Repositories;
using Ju.GundamWars.Application.Cuspas.Repositories;
using Ju.GundamWars.Application.Mobiles.Repositories;
using Ju.GundamWars.Application.Pilots.Repositories;
using Ju.GundamWars.Application.Supports.Repositories;
using Ju.GundamWars.Application.Systems.Repositories;
using Ju.GundamWars.Application.Tags.Repositories;

namespace Ju.GundamWars.Application.Systems;

public class LoadUserDataInteractor(
    IMobileSSkillRepository mobileSSkillRepository,
    IMobileSSkillInventory mobileSSkillInventory,

    IPilotAbilityRepository pilotAbilityRepository,
    IPilotAbilityInventory pilotAbilityInventory,

    IPilotSkillRepository pilotSkillRepository,
    IPilotSkillInventory pilotSkillInventory,

    ISerialRepository serialRepository,
    ISerialInventory serialInventory,

    ISupportBadgeRepository supportBadgeRepository,
    ISupportBadgeInventory supportBadgeInventory,

    ISupportSlotRepository supportSlotRepository,
    ISupportSlotInventory supportSlotInventory,

    ICoMobileRepository CoMobileRepository,
    CoMobileSubjectFactory CoMobileSubjectFactory,
    ICoMobileInventory CoMobileInventory,

    ICuspaRepository cuspaRepository,
    CuspaSubjectFactory cuspaSubjectFactory,
    ICuspaInventory cuspaInventory,

    IMobileRepository mobileRepository,
    MobileSubjectFactory mobileSubjectFactory,
    IMobileInventory mobileInventory,

    IPilotRepository pilotRepository,
    PilotSubjectFactory pilotSubjectFactory,
    IPilotInventory pilotInventory,

    ISupportRepository supportRepository,
    SupportSubjectFactory supportSubjectFactory,
    ISupportInventory supportInventory,

    ITagRepository tagRepository,
    TagSubjectFactory tagSubjectFactory,
    ITagInventory tagInventory,

    IProgressPresenter presenter)
    : ILoadUserDataUseCase
{

    public int ProgressCount => 12;


    public void Handle()
    {
        presenter.ShowMessage("Loading data...");

        // 1
        presenter.Increment(() => mobileSSkillInventory.ReAddRange(mobileSSkillRepository.SelectAll()));
        // 2
        presenter.Increment(() => pilotAbilityInventory.ReAddRange(pilotAbilityRepository.SelectAll()));
        // 3
        presenter.Increment(() => pilotSkillInventory.ReAddRange(pilotSkillRepository.SelectAll()));
        // 4
        presenter.Increment(() => serialInventory.ReAddRange(serialRepository.SelectAll()));
        // 5
        presenter.Increment(() => supportBadgeInventory.ReAddRange(supportBadgeRepository.SelectAll()));
        // 6
        presenter.Increment(() => supportSlotInventory.ReAddRange(supportSlotRepository.SelectAll()));
        // 7
        presenter.Increment(() => tagInventory.ReAddRange(tagRepository.SelectAll().Select(tagSubjectFactory.Create)));

        // 8
        presenter.Increment(() => CoMobileInventory.ReAddRange(CoMobileRepository.SelectAll().Select(CoMobileSubjectFactory.Create)));
        // 9
        presenter.Increment(() => cuspaInventory.ReAddRange(cuspaRepository.SelectAll().Select(cuspaSubjectFactory.Create)));
        // 10
        presenter.Increment(() => pilotInventory.ReAddRange(pilotRepository.SelectAll().Select(pilotSubjectFactory.Create)));
        // 11
        presenter.Increment(() => supportInventory.ReAddRange(supportRepository.SelectAll().Select(supportSubjectFactory.Create)));
        // 12
        presenter.Increment(() =>
        {
            mobileInventory.ReAddRange(mobileRepository.SelectAll().Select(mobileSubjectFactory.Create));
            foreach (var mobile in mobileInventory)
            {
                mobile.Pair = mobileInventory.FirstOrDefault(s => s.Id == mobile.PairId);
            }
        });
    }

}
