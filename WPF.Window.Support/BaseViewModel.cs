using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Window.Support
{

    /// <summary>
    /// Helper for MVVM ViewModel
    /// </summary>
    public abstract class BaseViewModel : Application.AppObject,
        System.ComponentModel.INotifyPropertyChanged
    {
        #region PropertyChanged

        /// <summary>
        /// Triggers on property change
        /// </summary>
        public event PropertyChangedEventHandler?
            PropertyChanged = null;

        /// <summary>
        /// Notify the UI that on peoperty changed
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnPropertyChanged(
            PropertyChangedEventArgs e)
        {
            var HandleCopy = this.PropertyChanged;
            if (HandleCopy != null)
            {
                HandleCopy(this, e);
            }
        }

        /// <summary>
        /// Triggers PropertyChanged event
        /// </summary>
        protected virtual void OnPropertyChanged(
            [System.Runtime.CompilerServices.CallerMemberName]
            string name=null!)
        {
            this.OnPropertyChanged(
                new PropertyChangedEventArgs(name));
        }

        #endregion PropertyChanged

        #region Window State

        /// <summary>
        /// Restores the window state using the
        /// window data from Infrastrucuture
        /// </summary>
        /// <param name="window"></param>
        protected void RestoreState(
            System.Windows.Window window)
        {
            var OldState = this.Context.Window.Fetch(window.Name);

            if (OldState != null)
            {
                window.Left = OldState.Left ?? window.Left;
                window.Top = OldState.Top ?? window.Top;
                window.Width = OldState.Width ?? window.Width;
                window.Height = OldState.Height ?? window.Height;

                if (OldState.Condition
                    == (int)System.Windows.WindowState.Maximized)
                {
                    window.WindowState = System.Windows
                        .WindowState.Maximized;
           
                }
                else
                {
                    window.WindowState
                        = System.Windows.WindowState.Normal;
       
                }

            }

        }

        /// <summary>
        /// Provides the Window Information to
        /// the WindowManager
        /// </summary>
        /// <param name="window"></param>
        protected void StoreState(System.Windows.Window window)
        {
            //for the Window create an Infor object
            //with the name as key
            var Info = new Application.Data.WindowInformation
            {
                Name = window.Name
            };

            Info.Condition = (int)window.WindowState;

            //Get the position only if the state is normal
            if (window.WindowState == System.Windows.WindowState.Normal)
            {
                Info.Left = (int)window.Left;
                Info.Top = (int)window.Top;
                Info.Width = (int)window.Width;
                Info.Height = (int)window.Height;
            }

            //Provide the Info Object to je WindowManager
            this.Context.Window.Deposit(Info);
        }


        #endregion Window State

    }
}
