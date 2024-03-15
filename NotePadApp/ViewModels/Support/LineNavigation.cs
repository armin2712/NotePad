using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF.Window.Support;

namespace NotePadApp.ViewModels.Support
{
    /// <summary>
    /// ViewModel class for line navigation functionality.
    /// </summary>
    internal class LineNavigation : WPF.Window.Support.BaseViewModel
    {
        #region Window Manager

        /// <summary>
        /// Internal field
        /// </summary>
        private LineNavigationWindowManager _Window = null!;

        /// <summary>
        /// Gets the window manager instance.
        /// </summary>
        public LineNavigationWindowManager Window
        {
            get
            {
                if (this._Window == null)
                {
                    this._Window = this.Context.Produce<LineNavigationWindowManager>();
                }
                return this._Window;
            }
        }

        #endregion Window Manager

        // Using string instead of int, so I can clear the input

        /// <summary>
        /// Internal field
        /// </summary>
        private string _Line = string.Empty;

        /// <summary>
        /// Gets or sets the line number input.
        /// </summary>
        public string Line
        {
            get => this._Line;
            set
            {
                this._Line = value;
                OnPropertyChanged();

            }
        }

        /// <summary>
        /// Finds the index of the specified line in the given text.
        /// </summary>
        /// <param name="text">The text to search for the line index.</param>
        /// <returns>The index of the specified line in the text.</returns>
        private int FindLineIndex(string text)
        {
            int index = -1;
            for (int i = 0; i < int.Parse(this.Line) - 1; i++)
            {
                index = text.IndexOf('\n', index + 1);
                if (index == -1)
                {
                    break; // Not found
                }
            }
            return index;
        }

        /// <summary>
        /// Sets the caret position to the specified line in the given tab.
        /// </summary>
        /// <param name="tab">The tab to navigate.</param>
        public void SetLine(Tab tab,object d)
        {
            var lineCount = tab.Content.Split('\n').Length;
            if (int.Parse(this.Line) > lineCount || int.Parse(this.Line) == 0)
            {
                if(d is System.Windows.Window w)
                {
                   
                    CustomMessageBox.Show(NotePadApp.Assets.Info.GoToMessage, MessageType.Ok, w);
                   
                }
              
            }
            else
            {
                var index = this.FindLineIndex(tab.Content);
                if (index > -1)
                {
                    tab.Caret.Index = index + 1;
                    this.Window.Close.Execute(null);
                }
                else
                {
                    tab.Caret.Index = 0;
                    this.Window.Close.Execute(null);
                }

            }
        }

        /// <summary>
        /// Internal field
        /// </summary>
        private BaseCommand _ClearInput = null!;

        /// <summary>
        /// Gets the command to clear the line input.
        /// </summary>
        public BaseCommand ClearInput
        {
            get
            {
                if (this._ClearInput == null)
                {
                    this._ClearInput = new BaseCommand(d => this.Line = string.Empty);
                }
                return this._ClearInput;
            }
        }

    }
}
