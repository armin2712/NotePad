using NotePadApp.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace NotePadApp.Views.Support
{
    /// <summary>
    /// Interaction logic for FindAndReplaceView.xaml
    /// </summary>
    public partial class FindAndReplaceView : Window
    {
        // Variable to store the last focused element
        private UIElement? lastFocusedElement;

        public FindAndReplaceView()
        {
            InitializeComponent();

            // Assigning event handler for GotFocus event
            GotFocus += MainWindow_GotFocus;

            // Subscribe to the IsVisibleChanged event
            ReplaceRowContent.IsVisibleChanged += WindowSizeHandler;

            // Subscribe to the Unloaded event
            Unloaded += FindAndReplaceView_Unloaded;
        }

        // Event handler for GotFocus event of the window
        //So when we get the focus back from the Find command, the focus gets on the textbox
        private void MainWindow_GotFocus(object sender, RoutedEventArgs e)
        {
            // Check if the last focused element was the find button
            if (lastFocusedElement == FindButton)
            {
                // Set focus to the textbox
                searchTextBox.Focus();
            }
        }

        // Event handler for GotFocus event of all elements
        private void Element_GotFocus(object sender, RoutedEventArgs e)
        {
            // Update the last focused element
            lastFocusedElement = sender as UIElement;
        }

        // Event handler for the Unloaded event
        private void FindAndReplaceView_Unloaded(object sender, RoutedEventArgs e)
        {
            // Unsubscribe from the IsVisibleChanged event
            ReplaceRowContent.IsVisibleChanged -= WindowSizeHandler;

            // Unsubscribe from the Unloaded event
            Unloaded -= FindAndReplaceView_Unloaded;
        }

        // Event handler for the IsVisibleChanged event
        private void WindowSizeHandler(object sender, DependencyPropertyChangedEventArgs e)
        {
            // Create a double animation
            DoubleAnimation animation = new DoubleAnimation();

            // Set the animation properties based on the visibility of ReplaceRowContent
            if (ReplaceRowContent.Visibility == Visibility.Visible)
            {
                animation.From = Height;
                animation.To = 135;
            }
            else
            {
                animation.From = Height;
                animation.To = 80;
            }

            // Set the animation duration
            animation.Duration = TimeSpan.FromSeconds(0.1); // Adjust the duration as needed

            // Begin the animation on the window's height property
            BeginAnimation(HeightProperty, animation);
        }
    }
}
