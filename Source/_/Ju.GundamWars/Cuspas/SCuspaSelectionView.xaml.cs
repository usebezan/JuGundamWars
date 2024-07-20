using System.Windows.Controls;
using static Ju.GundamWars.App;

namespace Ju.GundamWars.Cuspas;

/// <summary>
/// SCuspaSelectionView.xaml の相互作用ロジック
/// </summary>
public partial class SCuspaSelectionView : UserControl
{
    public SCuspaSelectionView()
    {
        InitializeComponent();
        DataContext = GetRequiredService<SCuspaSelectionViewModel>();
    }
}
