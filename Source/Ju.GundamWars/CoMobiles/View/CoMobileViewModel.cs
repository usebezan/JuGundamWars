using Ju.GundamWars.Commons.Domain.Model;
using Ju.GundamWars.CoMobiles.Domain;

namespace Ju.GundamWars.CoMobiles.View;

internal partial class CoMobileViewModel(CoMobileViewState viewState) : ModelBase
{

    public CoMobileViewState ViewState { get; } = viewState;

}
