using Ju.GundamWars.ViewModels;
using System;
using System.Windows.Controls;
using static Ju.GundamWars.App;


namespace Ju.GundamWars.Views
{
    /// <summary>
    /// YesNoDialog.xaml の相互作用ロジック
    /// </summary>
    public partial class YesNoDialog : UserControl
    {
        public YesNoDialog()
        {
            InitializeComponent();
            DataContext = GetRequiredService<MessageDialogViewModel>();
        }
    }
}
