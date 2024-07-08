using System.Windows.Controls;
using static Ju.GundamWars.App;

namespace Ju.GundamWars.Tags;

/// <summary>
/// TagListView.xaml の相互作用ロジック
/// </summary>
public partial class TagListView : UserControl
{
    public TagListView()
    {
        InitializeComponent();
        DataContext = GetRequiredService<TagListViewModel>();
    }
}
