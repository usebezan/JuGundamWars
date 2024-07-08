using System.Windows.Controls;
using static Ju.GundamWars.App;

namespace Ju.GundamWars.Cuspas;

/// <summary>
/// NCuspaSelectionView.xaml の相互作用ロジック
/// </summary>
public partial class NCuspaSelectionView : UserControl
{
    public NCuspaSelectionView()
    {
        InitializeComponent();
        DataContext = GetRequiredService<NCuspaSelectionViewModel>();
    }
}
