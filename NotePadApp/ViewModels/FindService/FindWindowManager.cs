using System.Windows;
using WPF.Window.Support;

namespace NotePadApp.ViewModels.FindService
{
    /// <summary>
    /// Manages the display window for the FindService, 
    /// including toggling visibility of the Replace section, 
    /// opening and hiding the window, and maintaining its state.
    /// </summary>
    public class FindWindowManager : BaseViewModel
    {
        #region Window Controller

        /// <summary>
        /// Internal field
        /// </summary>
        private Support.WindowController _Controller = null!;

        /// <summary>
        /// Provides the base window handling for the Find window
        /// </summary>
        private Support.WindowController Controller
        {
            get
            {
                if(this._Controller == null)
                {
                    this._Controller = new Support.WindowController(Support.WindowType.FindWindow);
                }
                return this._Controller;
            }
        }

        #endregion Window Controller

        /// <summary>
        /// Internal field
        /// </summary>
        private bool _ReplaceVisibility = false;

        /// <summary>
        /// Gets or sets the Replace section visibility
        /// </summary>
        public bool ReplaceVisibility
        {
            get => _ReplaceVisibility;

            set
            {
                _ReplaceVisibility = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Toggles the visibility of the Replace section.
        /// </summary>
        private void SwitchVisibility()
        {
            if (ReplaceVisibility == false)
            {
                ReplaceVisibility = true;

            }
            else
            {
                ReplaceVisibility = false;

            }
        }

        /// <summary>
        /// Internal field
        /// </summary>
        private BaseCommand _ToggleReplace = null!;

        /// <summary>
        /// Gets the command to toggle the Replace section
        /// of the View
        /// </summary>
        public BaseCommand ToggleReplace
        {
            get
            {
                if (_ToggleReplace == null)
                {
                    _ToggleReplace = new BaseCommand(d => SwitchVisibility());
                }
                return _ToggleReplace;
            }
        }

        /// <summary>
        /// Opens the Find Window
        /// </summary>
        /// <param name="p">System.Windows.Window owner of the Find Window</param>
        public void OpenFindWindow(object p)
        {
            if (p is System.Windows.Window callingWindow)
            {
                this.Controller.Display<Views.Support.FindAndReplaceView>(callingWindow);
            }
        }

        /// <summary>
        /// Internal field
        /// </summary>
        private BaseCommand _Close = null!;

        /// <summary>
        /// Gets the command to close the FindService window
        /// </summary>
        public BaseCommand Close
        {
            get
            {
                if (this._Close == null)
                {
                    this._Close = new BaseCommand(d =>this.Controller.CloseWindow());    
                }
                return this._Close;
            }
        }

    }
}
