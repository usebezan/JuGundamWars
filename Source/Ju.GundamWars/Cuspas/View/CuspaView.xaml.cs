using System.Windows.Controls;

namespace Ju.GundamWars.Cuspas.View;

/// <summary>
/// CuspaView.xaml の相互作用ロジック
/// </summary>
public partial class CuspaView : UserControl
{
    public CuspaView()
    {
        InitializeComponent();
        DataContext = App.GetRequiredService<CuspaViewModel>();
    }
}
