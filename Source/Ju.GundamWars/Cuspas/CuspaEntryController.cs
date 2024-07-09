using Ju.GundamWars.Core.Ju.GundamWars.Cuspas;
using Ju.GundamWars.UseCase.Cuspas;

namespace Ju.GundamWars.Cuspas;

public class CuspaEntryController(IInsertCuspaUseCase insertUseCase, IUpdateCuspaUseCase updateUseCase, IDeleteCuspaUseCase deleteUseCase, ICancelCuspaUseCase cancelUseCase)
    : EntryControllerBase<CuspaSubject, IInsertCuspaUseCase, IUpdateCuspaUseCase, IDeleteCuspaUseCase, ICancelCuspaUseCase>(insertUseCase, updateUseCase, deleteUseCase, cancelUseCase)
{
}
