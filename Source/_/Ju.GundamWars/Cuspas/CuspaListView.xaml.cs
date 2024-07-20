using System.Windows.Controls;
using static Ju.GundamWars.App;

namespace Ju.GundamWars.Cuspas;

/// <summary>
/// CuspaListView.xaml の相互作用ロジック
/// </summary>
public partial class CuspaListView : UserControl
{
    public CuspaListView()
    {
        InitializeComponent();
        DataContext = GetRequiredService<CuspaListViewModel>();
    }
}
