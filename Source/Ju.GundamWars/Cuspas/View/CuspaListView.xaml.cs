using System.Windows.Controls;

namespace Ju.GundamWars.Cuspas.View;

/// <summary>
/// CuspaListView.xaml の相互作用ロジック
/// </summary>
public partial class CuspaListView : UserControl
{
    public CuspaListView()
    {
        InitializeComponent();
        DataContext = App.GetRequiredService<CuspaListViewModel>();
    }
}
