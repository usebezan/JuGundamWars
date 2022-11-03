using Ju.GundamWars.ViewModels;
using MahApps.Metro.Controls;
using System;
using static Ju.GundamWars.App;


namespace Ju.GundamWars.Views
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = GetRequiredService<MainViewModel>();
        }
    }
}
