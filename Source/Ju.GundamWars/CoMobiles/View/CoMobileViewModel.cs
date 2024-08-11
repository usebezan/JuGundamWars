using Ju.GundamWars.Commons.Domain.Model;
using Ju.GundamWars.Commons.View;

namespace Ju.GundamWars.CoMobiles.View;

internal partial class CoMobileViewModel(ViewState viewState) : ModelBase
{

    public ViewState ViewState { get; } = viewState;

}
