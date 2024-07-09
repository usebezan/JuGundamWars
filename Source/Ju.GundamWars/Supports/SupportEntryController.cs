using Ju.GundamWars.Supports.Domain;
using Ju.GundamWars.UseCase.Supports;

namespace Ju.GundamWars.Supports;

public class SupportEntryController(IInsertSupportUseCase insertUseCase, IUpdateSupportUseCase updateUseCase, IDeleteSupportUseCase deleteUseCase, ICancelSupportUseCase cancelUseCase)
    : EntryControllerBase<SupportSubject, IInsertSupportUseCase, IUpdateSupportUseCase, IDeleteSupportUseCase, ICancelSupportUseCase>(insertUseCase, updateUseCase, deleteUseCase, cancelUseCase)
{
}
