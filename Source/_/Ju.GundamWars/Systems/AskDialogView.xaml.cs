using System.Windows.Controls;
using static Ju.GundamWars.App;

namespace Ju.GundamWars.Systems;

/// <summary>
/// AskDialogView.xaml の相互作用ロジック
/// </summary>
public partial class AskDialogView : UserControl
{
    public AskDialogView()
    {
        InitializeComponent();
        DataContext = GetRequiredService<AskDialogViewModel>();
    }
}
