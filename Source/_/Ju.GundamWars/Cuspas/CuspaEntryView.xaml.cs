using System.Windows.Controls;
using static Ju.GundamWars.App;

namespace Ju.GundamWars.Cuspas;

/// <summary>
/// CuspaEntryView.xaml の相互作用ロジック
/// </summary>
public partial class CuspaEntryView : UserControl
{
    public CuspaEntryView()
    {
        InitializeComponent();
        DataContext = GetRequiredService<CuspaEntryViewModel>();
    }
}
