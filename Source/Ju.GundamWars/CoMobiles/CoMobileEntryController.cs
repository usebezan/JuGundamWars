using Ju.GundamWars.Domain.CoUnits;
using Ju.GundamWars.UseCase.CoUnits;

namespace Ju.GundamWars.CoMobiles;

public class CoUnitEntryController(IInsertCoUnitUseCase insertUseCase, IUpdateCoUnitUseCase updateUseCase, IDeleteCoUnitUseCase deleteUseCase, ICancelCoUnitUseCase cancelUseCase)
    : EntryControllerBase<CoUnitSubject, IInsertCoUnitUseCase, IUpdateCoUnitUseCase, IDeleteCoUnitUseCase, ICancelCoUnitUseCase>(insertUseCase, updateUseCase, deleteUseCase, cancelUseCase)
{
}
