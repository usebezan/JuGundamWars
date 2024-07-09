using Ju.GundamWars.CoUnits;
using System.Windows.Controls;
using static Ju.GundamWars.App;

namespace Ju.GundamWars.CoMobiles;

/// <summary>
/// CoUnitSelectionView.xaml の相互作用ロジック
/// </summary>
public partial class CoUnitSelectionView : UserControl
{
    public CoUnitSelectionView()
    {
        InitializeComponent();
        DataContext = GetRequiredService<CoUnitSelectionViewModel>();
    }
}
