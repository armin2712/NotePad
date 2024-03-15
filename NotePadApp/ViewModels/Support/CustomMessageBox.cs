using System.Runtime.CompilerServices;
using System.Windows;
using WPF.Window.Support;

namespace NotePadApp.ViewModels.Support
{
    /// <summary>
    /// Represents a custom message box utility for displaying messages
    /// to the user with various options for button layout (e.g., Ok, Yes/No).
    /// </summary>
    public enum MessageType
    {
        /// <summary>
        /// Specifies a message box with Ok button only.
        /// </summary>
        Ok,

        /// <summary>
        /// Specifies a message box with Yes and No buttons.
        /// </summary>
        YesNo
    }

    /// <summary>
    /// Provides static methods for displaying custom message boxes
    /// with configurable button layouts and message content.
    /// </summary>
    public static class CustomMessageBox
    {
        #region Window Controller

        /// <summary>
        /// Internal field
        /// </summary>
        private static WindowController _Controller = null!;

        /// <summary>
        /// Provides the service for handling the display of the MessageBox
        /// </summary>
        private static WindowController Controller
        {
            get
            {
                if (CustomMessageBox._Controller == null)
                {
                    CustomMessageBox._Controller = new WindowController(WindowType.MessageBox);
                }
                return CustomMessageBox._Controller;
            }
        }

        #endregion Window Controller

        /// <summary>
        /// Gets or sets the Result of the MessageBox
        /// </summary>
        private static MessageBoxResult Result { get; set; }

        /// <summary>
        /// Gets or Sets the type of the Message
        /// </summary>
        private static MessageType MessageType { get; set; }

        /// <summary>
        /// Internal field
        /// </summary>
        private static string _Message = string.Empty;

        /// <summary>
        /// Gets or sets the message content to be displayed in the message box.
        /// </summary>
        public static string Message
        {
            get => CustomMessageBox._Message;

            set => CustomMessageBox._Message = value;

        }

        /// <summary>
        /// Displays a custom message box with the specified message text and button layout.
        /// </summary>
        /// <param name="text">The message text to display.</param>
        /// <param name="typ">The button layout type for the message box.</param>
        /// <param name="owner">The Window that should present the MessageBox</param>
        /// <returns>The result of the user interaction with the message box.</returns>
        public static MessageBoxResult Show(string text, MessageType typ, System.Windows.Window owner=null!)
        {
            //Set the message
            CustomMessageBox.Message = text;
            //Set the Type of the message
            CustomMessageBox.MessageType = typ;

            if (CustomMessageBox.MessageType == MessageType.YesNo)
            {
                CustomMessageBox.IsYesNoMessage = true;
            }
            else
            {
                CustomMessageBox.IsYesNoMessage = false;

            }
            //Get the Active Window
            if (owner is System.Windows.Window w){
               
                CustomMessageBox.OpenDialog(w);
            }
            else
            {
                var mainWindow = System.Windows.Application.
                Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive);
                CustomMessageBox.OpenDialog(mainWindow!);
            }

            return CustomMessageBox.Result;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the message box has a Yes/No button layout.
        /// </summary>
        public static bool IsYesNoMessage { get; set; } = false;

        /// <summary>
        /// Internal field
        /// </summary>
        private static BaseCommand _Yes = null!;

        /// <summary>
        /// Gets the command for handling the Yes button click event in the message box.
        /// </summary>
        public static BaseCommand Yes
        {
            get
            {
                if (CustomMessageBox._Yes == null)
                {
                    CustomMessageBox._Yes = new BaseCommand(d =>
                    {
                        CustomMessageBox.Result = MessageBoxResult.Yes;
                        CustomMessageBox.CloseWindow();
                    });
                }
                return CustomMessageBox._Yes;
            }
        }

        /// <summary>
        /// Internal field
        /// </summary>
        private static BaseCommand _No = null!;

        /// <summary>
        /// Gets the command for handling the No button click event in the message box.
        /// </summary>
        public static BaseCommand No
        {
            get
            {
                if (CustomMessageBox._No == null)
                {
                    CustomMessageBox._No = new BaseCommand(d =>
                    {
                        CustomMessageBox.Result = MessageBoxResult.No;
                        CustomMessageBox.CloseWindow();

                    });
                }
                return CustomMessageBox._No;
            }
        }

        /// <summary>
        /// Internal field
        /// </summary>
        private static BaseCommand _Cancel = null!;

        /// <summary>
        /// Gets the command for handling the Cancel button click event in the message box.
        /// </summary>
        public static BaseCommand Cancel
        {
            get
            {
                if (CustomMessageBox._Cancel == null)
                {
                    CustomMessageBox._Cancel = new BaseCommand(d =>
                    {
                        CustomMessageBox.Result = MessageBoxResult.Cancel;
                        CustomMessageBox.CloseWindow();


                    });
                }
                return CustomMessageBox._Cancel;
            }
        }

        /// <summary>
        /// Internal field
        /// </summary>
        private static BaseCommand _Ok = null!;

        /// <summary>
        /// Gets the command for handling the Ok button click event in the message box.
        /// </summary>
        public static BaseCommand Ok
        {
            get
            {
                if (CustomMessageBox._Ok == null)
                {
                    CustomMessageBox._Ok = new BaseCommand(d =>
                    {
                        CustomMessageBox.Result = MessageBoxResult.OK;
                        CustomMessageBox.CloseWindow();

                    });
                }
                return CustomMessageBox._Ok;
            }
        }

        /// <summary>
        /// Closes the MessageBox
        /// </summary>
        private static void CloseWindow()
        {
            CustomMessageBox.Controller.CloseWindow();
        }

        /// <summary>
        /// Opens the MessageBox 
        /// </summary>
        /// <param name="p">System.Windows.Window where the MessageBox will be shown</param>
        private static void OpenDialog(object p)
        {
            if (p is System.Windows.Window callingWindow)
            {
                if (CustomMessageBox.IsYesNoMessage)
                {
                    CustomMessageBox.Controller.Display<Views.Support.MessageYesNo>(callingWindow);

                }
                else
                {
                    CustomMessageBox.Controller.Display<Views.Support.MessageOk>(callingWindow);

                }

            }
        }
    }
}
