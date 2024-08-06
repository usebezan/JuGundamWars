using System.Windows.Controls;

namespace Ju.GundamWars.Supports.View;

/// <summary>
/// SupportEntryView.xaml の相互作用ロジック
/// </summary>
public partial class SupportEntryView : UserControl
{
    public SupportEntryView()
    {
        InitializeComponent();
        DataContext = App.GetRequiredService<SupportEntryViewModel>();
    }
}
