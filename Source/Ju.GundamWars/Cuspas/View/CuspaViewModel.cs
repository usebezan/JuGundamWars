using Ju.GundamWars.Commons.Domain.Model;
using Ju.GundamWars.Cuspas.Domain;

namespace Ju.GundamWars.Cuspas.View;

internal partial class CuspaViewModel(CuspaViewState viewState) : ModelBase
{

    public CuspaViewState ViewState { get; } = viewState;

}
