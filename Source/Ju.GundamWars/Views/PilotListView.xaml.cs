using Ju.GundamWars.ViewModels;
using System;
using System.Windows.Controls;
using static Ju.GundamWars.App;


namespace Ju.GundamWars.Views
{
    /// <summary>
    /// PilotListView.xaml の相互作用ロジック
    /// </summary>
    public partial class PilotListView : UserControl
    {
        public PilotListView()
        {
            InitializeComponent();
            DataContext = GetRequiredService<PilotListViewModel>();
        }
    }
}
