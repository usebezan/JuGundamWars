using System.Windows.Controls;
using static Ju.GundamWars.App;

namespace Ju.GundamWars.Pilots;

/// <summary>
/// PilotEntryView.xaml の相互作用ロジック
/// </summary>
public partial class PilotEntryView : UserControl
{
    public PilotEntryView()
    {
        InitializeComponent();
        DataContext = GetRequiredService<PilotEntryViewModel>();
    }
}
