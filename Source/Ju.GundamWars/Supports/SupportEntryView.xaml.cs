using System.Windows.Controls;
using static Ju.GundamWars.App;

namespace Ju.GundamWars.Supports;

/// <summary>
/// SupportEntryView.xaml の相互作用ロジック
/// </summary>
public partial class SupportEntryView : UserControl
{
    public SupportEntryView()
    {
        InitializeComponent();
        DataContext = GetRequiredService<SupportEntryViewModel>();
    }
}
