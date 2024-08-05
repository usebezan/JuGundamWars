using Ju.GundamWars.Commons.Domain.Model;
using Ju.GundamWars.Pilots.Domain;

namespace Ju.GundamWars.Pilots.View;

internal partial class PilotViewModel(PilotViewState viewState) : ModelBase
{

    public PilotViewState ViewState { get; } = viewState;

}
