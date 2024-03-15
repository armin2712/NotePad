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
            this.WindowStyle = WindowStyle.SingleBorderWindow;
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
                RestoreBtn.Content = "\u2b1c";

                //BorderThickness = new Thickness(WindowState == WindowState.Maximized ? 8 : 0);
            }
            else
            {
                // Maximize the window
                //WindowStyle = WindowStyle.SingleBorderWindow;
                this.WindowStyle = WindowStyle.None;

                WindowState = WindowState.Maximized;

                RestoreBtn.Content = "\u2750";


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

        #region Window Maximized and DragMove() code

        //All of the code below handles the Maximized and drag window problem with
        //custom task bar, just copy paste it another app to use
        //In Xaml add in <Window  SourceInitialized="Window_SourceInitialized"/>
        //and in the first <Rectangle PreviewMouseLeftButtonDown="rctHeader_PreviewMouseLeftButtonDown"
        //PreviewMouseLeftButtonUp="rctHeader_PreviewMouseLeftButtonUp"
        //  PreviewMouseMove="rctHeader_PreviewMouseMove" />
        //Works on multiple Monitors
        private bool mRestoreIfMove = false; // Flag to indicate whether window should be restored if moved while maximized

        /// <summary>
        /// Event handler for the window's SourceInitialized event.
        /// </summary>
        private void Window_SourceInitialized(object sender, EventArgs e)
        {
            // Get the window handle
            IntPtr mWindowHandle = (new WindowInteropHelper(this)).Handle;
            // Add a hook to the window's message loop
            HwndSource.FromHwnd(mWindowHandle).AddHook(new HwndSourceHook(WindowProc));
        }

        /// <summary>
        /// Callback function to handle window messages.
        /// </summary>
        private static IntPtr WindowProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch (msg)
            {
                case 0x0024: // WM_GETMINMAXINFO message
                    WmGetMinMaxInfo(hwnd, lParam);
                    break;
            }

            return IntPtr.Zero;
        }

        /// <summary>
        /// Handles the WM_GETMINMAXINFO message to set minimum and maximum size of the window.
        /// </summary>
        private static void WmGetMinMaxInfo(IntPtr hwnd, IntPtr lParam)
        {
            POINT lMousePosition;
            GetCursorPos(out lMousePosition);

            // Get information about the primary monitor
            IntPtr lPrimaryScreen = MonitorFromPoint(new POINT(0, 0), MonitorOptions.MONITOR_DEFAULTTOPRIMARY);
            MONITORINFO lPrimaryScreenInfo = new MONITORINFO();
            if (GetMonitorInfo(lPrimaryScreen, lPrimaryScreenInfo) == false)
            {
                return;
            }

            // Get information about the current monitor based on mouse position
            IntPtr lCurrentScreen = MonitorFromPoint(lMousePosition, MonitorOptions.MONITOR_DEFAULTTONEAREST);

            MINMAXINFO lMmi = (MINMAXINFO)Marshal.PtrToStructure(lParam, typeof(MINMAXINFO))!;

            // Adjust maximum size and position based on current monitor
            if (lPrimaryScreen.Equals(lCurrentScreen))
            {
                lMmi.ptMaxPosition.X = lPrimaryScreenInfo.rcWork.Left;
                lMmi.ptMaxPosition.Y = lPrimaryScreenInfo.rcWork.Top;
                lMmi.ptMaxSize.X = lPrimaryScreenInfo.rcWork.Right - lPrimaryScreenInfo.rcWork.Left;
                lMmi.ptMaxSize.Y = lPrimaryScreenInfo.rcWork.Bottom - lPrimaryScreenInfo.rcWork.Top;
            }
            else
            {
                lMmi.ptMaxPosition.X = lPrimaryScreenInfo.rcMonitor.Left;
                lMmi.ptMaxPosition.Y = lPrimaryScreenInfo.rcMonitor.Top;
                lMmi.ptMaxSize.X = lPrimaryScreenInfo.rcMonitor.Right - lPrimaryScreenInfo.rcMonitor.Left;
                lMmi.ptMaxSize.Y = lPrimaryScreenInfo.rcMonitor.Bottom - lPrimaryScreenInfo.rcMonitor.Top;
            }

            // Apply the modified MINMAXINFO structure
            Marshal.StructureToPtr(lMmi, lParam, true);
        }

        /// <summary>
        /// Toggles between normal and maximized window state.
        /// </summary>
        private void SwitchWindowState()
        {
            switch (WindowState)
            {
                case WindowState.Normal:
                    WindowState = WindowState.Maximized;
                    break;
                case WindowState.Maximized:
                    WindowState = WindowState.Normal;
                    break;
            }
        }

        /// <summary>
        /// Event handler for the PreviewMouseLeftButtonDown event of the header rectangle.
        /// </summary>
        private void rctHeader_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Double-click handler to toggle window state
            if (e.ClickCount == 2)
            {
                if ((ResizeMode == ResizeMode.CanResize) || (ResizeMode == ResizeMode.CanResizeWithGrip))
                {
                    SwitchWindowState();
                }
                return;
            }
            // If window is maximized, set flag to restore window if moved
            else if (WindowState == WindowState.Maximized)
            {
                mRestoreIfMove = true;
                return;
            }

            // If not maximized, allow dragging of the window
            DragMove();
        }

        /// <summary>
        /// Event handler for the PreviewMouseLeftButtonUp event of the header rectangle.
        /// </summary>
        private void rctHeader_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // Reset flag when mouse button is released
            mRestoreIfMove = false;
        }

        /// <summary>
        /// Event handler for the PreviewMouseMove event of the header rectangle.
        /// </summary>
        private void rctHeader_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            // If flag is set, restore window and move it to new position
            if (mRestoreIfMove)
            {
                mRestoreIfMove = false;

                // Calculate position percentage based on mouse position relative to window size
                double percentHorizontal = e.GetPosition(this).X / ActualWidth;
                double targetHorizontal = RestoreBounds.Width * percentHorizontal;

                double percentVertical = e.GetPosition(this).Y / ActualHeight;
                double targetVertical = RestoreBounds.Height * percentVertical;

                // Restore window to normal state
                WindowState = WindowState.Normal;

                // Get current mouse position
                POINT lMousePosition;
                GetCursorPos(out lMousePosition);

                // Calculate new window position and move it
                Left = lMousePosition.X - targetHorizontal;
                Top = lMousePosition.Y - targetVertical;

                // Drag the window
                DragMove();
            }
        }

        // P/Invoke declarations for Win32 API functions

        /// <summary>
        /// Retrieves the cursor's position, in screen coordinates.
        /// </summary>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetCursorPos(out POINT lpPoint);

        /// <summary>
        /// Retrieves a handle to the display monitor that contains a specified point.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr MonitorFromPoint(POINT pt, MonitorOptions dwFlags);

        /// <summary>
        /// Retrieves information about a display monitor.
        /// </summary>
        [DllImport("user32.dll")]
        static extern bool GetMonitorInfo(IntPtr hMonitor, MONITORINFO lpmi);

        // Enum for monitor options
        enum MonitorOptions : uint
        {
            MONITOR_DEFAULTTONULL = 0x00000000,
            MONITOR_DEFAULTTOPRIMARY = 0x00000001,
            MONITOR_DEFAULTTONEAREST = 0x00000002
        }

        // Structures used in Win32 API calls

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;

            public POINT(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MINMAXINFO
        {
            public POINT ptReserved;
            public POINT ptMaxSize;
            public POINT ptMaxPosition;
            public POINT ptMinTrackSize;
            public POINT ptMaxTrackSize;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class MONITORINFO
        {
            public int cbSize = Marshal.SizeOf(typeof(MONITORINFO));
            public RECT rcMonitor = new RECT();
            public RECT rcWork = new RECT();
            public int dwFlags = 0;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left, Top, Right, Bottom;

            public RECT(int left, int top, int right, int bottom)
            {
                this.Left = left;
                this.Top = top;
                this.Right = right;
                this.Bottom = bottom;
            }
        }
        #endregion Window Maximized and DragMove() code

    }
}
