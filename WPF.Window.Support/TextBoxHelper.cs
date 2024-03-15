using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace WPF.Window.Support
{
    /// <summary>
    /// A helper class for working with TextBox controls in WPF.
    /// </summary>
    public class TextBoxHelper
    {
        /// <summary>
        /// Gets the selected text of a TextBox control.
        /// </summary>
        public static string GetSelectedText(DependencyObject obj)
        {
            return (string)obj.GetValue(SelectedTextProperty);
        }

        /// <summary>
        /// Sets the selected text of a TextBox control.
        /// </summary>
        public static void SetSelectedText(DependencyObject obj, string value)
        {
            obj.SetValue(SelectedTextProperty, value);
        }

        /// <summary>
        /// Gets the caret index of a TextBox control.
        /// </summary>
        public static int GetCaretIndex(DependencyObject obj)
        {
            return (int)obj.GetValue(CaretIndexProperty);
        }

        /// <summary>
        /// Sets the caret index of a TextBox control.
        /// </summary>
        public static void SetCaretIndex(DependencyObject obj, int value)
        {
            obj.SetValue(CaretIndexProperty, value);
        }

        /// <summary>
        /// Identifies the SelectedText dependency property.
        /// </summary>
        public static readonly DependencyProperty SelectedTextProperty =
            DependencyProperty.RegisterAttached(
                "SelectedText",
                typeof(string),
                typeof(TextBoxHelper),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, SelectedTextChanged));

        /// <summary>
        /// Identifies the CaretIndex dependency property.
        /// </summary>
        public static readonly DependencyProperty CaretIndexProperty =
            DependencyProperty.RegisterAttached(
                "CaretIndex",
                typeof(int),
                typeof(TextBoxHelper),
                new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, CaretIndexChanged));

        // Handler for changes to the SelectedText property
        private static void SelectedTextChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            TextBox tb = (obj as TextBox)!;
            if (tb != null)
            {
                if (e.OldValue == null && e.NewValue != null)
                {
                    // Subscribe to events when the property value changes from null to a non-null value
                    Debug.WriteLine("Subscribing to events");
                    tb.SelectionChanged += tb_SelectionChanged;
                    tb.LostFocus += tb_LostFocus; // Subscribe to LostFocus event
                }
                else if (e.OldValue != null && e.NewValue == null)
                {
                    // Unsubscribe from events when the property value changes from a non-null value to null
                    Debug.WriteLine("Unsubscribing from events");
                    tb.SelectionChanged -= tb_SelectionChanged;
                    tb.LostFocus -= tb_LostFocus; // Unsubscribe from LostFocus event
                }

                string newValue = (e.NewValue as string)!;

                // Update the TextBox's SelectedText property if it's different from the new value
                if (newValue != null && newValue != tb.SelectedText)
                {
                    tb.SelectedText = newValue as string;
                }
            }
        }

        // Handler for changes to the CaretIndex property
        private static void CaretIndexChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            TextBox tb = (obj as TextBox)!;
            if (tb != null)
            {
                int newValue = (int)e.NewValue;

                // Update the TextBox's CaretIndex property if it's different from the new value
                if (newValue != tb.CaretIndex)
                {
                    tb.CaretIndex = newValue;
                }
            }
        }

        // Handler for the SelectionChanged event of the TextBox
        private static void tb_SelectionChanged(object sender, RoutedEventArgs e)
        {
            TextBox tb = (sender as TextBox)!;
            if (tb != null)
            {
                Debug.WriteLine("SelectionChanged event fired");
                SetSelectedText(tb, tb.SelectedText);
                SetCaretIndex(tb, tb.CaretIndex);
            }
        }

        // Handler for the LostFocus event of the TextBox
        private static void tb_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (sender as TextBox)!;
            if (tb != null)
            {
                Debug.WriteLine("LostFocus event fired");
                // Force re-selecting the current selection to maintain highlight
                tb.SelectionStart = tb.SelectionStart;
                tb.SelectionLength = tb.SelectionLength;
            }
        }

        //TODO add method to get selection start and length
    }
}
