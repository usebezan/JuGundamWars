using Ju.GundamWars.Domain.Pilots;
using Ju.GundamWars.UseCase.Pilots;

namespace Ju.GundamWars.Pilots;

public class PilotEntryController(IInsertPilotUseCase insertUseCase, IUpdatePilotUseCase updateUseCase, IDeletePilotUseCase deleteUseCase, ICancelPilotUseCase cancelUseCase)
    : EntryControllerBase<PilotSubject, IInsertPilotUseCase, IUpdatePilotUseCase, IDeletePilotUseCase, ICancelPilotUseCase>(insertUseCase, updateUseCase, deleteUseCase, cancelUseCase)
{
}
