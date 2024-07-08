using System.Windows.Controls;
using static Ju.GundamWars.App;

namespace Ju.GundamWars.Systems;

/// <summary>
/// ProgressView.xaml の相互作用ロジック
/// </summary>
public partial class ProgressView : UserControl
{
    public ProgressView()
    {
        InitializeComponent();
        DataContext = GetRequiredService<ProgressViewModel>();
    }
}
