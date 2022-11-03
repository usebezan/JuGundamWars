using Ju.GundamWars.ViewModels;
using System;
using System.Windows.Controls;
using static Ju.GundamWars.App;


namespace Ju.GundamWars.Views
{
    /// <summary>
    /// MobileSuitListView.xaml の相互作用ロジック
    /// </summary>
    public partial class MobileSuitListView : UserControl
    {
        public MobileSuitListView()
        {
            InitializeComponent();
            DataContext = GetRequiredService<MobileSuitListViewModel>();
        }
    }
}
