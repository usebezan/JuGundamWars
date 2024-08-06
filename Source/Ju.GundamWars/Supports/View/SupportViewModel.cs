using Ju.GundamWars.Commons.Domain.Model;
using Ju.GundamWars.Supports.Domain;

namespace Ju.GundamWars.Supports.View;

internal partial class SupportViewModel(SupportViewState viewState) : ModelBase
{

    public SupportViewState ViewState { get; } = viewState;

}
