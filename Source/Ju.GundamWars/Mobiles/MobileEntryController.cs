using Ju.GundamWars.Const;
using Ju.GundamWars.Domain.Mobiles;
using Ju.GundamWars.Domain.Systems;
using Ju.GundamWars.UseCase.Mobiles;

namespace Ju.GundamWars.Mobiles;

public class MobileEntryController(IInsertMobileUseCase insertUseCase, IUpdateMobileUseCase updateUseCase, IDeleteMobileUseCase deleteUseCase, ICancelMobileUseCase cancelUseCase, WindowStatus windowStatus)
    : EntryControllerBase<MobileSubject, IInsertMobileUseCase, IUpdateMobileUseCase, IDeleteMobileUseCase, ICancelMobileUseCase>(insertUseCase, updateUseCase, deleteUseCase, cancelUseCase)
{

    public void MoveToPairSelection() => windowStatus.SlideIndexType = SlideIndexType.PairSelection;
    public void MoveToPilotSelection() => windowStatus.SlideIndexType = SlideIndexType.PilotSelection;
    public void MoveToNCuspaSelection() => windowStatus.SlideIndexType = SlideIndexType.NCuspaSelection;
    public void MoveToSCuspaSelection() => windowStatus.SlideIndexType = SlideIndexType.SCuspaSelection;
    public void MoveToSupportSelection() => windowStatus.SlideIndexType = SlideIndexType.SupportSelection;
    public void MoveToCoMobileSelection() => windowStatus.SlideIndexType = SlideIndexType.CoMobileSelection;

}
