
using NotePadApp.Models;
using NotePadApp.ViewModels.Support;
using System.Collections.ObjectModel;
using WPF.Window.Support;

namespace NotePadApp.ViewModels
{

    /// <summary>
    /// Represents a collection of tabs.
    /// </summary>
    public class Tabs :
        System.Collections.ObjectModel.ObservableCollection<Tab>
    {
      
    }


    /// <summary>
    /// Represents a tab item.
    /// </summary>
    public class Tab : BaseViewModel
    {

        #region Caret Manager

        /// <summary>
        /// Internal field
        /// </summary>
        private Support.CaretManager _Caret = null!;

        /// <summary>
        /// Gets the Caret manager of the Tab
        /// </summary>
        public Support.CaretManager Caret
        {
            get
            {
                if (this._Caret == null)
                {
                    this._Caret = new CaretManager();
                }
                return this._Caret;
            }
        }

        #endregion Caret Manager

        /// <summary>
        /// Internal Field
        /// </summary>
        private string _Name = null!;

        /// <summary>
        /// Gets or sets the name of the tab.
        /// </summary>
        public string Name
        {
            get
            {
                if (this._Name == null)
                {

                    this._Name = Assets.Info.Untitled;
                }
                return this._Name;
            }

            set
            {
                if (this._Name != value)
                {
                    this._Name = value;
                    OnPropertyChanged();

                }
            }
        }

        /// <summary>
        /// Internal Field
        /// </summary>
        private string _Content = string.Empty;

        /// <summary>
        /// Gets or sets the content of the tab.
        /// </summary>
        public string Content
        {
            get => this._Content;
            set
            {
                this._Content = value;
                this.Caret.Text = value;
                OnPropertyChanged();
                this.IsSaved = false;

                if (this.IsSaved == false && string.IsNullOrEmpty(this.Path)
                    && !string.IsNullOrEmpty(this._Content.Trim()))
                {
                    //Set the name to the Content till the first new line
                    this.Name
                        = _Content.Substring(0, _Content.IndexOf('\n') - 1 >= 0 ?
                        _Content.IndexOf('\n') - 1 : _Content.Length).Trim();
                }
                else if (string.IsNullOrEmpty(this.Path) && string.IsNullOrEmpty(_Content))
                {
                    this.IsSaved = true;
                    this.Name = Assets.Info.Untitled;

                }
                this.CharCount = this._Content.Replace("\r","").Length;

            }
        }

        /// <summary>
        /// Internal Field
        /// </summary>
        private bool _IsSaved = true;


        /// <summary>
        /// Gets or sets a value indicating whether the tab is saved.
        /// </summary>
        public bool IsSaved
        {
            get => this._IsSaved;

            set
            {
                if (this._IsSaved != value)
                {
                    this._IsSaved = value;
                }
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Internal field
        /// </summary>
        private string _SelectedText = string.Empty;

        /// <summary>
        /// Gets or sets the selected text of the Tab content
        /// </summary>
        public string SelectedText
        {
            get => this._SelectedText;
            set
            {
                this._SelectedText = value;
                OnPropertyChanged(); ;
            }
        }

        /// <summary>
        /// Internal Field
        /// </summary>
        private string _Path = string.Empty;

        /// <summary>
        /// Gets or sets the Tab save path
        /// </summary>
        public string Path
        {
            get => this._Path;

            set
            {
                if (this._Path != value)
                {
                    this._Path = value;
                }
                OnPropertyChanged();
            }

        }


        /// <summary>
        /// Internal field
        /// </summary>
        private int _CharCount = 0;

        /// <summary>
        /// Gets or sets the character count of the tab content
        /// </summary>
        public int CharCount
        {
            get => this._CharCount;
            set
            {
                this._CharCount = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Internal Field
        /// </summary>
        private BaseCommand _Delete = null!;

        /// <summary>
        /// Gets the command for deleting the selected text
        /// </summary>
        public BaseCommand Delete
        {
            get
            {
                if (this._Delete == null)
                {
                    this._Delete = new BaseCommand
                        (
                        d => this.SelectedText = this.SelectedText.Remove(0),
                        d => !string.IsNullOrEmpty(this.SelectedText)
                       );
                }
                return this._Delete;
            }
        }

        /// <summary>
        /// Internal field
        /// </summary>
        private BaseCommand _Close = null!;

        /// <summary>
        /// Gets the command to close the tab.
        /// </summary>
        public BaseCommand Close
        {
            get
            {
                if (this._Close == null)
                {

                    this._Close = new BaseCommand(data => CloseRequested?.Invoke(this, EventArgs.Empty));


                }
                return this._Close;
            }

        }

        /// <summary>
        /// Occurs when the tab is requested to be closed.
        /// </summary>
        public event EventHandler CloseRequested = null!;

    }

}