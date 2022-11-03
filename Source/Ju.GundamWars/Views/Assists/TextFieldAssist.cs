using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;


namespace Ju.GundamWars.Views.Assists
{

    public static class TextFieldAssist
    {

        public static bool GetIsSelectAllOnGotFocus(DependencyObject obj) =>
            (bool)obj.GetValue(IsSelectAllOnGotFocusProperty);

        public static void SetIsSelectAllOnGotFocus(DependencyObject obj, bool value) =>
            obj.SetValue(IsSelectAllOnGotFocusProperty, value);

        public static readonly DependencyProperty IsSelectAllOnGotFocusProperty =
            DependencyProperty.RegisterAttached("IsSelectAllOnGotFocus", typeof(bool), typeof(TextFieldAssist), new PropertyMetadata(false, (d, e) =>
            {
                if (d is not TextBoxBase tb) return;
                if (e.NewValue is not bool isSelectAll) return;

                tb.GotFocus -= OnTextBoxBaseGotFocus;
                //tb.PreviewMouseLeftButtonDown -= OnMouseLeftButtonDown;
                if (isSelectAll)
                {
                    tb.GotFocus += OnTextBoxBaseGotFocus;
                    //tb.PreviewMouseLeftButtonDown += OnMouseLeftButtonDown;
                }
            }));

        private static void OnTextBoxBaseGotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is not TextBoxBase tb) return;

            if (GetIsSelectAllOnGotFocus(tb))
            {
                tb.SelectAll();
            }
        }

        private static void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is not TextBoxBase tb) return;
            if (tb.IsFocused) return;

            tb.Focus();
            e.Handled = true;
        }

    }

}
