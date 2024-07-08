using System.Windows;

namespace Ju.GundamWars.Assists;

public static class IconControlAttached
{

    public static readonly DependencyProperty IconProperty = DependencyProperty.RegisterAttached("Icon", typeof(string), typeof(IconControlAttached), new PropertyMetadata());
    public static string GetIcon(DependencyObject target) => (string)target.GetValue(IconProperty);
    public static void SetIcon(DependencyObject target, string value) => target.SetValue(IconProperty, value);

}
