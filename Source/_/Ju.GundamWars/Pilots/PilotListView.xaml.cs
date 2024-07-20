using System.Windows.Controls;
using static Ju.GundamWars.App;

namespace Ju.GundamWars.Pilots;

/// <summary>
/// PilotListView.xaml の相互作用ロジック
/// </summary>
public partial class PilotListView : UserControl
{
    public PilotListView()
    {
        InitializeComponent();
        DataContext = GetRequiredService<PilotListViewModel>();
    }
}
