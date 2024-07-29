using MahApps.Metro.Controls;

namespace Ju.GundamWars;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : MetroWindow
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = App.GetRequiredService<MainViewModel>();
    }
}