using System.Windows.Controls;
using static Ju.GundamWars.App;

namespace Ju.GundamWars.Mobiles;

/// <summary>
/// MobileSelectionView.xaml の相互作用ロジック
/// </summary>
public partial class MobileSelectionView : UserControl
{
    public MobileSelectionView()
    {
        InitializeComponent();
        DataContext = GetRequiredService<MobileSelectionViewModel>();
    }
}
