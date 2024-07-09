using Ju.GundamWars.CoMobiles;
using System.Windows.Controls;
using static Ju.GundamWars.App;

namespace Ju.GundamWars.CoMobiles;

/// <summary>
/// CoMobileEntryView.xaml の相互作用ロジック
/// </summary>
public partial class CoMobileEntryView : UserControl
{
    public CoMobileEntryView()
    {
        InitializeComponent();
        DataContext = GetRequiredService<CoMobileEntryViewModel>();
    }
}
