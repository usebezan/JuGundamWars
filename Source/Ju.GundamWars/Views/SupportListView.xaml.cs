using Ju.GundamWars.ViewModels;
using System;
using System.Windows.Controls;
using static Ju.GundamWars.App;


namespace Ju.GundamWars.Views
{
    /// <summary>
    /// SupportListView.xaml の相互作用ロジック
    /// </summary>
    public partial class SupportListView : UserControl
    {
        public SupportListView()
        {
            InitializeComponent();
            DataContext = GetRequiredService<SupportListViewModel>();
        }
    }
}
