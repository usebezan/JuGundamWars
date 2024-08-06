using System.Windows.Controls;

namespace Ju.GundamWars.Supports.View;

/// <summary>
/// SupportListView.xaml の相互作用ロジック
/// </summary>
public partial class SupportListView : UserControl
{
    public SupportListView()
    {
        InitializeComponent();
        DataContext = App.GetRequiredService<SupportListViewModel>();
    }
}
