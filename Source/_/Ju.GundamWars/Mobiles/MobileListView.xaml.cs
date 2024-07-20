using System.Windows.Controls;
using static Ju.GundamWars.App;

namespace Ju.GundamWars.Mobiles;

/// <summary>
/// MobileListView.xaml の相互作用ロジック
/// </summary>
public partial class MobileListView : UserControl
{
    public MobileListView()
    {
        InitializeComponent();
        DataContext = GetRequiredService<MobileListViewModel>();
    }
}
