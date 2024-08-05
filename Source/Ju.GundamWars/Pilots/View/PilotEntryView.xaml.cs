using System.Windows.Controls;

namespace Ju.GundamWars.Pilots.View;

/// <summary>
/// PilotEntryView.xaml の相互作用ロジック
/// </summary>
public partial class PilotEntryView : UserControl
{
    public PilotEntryView()
    {
        InitializeComponent();
        DataContext = App.GetRequiredService<PilotEntryViewModel>();
    }
}
