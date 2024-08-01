using System.Windows.Controls;

namespace Ju.GundamWars.Cuspas.View;

/// <summary>
/// CuspaEntryView.xaml の相互作用ロジック
/// </summary>
public partial class CuspaEntryView : UserControl
{
    public CuspaEntryView()
    {
        InitializeComponent();
        DataContext = App.GetRequiredService<CuspaEntryViewModel>();
    }
}
