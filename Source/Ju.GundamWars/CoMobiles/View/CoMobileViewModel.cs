using Ju.GundamWars.Commons.Domain.Model;

namespace Ju.GundamWars.CoMobiles.View;

internal partial class CoMobileViewModel(CoMobileViewState viewState) : ModelBase
{

    public CoMobileViewState ViewState { get; } = viewState;

}
