using System.Windows.Controls;

namespace Ju.GundamWars.Pilots.View;

/// <summary>
/// PilotListView.xaml の相互作用ロジック
/// </summary>
public partial class PilotListView : UserControl
{
    public PilotListView()
    {
        InitializeComponent();
        DataContext = App.GetRequiredService<PilotListViewModel>();
    }
}
