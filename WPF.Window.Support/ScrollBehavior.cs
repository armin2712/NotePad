using Microsoft.Xaml.Behaviors;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;

namespace WPF.Window.Support
{
    /// <summary>
    /// Behavior class for synchronizing a ScrollBar's scrolling with a ScrollViewer.
    /// </summary>
    public class ScrollBehavior : Behavior<ScrollBar>
    {
        /// <summary>
        /// Called when the behavior is attached to the associated object.
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();
            // Subscribe to the Scroll event of the associated ScrollBar.
            AssociatedObject.Scroll += OnScroll;
        }

        /// <summary>
        /// Called when the behavior is being detached from the associated object.
        /// </summary>
        protected override void OnDetaching()
        {
            // Unsubscribe from the Scroll event of the associated ScrollBar.
            AssociatedObject.Scroll -= OnScroll;
            base.OnDetaching();
        }

        /// <summary>
        /// Event handler for the Scroll event of the associated ScrollBar.
        /// </summary>
        /// <param name="sender">The ScrollBar that raised the event.</param>
        /// <param name="e">Event arguments containing scroll information.</param>
        private void OnScroll(object sender, ScrollEventArgs e)
        {
            // Cast the sender to a ScrollBar.
            var scrollBar = sender as ScrollBar;
            // Get the ScrollViewer associated with the ScrollBar from its Tag property.
            var scrollViewer = scrollBar?.Tag as ScrollViewer;
            // Scroll the ScrollViewer horizontally to the new offset based on the ScrollBar's value.
            scrollViewer?.ScrollToHorizontalOffset(e.NewValue);
        }
    }
}
