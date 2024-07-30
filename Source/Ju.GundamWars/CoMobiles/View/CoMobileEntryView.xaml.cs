using System.Windows.Controls;

namespace Ju.GundamWars.CoMobiles.View;

/// <summary>
/// CoMobileEntryView.xaml の相互作用ロジック
/// </summary>
public partial class CoMobileEntryView : UserControl
{
    public CoMobileEntryView()
    {
        InitializeComponent();
        DataContext = App.GetRequiredService<CoMobileEntryViewModel>();
    }
}
