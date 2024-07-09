using Ju.GundamWars.CoMobiles;
using System.Windows.Controls;
using static Ju.GundamWars.App;

namespace Ju.GundamWars.CoMobiles;

/// <summary>
/// CoMobileListView.xaml の相互作用ロジック
/// </summary>
public partial class CoMobileListView : UserControl
{
    public CoMobileListView()
    {
        InitializeComponent();
        DataContext = GetRequiredService<CoMobileListViewModel>();
    }
}
