using CommunityToolkit.Mvvm.ComponentModel;
using Ju.GundamWars.Commons.Domain.Model;

namespace Ju.GundamWars.Cuspas.View;

internal partial class CuspaViewModel : ModelBase
{

    [ObservableProperty]
    private int _PageIndex = 0;

}
