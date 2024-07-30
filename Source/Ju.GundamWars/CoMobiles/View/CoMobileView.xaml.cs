using System.Windows.Controls;

namespace Ju.GundamWars.CoMobiles.View;

/// <summary>
/// CoMobileView.xaml の相互作用ロジック
/// </summary>
public partial class CoMobileView : UserControl
{
    public CoMobileView()
    {
        InitializeComponent();
        DataContext = App.GetRequiredService<CoMobileViewModel>();
    }
}
