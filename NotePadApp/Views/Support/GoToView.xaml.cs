
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

using System.Windows.Input;



namespace NotePadApp.Views.Support
{
    /// <summary>
    /// Interaction logic for GoToView.xaml
    /// </summary>
    public partial class GoToView : Window
    {
        public GoToView()
        {
            InitializeComponent();
            
        }

        private static readonly Regex _regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text

        /// <summary>
        /// Checks if user input is allowed, following the answer from IsTextAllowed
        /// </summary>
        private void TextBlock_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        /// <summary>
        /// Checks the user paste input, if non numeric, blocks it
        /// </summary>
        private void TextBoxPasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (!IsTextAllowed(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }

        /// <summary>
        /// True if the input is numeric
        /// </summary>
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Set focus on the TextBox when the window is loaded
            SearchTermTextBox.Focus();
        }

    }
}
