using System.Windows.Controls;
using static Ju.GundamWars.App;

namespace Ju.GundamWars.Mobiles;

/// <summary>
/// MobileEntryListView.xaml の相互作用ロジック
/// </summary>
public partial class MobileEntryListView : UserControl
{
    public MobileEntryListView()
    {
        InitializeComponent();
        DataContext = GetRequiredService<MobileListViewModel>();
    }
}
