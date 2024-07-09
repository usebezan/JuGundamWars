using Ju.GundamWars.Domain.CoMobiles;
using Ju.GundamWars.UseCase.CoMobiles;

namespace Ju.GundamWars.CoMobiles;

public class CoMobileEntryController(IInsertCoMobileUseCase insertUseCase, IUpdateCoMobileUseCase updateUseCase, IDeleteCoMobileUseCase deleteUseCase, ICancelCoMobileUseCase cancelUseCase)
    : EntryControllerBase<CoMobileSubject, IInsertCoMobileUseCase, IUpdateCoMobileUseCase, IDeleteCoMobileUseCase, ICancelCoMobileUseCase>(insertUseCase, updateUseCase, deleteUseCase, cancelUseCase)
{
}
