using System.Windows.Controls;
using static Ju.GundamWars.App;

namespace Ju.GundamWars.Supports;

/// <summary>
/// SupportSelectionView.xaml の相互作用ロジック
/// </summary>
public partial class SupportSelectionView : UserControl
{
    public SupportSelectionView()
    {
        InitializeComponent();
        DataContext = GetRequiredService<SupportSelectionViewModel>();
    }
}
