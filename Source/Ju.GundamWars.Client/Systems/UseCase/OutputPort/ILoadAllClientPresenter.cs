using Ju.GundamWars.BizMaster.Commons.Domain;
using Ju.GundamWars.Commons.UseCase.OutputPort;

namespace Ju.GundamWars.Client.Systems.UseCase.OutputPort;

public interface ILoadAllClientPresenter : IPresenter<DataModels>
{
    void ShowProgress();
    void CloseProgress();
}
