using MahApps.Metro.Controls;
using System;
using static Ju.GundamWars.App;

namespace Ju.GundamWars.Systems;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : MetroWindow
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = GetRequiredService<MainViewModel>();
    }

    private void MetroWindow_ContentRendered(object sender, EventArgs e)
    {
        if (DataContext is not MainViewModel vm) return;
        vm.LoadCommand.Execute(DataContext);
    }
}
