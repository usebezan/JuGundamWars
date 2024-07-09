using Ju.GundamWars.CoUnits;
using System.Windows.Controls;
using static Ju.GundamWars.App;

namespace Ju.GundamWars.CoMobiles;

/// <summary>
/// CoUnitEntryView.xaml の相互作用ロジック
/// </summary>
public partial class CoUnitEntryView : UserControl
{
    public CoUnitEntryView()
    {
        InitializeComponent();
        DataContext = GetRequiredService<CoUnitEntryViewModel>();
    }
}
