
using WPF.Window.Support;

namespace NotePadApp.ViewModels.Support
{
    /// <summary>
    /// Manager responsible for controlling line navigation window operations.
    /// </summary>
    internal class LineNavigationWindowManager : BaseViewModel
    {
        #region Window Controller

        /// <summary>
        /// Internal field
        /// </summary>
        private WindowController _Controller = null!;

        /// <summary>
        /// Gets the window controller for the line navigation window.
        /// </summary>
        private WindowController Controller
        {
            get
            {
                if (this._Controller == null)
                {
                    this._Controller = new WindowController(WindowType.GoToWindow);
                }
                return this._Controller;
            }
        }

        #endregion Window Controller

        /// <summary>
        /// Opens the line navigation window.
        /// </summary>
        /// <param name="p">A System.Windows.Window that owns the Navigation View.</param>
        public void OpenNavigationWindow(object p)
        {
            if (p is System.Windows.Window callingWindow)
            {
                this.Controller.Display<Views.Support.GoToView>(callingWindow);
            }
        }

        /// <summary>
        /// Command to close/hide the line navigation window.
        /// </summary>
        private BaseCommand _Close = null!;

        /// <summary>
        /// Gets the command to close the line navigation window.
        /// </summary>
        public BaseCommand Close
        {
            get
            {
                if (this._Close == null)
                {
                    this._Close = new BaseCommand(d => this.Controller.CloseWindow());
                }
                return this._Close;
            }
        }
    }
}
