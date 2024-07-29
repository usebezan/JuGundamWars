using System.Windows.Controls;

namespace Ju.GundamWars.Systems.View;

/// <summary>
/// LoadAllProgressView.xaml の相互作用ロジック
/// </summary>
public partial class LoadAllProgressView : UserControl
{
    public LoadAllProgressView()
    {
        InitializeComponent();
        DataContext = App.GetRequiredService<LoadAllProgressViewModel>();
    }
}
