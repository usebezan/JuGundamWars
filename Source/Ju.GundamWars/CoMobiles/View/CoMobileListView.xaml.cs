using System.Windows.Controls;

namespace Ju.GundamWars.CoMobiles.View;

/// <summary>
/// CoMobileListView.xaml の相互作用ロジック
/// </summary>
public partial class CoMobileListView : UserControl
{
    public CoMobileListView()
    {
        InitializeComponent();
        DataContext = App.GetRequiredService<CoMobileListViewModel>();
    }
}
