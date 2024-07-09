using Ju.GundamWars.CoMobiles;
using System.Windows.Controls;
using static Ju.GundamWars.App;

namespace Ju.GundamWars.CoMobiles;

/// <summary>
/// CoMobileSelectionView.xaml の相互作用ロジック
/// </summary>
public partial class CoMobileSelectionView : UserControl
{
    public CoMobileSelectionView()
    {
        InitializeComponent();
        DataContext = GetRequiredService<CoMobileSelectionViewModel>();
    }
}
