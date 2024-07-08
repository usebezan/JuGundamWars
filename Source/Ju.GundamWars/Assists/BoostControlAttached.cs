using System.Windows;
using System.Windows.Input;

namespace Ju.GundamWars.Assists;

public static class BoostControlAttached
{

    public static readonly DependencyProperty IndexProperty = DependencyProperty.RegisterAttached("Index", typeof(int), typeof(BoostControlAttached), new PropertyMetadata());
    public static int GetIndex(DependencyObject target) => (int)target.GetValue(IndexProperty);
    public static void SetIndex(DependencyObject target, int value) => target.SetValue(IndexProperty, value);

    public static readonly DependencyProperty TextProperty = DependencyProperty.RegisterAttached("Text", typeof(string), typeof(BoostControlAttached), new PropertyMetadata());
    public static string GetText(DependencyObject target) => (string)target.GetValue(TextProperty);
    public static void SetText(DependencyObject target, string value) => target.SetValue(TextProperty, value);

    public static readonly DependencyProperty ShowCommandProperty = DependencyProperty.RegisterAttached("ShowCommand", typeof(ICommand), typeof(BoostControlAttached), new PropertyMetadata());
    public static ICommand GetShowCommand(DependencyObject target) => (ICommand)target.GetValue(ShowCommandProperty);
    public static void SetShowCommand(DependencyObject target, ICommand value) => target.SetValue(ShowCommandProperty, value);

    public static readonly DependencyProperty DetachCommandProperty = DependencyProperty.RegisterAttached("DetachCommand", typeof(ICommand), typeof(BoostControlAttached), new PropertyMetadata());
    public static ICommand GetDetachCommand(DependencyObject target) => (ICommand)target.GetValue(DetachCommandProperty);
    public static void SetDetachCommand(DependencyObject target, ICommand value) => target.SetValue(DetachCommandProperty, value);

}
