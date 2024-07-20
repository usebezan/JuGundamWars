using System.Windows.Controls;
using static Ju.GundamWars.App;

namespace Ju.GundamWars.Mobiles;

/// <summary>
/// MobileEntryView.xaml の相互作用ロジック
/// </summary>
public partial class MobileEntryView : UserControl
{
    public MobileEntryView()
    {
        InitializeComponent();
        DataContext = GetRequiredService<MobileEntryViewModel>();
    }
}
