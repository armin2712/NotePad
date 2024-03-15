using WPF.Window.Support;

namespace NotePadApp.ViewModels.FindService
{
    /// <summary>
    /// Provides a manager responsible for managing search operations.
    /// </summary>
    public class FindManager : WPF.Window.Support.BaseViewModel
    {
        #region Find Window Manager

        /// <summary>
        /// Internal field
        /// </summary>
        private FindWindowManager _Window = null!;

        /// <summary>
        /// Gets the window manager for the find window.
        /// </summary>
        public FindWindowManager Window
        {
            get
            {
                if (_Window == null)
                {
                    _Window = Context.Produce<FindWindowManager>();
                }
                return _Window;
            }
        }

        #endregion Find Window Manager

        #region Controller

        /// <summary>
        /// Internal field for the search controller.
        /// </summary>
        private FindController _Controller = null!;

        /// <summary>
        /// Gets the controller for search operations.
        /// </summary>
        private FindController Controller
        {
            get
            {
                if (this._Controller == null)
                {
                    this._Controller = Context.Produce<FindController>();
                }
                return this._Controller;
            }
        }

        #endregion Controller

        #region Data
        /// <summary>
        /// Internal field for storing search data.
        /// </summary>
        private SearchData _Data = null!;

        /// <summary>
        /// Gets or sets the search information.
        /// </summary>
        public SearchData Data
        {
            get
            {
                if (this._Data == null)
                {
                    this._Data = Context.Produce<SearchData>();
                }
                return this._Data;
            }
            set
            {
                this._Data = value;
                this.OnPropertyChanged();
            }
        }
        #endregion Data

        /// <summary>
        /// Command to clear the search query.
        /// </summary>
        private BaseCommand _ClearSearchQuery = null!;

        /// <summary>
        /// Gets the command to clear the search query.
        /// </summary>
        public BaseCommand ClearSearchQuery
        {
            get
            {
                if (_ClearSearchQuery == null)
                {
                    _ClearSearchQuery = new BaseCommand(d => this.Data.SearchQuery = string.Empty);
                }
                return _ClearSearchQuery;
            }
        }

        /// <summary>
        /// Initiates a search for the next occurrence 
        /// of the specified text within the provided document.
        /// </summary>
        /// <param name="tab">The tab containing the text to search.</param>
        /// <param name="p">The caller of the method.</param>
        public void FindNext(Tab tab, object p)
        {
            this.Data.SearchIndex = 0;
            this.Data.IsNext = true;
            this.Controller.FindInText(tab, this.Data, p);
        }

        /// <summary>
        /// Searches for the first occuerence of the SearchQuerry, from the Data object,
        /// in the Tab Content and replaces it with the Replace Text
        /// </summary>
        /// <param name="tab">the Currently selected tab</param>
        /// <param name="p">System.Windows.Window to focus on</param>
        public void Replace(Tab tab, object p)
        {
            if (!string.IsNullOrEmpty(this.Data.ReplaceText))
            {
                this.Data.SearchIndex = 0;
                this.Data.IsNext = true;
                this.Controller.FindInText(tab, this.Data, p, this.Data.ReplaceText);
            }
        }

        /// <summary>
        /// Searches all occuerences of the SearchQuerry, from the Data object,
        /// in the Tab Content and replaces it with the Replace Text
        /// </summary>
        /// <param name="tab">the Currently selected tab</param>
        /// <param name="p">System.Windows.Window to focus on</param>
        public void ReplaceAll(Tab tab, object p)
        {
            if (!string.IsNullOrEmpty(this.Data.SearchQuery) && !string.IsNullOrEmpty(this.Data.ReplaceText))
            {
                this.Controller.Replace(tab, this.Data,p);
            }

        }

        /// <summary>
        /// Initiates a search for the previous occurrence 
        /// of the specified text within the provided document.
        /// </summary>
        /// <param name="tab">The tab containing the text to search.</param>
        /// <param name="p">The caller of the method.</param>
        public void FindPrevious(Tab tab, object p)
        {
            this.Data.IsNext = false;
            this.Controller.FindInText(tab, this.Data, p);
        }
    }
}
