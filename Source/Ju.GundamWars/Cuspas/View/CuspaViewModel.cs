using Ju.GundamWars.Commons.Domain.Model;
using Ju.GundamWars.Commons.View;

namespace Ju.GundamWars.Cuspas.View;

internal partial class CuspaViewModel(ViewState viewState) : ModelBase
{

    public ViewState ViewState { get; } = viewState;

}
