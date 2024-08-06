using System.Windows.Controls;

namespace Ju.GundamWars.Supports.View;

/// <summary>
/// SupportView.xaml の相互作用ロジック
/// </summary>
public partial class SupportView : UserControl
{
    public SupportView()
    {
        InitializeComponent();
        DataContext = App.GetRequiredService<SupportViewModel>();
    }
}
