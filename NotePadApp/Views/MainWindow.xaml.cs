using NotePadApp.ViewModels;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using static System.Net.Mime.MediaTypeNames;



namespace NotePadApp.Views
{

    /// <summary>
    /// Provides the MainWindow
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initialize an Main Window Object
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            //When the user changes the tab, notify 
            this.TabCtrl.SelectionChanged += OnSelectionChanged;

            SizeChanged += Window_SizeChanged; // Subscribe to SizeChanged event

            this.TabCtrl.ItemContainerGenerator.ItemsChanged += ViewPortChanged; //Subscribe to the ItemsChanged event

            this.Footer.IsVisibleChanged += FooterViewVisibilityChanged; //Subscribe to the Visibility change of footer

            this.Unloaded += MainWindow_Unloaded; //Unsubscribe from the events above
        }


        //The code below is strictly related to the View, such as the visibility of the FooterView,
        //the visibility of the ScrollViewer for Tabs, resizing and maximizing the window,
        //as well as buttons for minimizing, restoring, and exiting the window,
        //which are typically present but, in this example,
        //needed to be removed to achieve the desired application design.

        //The only reason I have the FooterView visibility changed implemented
        //is to manipulate the grid's value where the footer is located
        //so that the content text of the tab can occupy the space smoothly
        //if the FooterView is not displayed.


        // Event handler for the Unloaded event
        private void MainWindow_Unloaded(object sender, RoutedEventArgs e)
        {
            // Unsubscribe from events
            SizeChanged -= Window_SizeChanged;
            TabCtrl.ItemContainerGenerator.ItemsChanged -= ViewPortChanged;
            Footer.IsVisibleChanged -= FooterViewVisibilityChanged;

            // Unsubscribe from the Unloaded event
            Unloaded -= MainWindow_Unloaded;

            TabCtrl.SelectionChanged -= OnSelectionChanged;
        }

        //Notify the Find Service that the selection has changed
        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var mainViewModel = this.DataContext as MainViewModel;

            if (this.TabCtrl.SelectedItem != null)
            {
            //  mainViewModel!.Tabs.Find.SelectedTab = (this.TabCtrl.SelectedItem as Tab)!;
                this.Focus();
            }
        }



        #region Footer Visibility

        /// <summary>
        /// Event handler for the Footer Visibility change
        /// </summary>
        private void FooterViewVisibilityChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

            if (Footer.Visibility == Visibility.Collapsed)
            {
                FooterRow.Height = new System.Windows.GridLength(0); //Set the row of the footer to 0
            }
            else if (Footer.Visibility == Visibility.Visible)
            {
                FooterRow.Height = new System.Windows.GridLength(30); //Restore the row of the footer to 30
            }

        }

        #endregion Footer Visibility

        #region ScrollViewer

        /// <summary>
        /// Update the scrollviewer max width 
        /// of the Tabcontrol template on window width change
        /// </summary>
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double newWidth = e.NewSize.Width - 230;
            // Accessing the ScrollViewer named "sv"
            ScrollViewer sv = (ScrollViewer)TabCtrl.Template.FindName("sv", TabCtrl);

            if (sv != null)
            {

                sv.MaxWidth = newWidth;
                CheckVisibility(sv);

            }
        }

        /// <summary>
        /// Checks if the scrollviewer of the given object
        /// should be displayed on the Items list changed event
        /// </summary>
        private void ViewPortChanged(object sender, ItemsChangedEventArgs e)
        {
            //Find the scrollviewer of the Tabcontrol
            ScrollViewer sv = (ScrollViewer)TabCtrl.Template.FindName("sv", TabCtrl);

            if (sv != null)
            {
                CheckVisibility(sv);
            }

        }

        /// <summary>
        /// Checks if the buttons for scrolling the scrollviewer
        /// content should be displayed
        /// </summary>
        /// <param name="sv">An ScrollViewer object that needs to be checked</param>
        private static void CheckVisibility(System.Windows.Controls.ScrollViewer sv)
        {
            //Find the Buttons in the template
            RepeatButton leftScrollButton = (RepeatButton)sv.Template.FindName("LeftScroll", sv);
            RepeatButton rightScrollButton = (RepeatButton)sv.Template.FindName("RightScroll", sv);

            if (leftScrollButton != null && rightScrollButton != null)
            {
                leftScrollButton.Visibility = sv.ExtentWidth > sv.ViewportWidth ? Visibility.Visible : Visibility.Collapsed;
                rightScrollButton.Visibility = sv.ExtentWidth > sv.ViewportWidth ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        #endregion ScrollViewer

        #region Window bar behavior

        /// <summary>
        /// Minimaze the Window
        /// </summary>
        private void MinimizeBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        /// <summary>
        /// Restore the window
        /// </summary>
        /// <remarks> If the region below is not used, 
        /// the commented out solution will work and add a Click event with 
        /// DragMove() for the movement</remarks>
        private void RestoreBtn_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                // Restore the window to normal state
                WindowState = WindowState.Normal;
                this.RestoreBtn.Content = "\u2b1c";


                //BorderThickness = new Thickness(WindowState == WindowState.Maximized ? 8 : 0);
            }
            else
            {

                WindowState = WindowState.Maximized;
                this.RestoreBtn.Content ="\u2750";


                // WindowStyle = WindowStyle.None;
                //BorderThickness = new Thickness(WindowState == WindowState.Maximized ? 8 : 0);
            }

        }

        /// <summary>
        /// Close Window
        /// </summary>
        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        #endregion Window bar behavior

        private void Ziehen(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void GrößeGeändert(object sender, SizeChangedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.BorderThickness = new System.Windows.Thickness(8);
            }
            else
            {
                this.BorderThickness = new System.Windows.Thickness(0);
            }
        }





    }
}
