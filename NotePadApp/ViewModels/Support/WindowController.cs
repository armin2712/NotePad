﻿using NotePadApp.Views;
using System.Windows;
using WPF.Window.Support;

namespace NotePadApp.ViewModels.Support
{
    /// <summary>
    /// Enum representing different types of windows.
    /// </summary>
    public enum WindowType
    {
        /// <summary>
        /// Represents a window for finding text.
        /// </summary>
        FindWindow,

        /// <summary>
        /// Represents a window for navigating to a specific location.
        /// </summary>
        GoToWindow,

        /// <summary>
        /// Represents a message box window for displaying messages to the user.
        /// </summary>
        MessageBox,

        /// <summary>
        /// Represents a window for selecting font settings.
        /// </summary>
        FontWindow
    }


    /// <summary>
    /// Controller class for managing support windows in the NotePad application.
    /// </summary>
    public class WindowController : WPF.Window.Support.BaseViewModel
    {
        #region Data

        /// <summary>
        /// Gets or sets the unique Window key
        /// </summary>
        private static int WindowId { get; set; } = 1;

        /// <summary>
        /// Internal field
        /// </summary>
        private string _WindowName = null!;

        /// <summary>
        /// Gets or sets the name of Window
        /// </summary>
        private string WindowName
        {
            get
            {
                if(this._WindowName == null)
                {
                    this._WindowName = "SupportWindow" + WindowController.WindowId;
                    WindowController.WindowId++;
                }
                return this._WindowName;
            }
            set=> this._WindowName = value;
        }

        /// <summary>
        /// Gets or sets the Window type of the window 
        /// </summary>
        private WindowType WindowType { get; set; }

       
        /// <summary>
        /// Initializes a new instance of the <see cref="WindowController"/> class.
        /// </summary>
        /// <param name="windowType">The type of window.</param>
        public WindowController(WindowType windowType)
        {
            WindowType = windowType;
        }

        /// <summary>
        /// Gets or sets the calling window
        /// </summary>
        private System.Windows.Window CallingWindow { get; set; } = null!;
        #endregion Data

        /// <summary>
        /// Opens the given window.
        /// </summary>
        /// <typeparam name="T">The type of window.</typeparam>
        /// <param name="window">The window that will be used 
        /// as the owner of the made window.</param>
        public void Display<T>(System.Windows.Window window) where T :
            System.Windows.Window, new()
        {
            this.CallingWindow = System.Windows.Window.GetWindow(window);

            var Window = new T();
            Window.Name = this.WindowName;

            // Set the owner to the calling window for easy control
            Window.Owner = CallingWindow;

            // Set ShowInTaskbar property to false
            Window.ShowInTaskbar = false;

            // Handle the LocationChanged and SizeChanged events of the main window
            this.CallingWindow.LocationChanged += (sender, e) 
                => UpdateWindowPositionAndSize(Window);
            this.CallingWindow.SizeChanged += (sender, e) 
                => UpdateWindowPositionAndSize(Window);

            // Set the initial position and size for the window
            UpdateWindowPositionAndSize(Window);

            // Display the window
            Window.DataContext = this.CallingWindow.DataContext;

            if (this.WindowType == WindowType.MessageBox)
            {
                Window.ShowDialog();
            }
            else
            {
                Window.Show();

            }

            // Unsubscribe from events when the calling window is closed
            this.CallingWindow.Closed += (sender, e) =>
            {
                var window = System.Windows.Application.Current.Windows
                    .OfType<T>().FirstOrDefault
                    (w => string.Compare(w.Name, this.WindowName) == 0);
                if (window != null)
                {
                    this.CallingWindow.LocationChanged -= (sender, e) 
                    => UpdateWindowPositionAndSize(window!);
                    this.CallingWindow.SizeChanged -= (sender, e) => 
                    UpdateWindowPositionAndSize(window!);
                }
            };

        }

        /// <summary>
        /// Updates the position and size of the window based on the type of window.
        /// </summary>
        /// <param name="callingWindow">The main window.</param>
        /// <param name="window">The window to be updated.</param>
        private void UpdateWindowPositionAndSize(
            System.Windows.Window window)
        {
            if (this.WindowType == WindowType.FindWindow)
            {
                if (this.CallingWindow.WindowState != WindowState.Maximized)
                {
                    //The reason we check whether the window state is maximized
                    //is because in the view, due to design constraints,
                    //we don't have window style, and things like drag to minimize
                    //and similar functionalities I have to implement myself.
                    //To achieve the desired appearance in the maximized state,
                    //the coordinates cannot be accurately read,
                    //so we take the data from the screen rather than the calling window.

                    double offsetLeft = this.CallingWindow.Width * 0.3;
                    double offsetTop = 80;
                    double offsetWidth = this.CallingWindow.Width * 0.4;

                    double newX = this.CallingWindow.Left + offsetLeft;
                    double newY = this.CallingWindow.Top + offsetTop;
                    double newW = this.CallingWindow.Width - offsetWidth;

                    // Set the new position and size for the window
                    window.Left = newX;
                    window.Top = newY;
                    window.Width = newW;
                }
                else
                {
                    double offsetLeft =
                        System.Windows.SystemParameters.PrimaryScreenWidth * 0.7;
                    double offsetWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.4;

                    double newX = System.Windows.SystemParameters.PrimaryScreenWidth - offsetLeft;
                    double newW = System.Windows.SystemParameters.PrimaryScreenWidth - offsetWidth;

                    // Set the new position and size for the window
                    window.Left = newX;
                    window.Top = 80;
                    window.Width = newW;
                }
            }
            else
            {
                if (this.CallingWindow.WindowState != WindowState.Maximized)
                {
                    // Set the position and size of the GoTo window to match the main window
                    window.Left = this.CallingWindow.Left;
                    window.Top = this.CallingWindow.Top;
                    window.Height = this.CallingWindow.Height;
                    window.Width = this.CallingWindow.Width;
                }
                else
                {
                    // Set the position and size of the GoTo window to match the main window
                    window.Left = 0;
                    window.Top = 0;
                    window.Height = System.Windows.SystemParameters.PrimaryScreenHeight;
                    window.Width = System.Windows.SystemParameters.PrimaryScreenWidth;
                }

            }
        }

        /// <summary>
        /// Close the window.
        /// </summary>
        public void CloseWindow()
        {
            System.Windows.Application.Current.Windows.OfType<System.Windows.Window>().
                FirstOrDefault(w => string.Compare(w.Name, this.WindowName) == 0)!.Close();
            //Give the Focus to the Caller Window so the app stays on top
            this.CallingWindow.Focus();

        }

       


    }
}
