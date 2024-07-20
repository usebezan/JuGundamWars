using System.Windows.Controls;
using static Ju.GundamWars.App;

namespace Ju.GundamWars.Pilots;

/// <summary>
/// PilotSelectionView.xaml の相互作用ロジック
/// </summary>
public partial class PilotSelectionView : UserControl
{
    public PilotSelectionView()
    {
        InitializeComponent();
        DataContext = GetRequiredService<PilotSelectionViewModel>();
    }
}
