using System.Windows.Controls;

namespace Ju.GundamWars.Pilots.View;

/// <summary>
/// PilotView.xaml の相互作用ロジック
/// </summary>
public partial class PilotView : UserControl
{
    public PilotView()
    {
        InitializeComponent();
        DataContext = App.GetRequiredService<PilotViewModel>();
    }
}
