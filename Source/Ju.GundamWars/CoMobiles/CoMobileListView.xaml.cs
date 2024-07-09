using Ju.GundamWars.CoUnits;
using System.Windows.Controls;
using static Ju.GundamWars.App;

namespace Ju.GundamWars.CoMobiles;

/// <summary>
/// CoUnitListView.xaml の相互作用ロジック
/// </summary>
public partial class CoUnitListView : UserControl
{
    public CoUnitListView()
    {
        InitializeComponent();
        DataContext = GetRequiredService<CoUnitListViewModel>();
    }
}
